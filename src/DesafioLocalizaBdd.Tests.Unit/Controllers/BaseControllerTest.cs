using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Tests.Unit.Controller
{
    public class BaseControllerTest
    {
        protected T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }
    }
}
