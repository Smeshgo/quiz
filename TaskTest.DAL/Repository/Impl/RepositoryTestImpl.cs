using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TaskTest.DAL.EF;
using TaskTest.DAL.Entities;

namespace TaskTest.DAL.Repository.Impl
{
    public class RepositoryTestImpl : RepositoryBaseImpl<Test>, IRepositoryTest
    {
        public RepositoryTestImpl(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task<IQueryable<Test>> GetAllTests()
            => FindAll().OrderBy(n => n.Name);

        public async Task<List<Test>> GetTestAndQuestion(Guid idTest)
        {

            var result =
                await RepositoryContext.Tests.Where(a => a.TestId == idTest)
                    .Include(q => q.Questions)
                    .ThenInclude(a => a.Answers).ToListAsync();

            return result;
        }
        public async Task<List<Test>> GetTestAndQuestionMany()
        {
            var result =
                await RepositoryContext.Tests
                    .Include(q => q.Questions)
                    .ThenInclude(a => a.Answers).ToListAsync();

            return result;
        }


       
    }
}