
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    //for swagger
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
                return new ObjectResult (new ApiResponse(code));
        }

    }
}