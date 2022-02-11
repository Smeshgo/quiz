using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskTest.DAL.EF;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository.Impl
{
    public class RepositoryUserImpl : RepositoryBaseImpl<User>, IRepositoryUser
    {
        public RepositoryUserImpl(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public IQueryable<User> GetUserByTests()
        {
            var result = RepositoryContext.Users
                .Include(user => user.Test).ThenInclude(tests => tests.Questions)
                .ThenInclude(qustions => qustions.Answers);
            return result;
        }

    }
}