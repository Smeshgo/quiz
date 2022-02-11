using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTest.BLL.DTO.Test;
using TaskTest.DAL.Entities;
using TaskTest.DAL.Repository;

namespace TaskTest.BLL.Service
{
    public class TestServiceImpl : ITestService
    {
        private const int countTest = 3;
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public TestServiceImpl(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TestResponse>> GetAllTests()
        {
            var result = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResponse>>(
                 await _repository.Test.GetAllTests());

            return result;
        }

        public async Task<IEnumerable<TestResponse>> GetTestAndQuestion(Guid testId)
        {
            var result = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResponse>>
                (await _repository.Test.GetTestAndQuestion(testId));
            return result;
        }

        public async Task<IEnumerable<TestResponseMany>> GetTestAndQuestionMany(Guid testId)
        {
            var result = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResponseMany>>
                (await _repository.Test.GetTestAndQuestion(testId));
            return result;
        }

        public async Task SetUserTests(DAL.Entities.User user)
        {

            var tests = await _repository.Test.GetAllTests();

            var dictionaryTestsRandom = RandomTests(tests.ToList());

            foreach (var VARIABLE in dictionaryTestsRandom.Values)
            {
                VARIABLE.User.Add(user);
                _repository.Test.UpdateUser(VARIABLE);

            }
            await _repository.SaveAsync();
        }

        public IQueryable<DAL.Entities.User> GetUserByTests()
        {
            var result = _repository.User.GetUserByTests();
            return result;
        }

        public static Dictionary<int, Test> RandomTests(List<Test> test)
        {
            Dictionary<int, Test> dictionaryTests = new Dictionary<int, Test>();

            Random rnd = new();
            int count = 0;

            while (count < countTest)
            {
                int temp = rnd.Next(test.Count);

                if (!dictionaryTests.Any())
                {
                    dictionaryTests.Add(temp, test[temp]);
                    count++;
                }
                else if (IsUnique(temp, dictionaryTests))
                {
                    dictionaryTests.Add(temp, test[temp]);
                    count++;
                }

            }

            return dictionaryTests;
        }

        private static bool IsUnique(int temp, Dictionary<int, Test> dictionaryTests)
        {
            var isUnique = false;

            foreach (var VARIABLE in dictionaryTests.Keys)
            {
                if (temp != VARIABLE)
                {
                    isUnique = true;
                }
                else
                {
                    return false;
                }
            }

            return isUnique;
        }

    }
}