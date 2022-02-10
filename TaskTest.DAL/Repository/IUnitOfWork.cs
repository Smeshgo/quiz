using System.Threading.Tasks;

namespace TaskTest.DAL.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryTest Test { get; }
        IRepositoryUserTest UserTest { get; }
        Task SaveAsync();
    }
}