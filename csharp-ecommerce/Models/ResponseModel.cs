namespace csharp_ecommerce.Models
{
    public class ResponseModel<T>
    {
        public T Value { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }   
    }
}
