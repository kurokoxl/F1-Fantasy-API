namespace F1_Fantasy_API.Models.Responses
{
    public class ApiResponse<T>

    {

        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

    }
}
