using System;
using System.Threading.Tasks;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;

namespace Server.Service.Abstract
{
    public interface IShopItemService
    {
        Task<bool> InsertAsync(ShopItemRequest item);
        Task<bool> UpdateAsync(ShopItemRequest item);
        Task<ShopItemResponse> GetById(Guid id);
    }
}