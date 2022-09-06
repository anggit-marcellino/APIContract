namespace Common.Models
{
    public class ResultModel<T>
    {
        public int Status { get; set; }

        public T Data { get; set; }
    }
}
