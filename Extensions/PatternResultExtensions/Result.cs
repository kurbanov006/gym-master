public class Result<T>
{
    public bool IsSuccess { get; init; }
    public Error Error { get; init; }
    public T? Data { get; set; }
    private Result(bool isSuccess, Error error, T? data)
    {
        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }
    public static Result<T> Success(T? data)
    => new Result<T>(true, Error.None(), data);

    public static Result<T> Fail(Error error)
    => new Result<T>(false, error, default);
}