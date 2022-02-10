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

            List<UserTest> result = new();

            foreach (var VARIABLE in dictionaryTestsRandom.Values)
            {
                UserTest userTest = new(user, VARIABLE);
                //UserTest userTest = new(user, dictionaryTestsRandom.Values.First());
                _repository.UserTest.CrateUserTest(userTest);

            }

            //for (int i = 0; i < testsRandom.Result.Count; i++)
            //{
            //    UserTest userTest = new(user, testsRandom.Result[i]);
            //    result.Add(userTest);
            //}
            await _repository.SaveAsync();


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