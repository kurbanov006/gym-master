public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public Error Error { get; set; }
    public T? Data { get; set; }
    private ApiResponse(bool isSuccess, Error error, T? data)
    {
        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }
    public static ApiResponse<T> Success(T? data) => new ApiResponse<T>(true, Error.None(), data);

    public static ApiResponse<T> Fail(Error error) => new ApiResponse<T>(false, error, default);

}