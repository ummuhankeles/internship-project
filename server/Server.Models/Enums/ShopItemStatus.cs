namespace Server.Models.Enums
{
    public enum ShopItemStatus : sbyte
    {
        Removed = -1,       // removed from the list
        OnList,             // still on the list, nothing done. (default)
        Approved,           // no need anymore or purchased.
    }
}
