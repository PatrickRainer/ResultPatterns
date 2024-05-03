namespace Results;

public class Result<TData> : IResult<TData> where TData : class
{
    public bool Success { get; set; }
    public Exception? Exception { get; set; }
    public ICollection<string> ErrorMessages { get; set; } = new List<string>();
    public TData? Data { get; set; }

    private Result()
    {
        
    }

    public static Result<TData> CreateSuccessResult(TData? data = null)
    {
        var result = new Result<TData>
        {
            Success = true,
            Data = data
        };

        return result;
    }

    public static Result<TData> CreateErrorResult(Exception? exception = null, List<string>? errors = null)
    {
        var result = new Result<TData>
        {
            Success = false,
            Exception = exception
        };
        if (errors is not null) result.ErrorMessages = errors;

        return result;
    }
    
    public static Result<TData> CreateErrorResult(Exception? exception = null, string? error = null)
    {
        var result = new Result<TData>
        {
            Success = false,
            Exception = exception
        };
        if (error is not null) result.ErrorMessages.Add(error);

        return result;
    }
}