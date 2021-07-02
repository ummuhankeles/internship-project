using System;
using System.Threading.Tasks;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;

namespace Server.Service.Abstract
{
    public interface IShopListService
    {
        Task<ShopListResponse> InsertAsync(ShopListRequest value);
        Task<bool> UpdateAsync(ShopListRequest value);
        Task<ShopListResponse> GetById(Guid id);
        Task<ShopListResponse> GetWithAllItemsById(Guid id);
    }
}