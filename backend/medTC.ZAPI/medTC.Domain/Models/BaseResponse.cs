namespace medTC.Domain.Models
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object StatusCode { get; set; }
    }
}
