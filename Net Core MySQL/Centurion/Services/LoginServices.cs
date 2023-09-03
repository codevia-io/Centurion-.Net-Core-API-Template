using Models;
using Models.Forms;
using Session;

namespace Services
{
    public class LoginServices
    {
        private readonly UserServices UserServices = new UserServices();
        private readonly SessionManagement SessionManagement = SessionManagement.GetInstance();

        public LoginAccesInfo Login(Login login)
        {
            if (login is null)
                throw new ArgumentException("Login form is null");

            if (login.UserName is null)
                throw new ArgumentException("User name is Null");

            if (login.UserName == string.Empty)
                throw new ArgumentException("User name is empty");

            if (login.Password == string.Empty)
                throw new ArgumentException("Password is empty");

            if (login.Password is null)
                throw new ArgumentException("Password is Null");

            User? user = UserServices.Find(login.UserName);

            UserServices.VerifyPassword(user.Id, login.Password);

            UserSession? sessionExist = SessionManagement.Get(user.Id);

            if (sessionExist is not null)
            {
                return new()
                {
                    UserName = sessionExist.User.UserName,
                    Tokent = sessionExist.Token,
                    Message = $"Wellcome {sessionExist.User.UserName}."
                };
            }

            UserSession userSession = new UserSession()
            {
                User = user,
                Token = TokenManagement.Create(user),
            };

            SessionManagement.Add(userSession);

            return new()
            {
                UserName = userSession.User.UserName,
                Tokent = userSession.Token,
                Message = $"Wellcome {userSession.User.UserName}."
            };
        }

        public void LogOut(string token)
        {
            UserSession? userSession = SessionManagement.UserSessions.SingleOrDefault(u => u.Token.Equals(token));

            if (userSession is null)
                throw new ArgumentException("Session does exist");

            SessionManagement.UserSessions.Remove(userSession);
        }
    }
}

