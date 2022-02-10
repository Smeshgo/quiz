using System;
using System.Collections.Generic;
using TaskTest.DAL.EF;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository.Impl
{
    public class RepositoryUserTestImpl : RepositoryBaseImpl<UserTest>, IRepositoryUserTest
    {
        public RepositoryUserTestImpl(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }
        
       

        public void CrateUserTestRange(List<UserTest> userTest)
        {
            CreateRange(userTest);
        }
        public void CrateUserTest(UserTest userTest)
        {
            Create(userTest);
        }




    }
}