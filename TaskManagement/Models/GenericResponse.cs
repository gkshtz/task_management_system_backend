namespace TaskManagement.Models
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T? ResponseData { get; set; }
        public string? ResponseMessage { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
