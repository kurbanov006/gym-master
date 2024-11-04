public sealed record Error
{
    public int? Code { get; set; }
    public string? Message { get; set; }
    public ErrorTypes ErrorType { get; set; }

    public Error()
    {
        Code = 500;
        Message = "Server Error!";
        ErrorType = ErrorTypes.InternalServerError;
    }

    private Error(int? code, string? message, ErrorTypes errorType)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }

    public static Error None()
    => new Error(null, null, ErrorTypes.None);

    public static Error NotFound(string? message = "Data not found ...")
    => new Error(404, message, ErrorTypes.NotFound);

    public static Error BadRequest(string? message = "Bad Request ...")
    => new Error(400, message, ErrorTypes.BadRequest);

    public static Error Conflict(string? message = "Conflict ...")
    => new Error(409, message, ErrorTypes.Conflict);

    public static Error InternalServerError(string? message = "Internal server error ...")
    => new Error(500, message, ErrorTypes.InternalServerError);
}