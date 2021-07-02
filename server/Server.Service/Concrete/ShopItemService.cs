using System;
using System.Threading.Tasks;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;
using Server.Service.Abstract;

namespace Server.Service.Concrete
{
    public class ShopItemService : IShopItemService
    {
        public Task<ShopItemResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(ShopItemRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ShopItemRequest item)
        {
            throw new NotImplementedException();
        }
    }
}