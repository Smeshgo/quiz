using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository
{
    public interface IRepositoryTest
    {
        Task<IQueryable<Test>> GetAllTests();
        Task<List<Test>> GetTestAndQuestion(Guid testId);
        Task<List<Test>> GetTestAndQuestionMany();
        void UpdateUser(Test test);
    }
}
