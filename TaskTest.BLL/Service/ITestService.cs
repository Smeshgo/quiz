using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTest.BLL.DTO.Test;
using TaskTest.DAL.Entities;


namespace TaskTest.BLL.Service
{
    public interface ITestService
    {
        Task<IEnumerable<TestResponse>> GetAllTests();
        Task<IEnumerable<TestResponse>> GetTestAndQuestion(Guid testId);
        Task<IEnumerable<TestResponseMany>> GetTestAndQuestionMany(Guid testId);
        Task SetUserTests(DAL.Entities.User user);
    }
}
