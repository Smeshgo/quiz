using System.Threading.Tasks;
using TaskTest.DAL.EF;

namespace TaskTest.DAL.Repository.Impl
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly ApplicationDbContext _repositoryContext;
        private IRepositoryTest _repositoryTest;
        private IRepositoryUser _repositoryUser;

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

        public IRepositoryUser User
        {
            get
            {
                if (_repositoryUser == null)
                    _repositoryUser = new RepositoryUserImpl(_repositoryContext);
                return _repositoryUser;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}