using System.Linq;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository
{
    public interface IRepositoryUser
    {
        IQueryable<User> GetUserByTests();
    }
}