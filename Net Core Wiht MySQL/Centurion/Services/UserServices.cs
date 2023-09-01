using Services.Interfaces;
using Models;
using Models.Forms;
using Repository;
using Helpers;
using System.Net;
using Catch;

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
            if (model is null)
                throw new NullReferenceException();

            _Repository.Created(AutoMapper.Convert<Entities.User>(model));
        }

        public void Delete(int Id)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }

        public User Find(int Id)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }

        public User Find(string key, string value)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }

        public User Find(Dictionary<string, string> pairs)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }

        public List<User> List(int page = 0, int count = 10)
        {
            throw new HttpException("The method List of User services is not implemented", HttpStatusCode.NotImplemented);
        }

        public void Update(User model)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }
    }
}

