using Server.Models.Enums;

namespace Server.Models
{
    public class ApiResponse
    {
        public ApiResponse(ApiResponseType _type)
        {
            Type = _type;
        }
        public ApiResponse(object _data, ApiResponseType _type)
        {
            Data = _data;
            Type = _type;
        }

        public object Data { get; set; } = null;
        public ApiResponseType Type { get; set; }
    }
}