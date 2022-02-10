using System.Collections.Generic;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository
{
    public interface IRepositoryUserTest
    {
        void CrateUserTestRange(List<UserTest> userTest);
        void CrateUserTest(UserTest userTest);
    }
}