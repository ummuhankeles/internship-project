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
            switch (response.Type)
            {
                case ApiResponseType.Created:
                    return StatusCode(201);
                case ApiResponseType.Ok:
                    return Ok(response.Data);
                case ApiResponseType.NoContent:
                    return NoContent();
                case ApiResponseType.NotFound:
                    return NotFound("Request processed at end-point but not found any object with identifier which you sent");
                default:
                    return Accepted();
            }
        }
    }
}