namespace F1_Fantasy_API.Services
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }

        protected Result(bool success, T? value, string? error)
        {
            IsSuccess = success;
            Error = error;
            Value = value;
        }
        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
}
}
