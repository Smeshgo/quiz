using System.Threading.Tasks;

namespace TaskTest.DAL.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryTest Test { get; }
        IRepositoryUser User { get; }
        Task SaveAsync();
    }
}