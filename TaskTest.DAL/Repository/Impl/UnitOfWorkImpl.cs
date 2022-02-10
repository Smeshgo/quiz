using System.Threading.Tasks;
using TaskTest.DAL.EF;

namespace TaskTest.DAL.Repository.Impl
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly ApplicationDbContext _repositoryContext;
        private IRepositoryTest _repositoryTest;
        private IRepositoryUserTest _repositoryUserTest;

        public UnitOfWorkImpl(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IRepositoryTest Test
        {
            get
            {
                if (_repositoryTest == null)
                    _repositoryTest = new RepositoryTestImpl(_repositoryContext);
                return _repositoryTest;
            }
        }
        public IRepositoryUserTest UserTest
        {
            get
            {
                if (_repositoryUserTest == null)
                    _repositoryUserTest = new RepositoryUserTestImpl(_repositoryContext);
                return _repositoryUserTest;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}