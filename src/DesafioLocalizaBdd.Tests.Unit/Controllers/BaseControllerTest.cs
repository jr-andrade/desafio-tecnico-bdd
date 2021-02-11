using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Tests.Unit.Controllers
{
    public class BaseControllerTest
    {
        protected T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }

        protected T GetCreatedObject<T>(IActionResult result)
        {
            var createdResult = (CreatedResult)result;
            return (T)createdResult.Value;
        }
    }
}
