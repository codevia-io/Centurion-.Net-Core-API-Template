using Catch;
using Models;

namespace Session
{
    public sealed class SessionManagement
    {
        public static List<UserSession> UserSessions { get; set; }
        private SessionManagement()
        {
            UserSessions = new();
        }

        private static SessionManagement? _Instance;

        public static SessionManagement GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new SessionManagement();
            }
            return _Instance;
        }

        public static bool Exist(string token)
        {
            return UserSessions.SingleOrDefault(s => s.Token.Equals(token)) is not null;
        } 

        public static UserSession? Get(string token)
        {
            UserSession? sessions = UserSessions.SingleOrDefault(s => s.Token.Equals(token));
            return sessions;
        }

        public static UserSession? Get(int userId)
        {
            UserSession? sessions = UserSessions.SingleOrDefault(s => s.User.Id.Equals(userId));

            return sessions;
        }

        public static void Add(UserSession userSession)
        {
            if (userSession is null)
                throw new HttpException("User Session is null", StatusCode.Unauthorized);

            UserSession? session = UserSessions.SingleOrDefault(s => s.Token == userSession.Token);

            if (session is null)
                UserSessions.Add(userSession);
        }

        public static void Remove(string tokenService)
        {
            UserSession? userSession = UserSessions.SingleOrDefault(u => u.Token.Equals(tokenService));

            if (userSession is null)
                throw new ArgumentException("Session does exist");

            UserSessions.Remove(userSession);
        }
    }

    public class UserSession
    {
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime LastActivity { get; set; } = DateTime.Now;
    }
}

