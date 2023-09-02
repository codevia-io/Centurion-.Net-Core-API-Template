using System.Net;
using System.Reflection;
using Catch;
using Entities;
using Helpers;
using Repository.Interfaces;
namespace Repository
{
    public class UserRepository : ICreateRepository<User>, IReadRepository<User>, IUpdateRepository<User>, IDeleteRepository
    {
        public void Created(User entity)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void Delete(int Id)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public User Find(int Id)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public User Find(string userName)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public User Find(string key, string value)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public User Find(Dictionary<string, string> pairs)
        {
            throw new NotImplementedException();
        }

        public List<User> List(int page = 0, int count = 10)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void Update(User entity)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void VerifyPassword(int entityId, string password)
        {
            if (password is null)
                throw new ArgumentException("Password is null");

            if (password == string.Empty)
                throw new ArgumentException("Password is empty");

            User? user = Find(entityId);

            if (PasswordManagement.Compare(password, user.Password) is false)
                throw new HttpException("Password is bad", StatusCode.Unauthorized);
        }
    }
}

