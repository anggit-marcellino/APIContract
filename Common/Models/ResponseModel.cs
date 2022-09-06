namespace Common.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }

        public ResultModel<T> Results { get; set; }

        public ErrorModel<T> Error { get; set; }
    }
}