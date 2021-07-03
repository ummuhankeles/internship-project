using System.ComponentModel.DataAnnotations;
using Server.Models.Enums;

namespace Server.Models.DTOs.Request
{
    public class ShopItemRequest
    {
        [Required]
        public string Name { get; set; }
        public string Definition { get; set; }
        public ShopItemStatus Status { get; set; }
    }
}