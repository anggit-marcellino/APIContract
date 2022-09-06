namespace Common.Models
{
    public class ErrorModel<T>
    {
        public int Status { get; set; }

        public T Messages { get; set; }
    }
}