using System.Net;
using Catch;
using Entities;
using Repository.Interfaces;
namespace Repository
{
    public class UserRepository : ICreateRepository<User>, IReadRepository<User>, IUpdateRepository<User>, IDeleteRepository
    {
        public void Created(User entity)
        {
            entity.Created = DateTime.Now;
            using (var context = new DataBaseContexts.DefaultDataBase())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
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
            throw new HttpException(HttpStatusCode.NotImplemented);
        }

        public void Update(User entity)
        {
            throw new HttpException(HttpStatusCode.NotImplemented);
        }
    }
}

