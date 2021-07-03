using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs.Request;
using Server.Service.Abstract;

namespace Server.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : BaseController
    {
        private readonly IShopItemService shopItemService;

        public ShopItemController(IShopItemService _shopItemService)
        {
            shopItemService = _shopItemService;
        }

        [HttpPost("{shortURL}")]
        public async Task<IActionResult> Post([FromRoute] string shortURL, [FromBody] ShopItemRequest model)
        {
            return ApiReturn(await shopItemService.InsertAsync(shortURL, model));
        }

        [HttpPatch("{shopItemID}")]
        public async Task<IActionResult> Patch([FromRoute] Guid shopItemID, [FromBody] ShopItemRequest model)
        {
            return ApiReturn(await shopItemService.UpdateAsync(shopItemID, model));
        }
    }
}