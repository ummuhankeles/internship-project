using AutoMapper;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;

namespace Server.WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopItemRequest, ShopItem>();
            CreateMap<ShopListRequest, ShopList>();

            CreateMap<ShopList, ShopListResponse>();
            CreateMap<ShopItem, ShopItemResponse>();
        }
    }
}