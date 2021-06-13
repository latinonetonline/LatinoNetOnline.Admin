namespace LatinoNetOnline.Admin.Models
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public ErrorResult Error { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
    }

    public class ErrorResult
    {
        public ErrorResult(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
