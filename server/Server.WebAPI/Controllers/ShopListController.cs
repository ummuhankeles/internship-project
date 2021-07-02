using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs.Request;
using Server.Service.Abstract;

namespace Server.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopListController : ControllerBase
    {
        private readonly IShopListService shopListService;

        public ShopListController(IShopListService _shopListService)
        {
            shopListService = _shopListService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateList(ShopListRequest model)
        {
            var result = await shopListService.InsertAsync(model);
            //todo: get result as a response class
            return result != null ? Ok(result) : BadRequest("");
        }

    }
}