using Catch;
using Models;

namespace Session
{
    /// <summary>
    /// This class allow you tu manager session of all users in this single intances
    /// </summary>
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

        /// <summary>
        /// This method allow verify if token exis in one ou more session
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Exist(string token)
        {
            return UserSessions.SingleOrDefault(s => s.Token.Equals(token)) is not null;
        }

        /// <summary>
        /// This method allow get session associate to this token
        /// </summary>
        /// <param name="token">Toke of user</param>
        /// <returns>UserSession</returns>
        public static UserSession? Get(string token)
        {
            UserSession? sessions = UserSessions.SingleOrDefault(s => s.Token.Equals(token));
            return sessions;
        }

        /// <summary>
        /// This method allow get session associate to user id
        /// </summary>
        /// <param name="userId">User if</param>
        /// <returns>UserSession</returns>
        public static UserSession? Get(int userId)
        {
            UserSession? sessions = UserSessions.SingleOrDefault(s => s.User.Id.Equals(userId));

            return sessions;
        }

        /// <summary>
        /// This method allow add new session of a new user connexion
        /// </summary>
        /// <param name="userSession"></param>
        /// <exception cref="HttpException"></exception>
        public static void Add(UserSession userSession)
        {
            if (userSession is null)
                throw new HttpException("User Session is null", StatusCode.Unauthorized);

            UserSession? session = UserSessions.SingleOrDefault(s => s.Token == userSession.Token);

            if (session is null)
                UserSessions.Add(userSession);
        }

        /// <summary>
        /// This method allow to remove a session from a token
        /// </summary>
        /// <param name="tokenService"></param>
        /// <exception cref="ArgumentException"></exception>
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

