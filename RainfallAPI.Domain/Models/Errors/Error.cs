namespace RainfallAPI.Domain.Models.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public IList<ErrorDetail> Detail { get; set; }
    }
}
