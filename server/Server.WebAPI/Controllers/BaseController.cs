using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Enums;

namespace Server.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult ApiReturn(ApiResponse response)
        {
            return response.Type switch
            {
                ApiResponseType.Ok              => Ok(new { response.Data }),
                ApiResponseType.NotFound        => NotFound("Request processed at end-point but not found any object with identifier which you sent"),
                ApiResponseType.NoContent       => NoContent(),
                ApiResponseType.Created         => StatusCode(201),
                _                               => Accepted()
            };
        }
    }
}