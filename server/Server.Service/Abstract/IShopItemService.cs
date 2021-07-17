using System;
using System.Threading.Tasks;
using Server.Models;
using Server.Models.DTOs.Request;
using Server.Models.Entities;

namespace Server.Service.Abstract
{
    public interface IShopItemService
    {
        Task<ApiResponse> InsertAsync(string shortURL, ShopItemRequest value);
        Task<ApiResponse> UpdateAsync(Guid id, ShopItemRequest value);
        Task<ShopItem> GetById(Guid shopItemID);
    }
}