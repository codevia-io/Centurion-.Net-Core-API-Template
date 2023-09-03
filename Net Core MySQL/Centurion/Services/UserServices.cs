using Catch;
using Helpers;
using Models;
using Models.Forms;
using Repository;
using Services.Interfaces;

namespace Services
{
    public class UserServices : ICreateService<Sigin>, IReadServices<User>, IUpdateService<User>, IDeleteService
	{
        private UserRepository _Repository;
		public UserServices()
		{
            _Repository = new UserRepository();
		}

        public void Created(Sigin model)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void Delete(int Id)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public User Find(int Id)
        {
            return AutoMapper.Convert<User>(_Repository.Find(Id));
        }

        public User Find(string userName)
        {
            return AutoMapper.Convert<User>(_Repository.Find(userName));
        }

        public User Find(string key, string value)
        {
            return AutoMapper.Convert<User>(_Repository.Find(key, value));
        }

        public User Find(Dictionary<string, string> pairs)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public List<User> List(int page = 0, int count = 10)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void Update(User model)
        {
            throw new HttpException(StatusCode.NotImplemented);
        }

        public void VerifyPassword(int userId, string password)
        {
            if (password is null)
                throw new ArgumentException("Password is null");

            if (password == string.Empty)
                throw new ArgumentException("Password is emtpy");

            _Repository.VerifyPassword(userId, password);
        }
    }
}

