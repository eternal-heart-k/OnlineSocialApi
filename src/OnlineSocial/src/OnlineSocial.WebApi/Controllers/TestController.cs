using Microsoft.AspNetCore.Mvc;
using OnlineSocial.Foundation;

namespace OnlineSocial.WebApi.Controllers
{
    public class TestController : ApiBaseController
    {
        public TestController()
        {

        }

        [HttpGet("hello")]
        public string GetHello()
        {
            return "hello world";
        }
    }
}