using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TaskTest.BLL.Service;
using TaskTest.DAL.Entities;

namespace TaskTest.WebUi.Controllers
{
    [Route("api/test")]
    [ApiController]
  //  [Authorize]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly UserManager<User> _userManager;

        public TestController(ITestService testService, UserManager<User> userManager)
        {
            _testService = testService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTest()
        {
            return Ok(await _testService.GetAllTests());
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetTestAndQuestion([FromQuery] Guid testId)
        {
            return Ok(await _testService.GetTestAndQuestion(testId));
        }

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> SetTestToUser()
        {

            var user = await _userManager.GetUserAsync(User);

            await _testService.SetUserTests(user);

            return Ok();
        }

        [HttpGet]
        [Route("GetTest")]
        public async Task<IActionResult> GetTestToUser()
        {
            var user = await _userManager.GetUserAsync(User);
            var emailUser = user.Email;
            var result = _testService.GetUserByTests(emailUser);

            return Ok(result);
        }

    }
}
