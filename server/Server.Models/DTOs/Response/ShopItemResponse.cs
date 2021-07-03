using System;
using Server.Models.Enums;

namespace Server.Models.DTOs.Response
{
    public class ShopItemResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public ShopItemStatus Status { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}