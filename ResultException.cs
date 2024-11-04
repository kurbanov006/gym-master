using Microsoft.AspNetCore.Mvc;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        ApiResponse<T> apiResponse = result.IsSuccess
            ? ApiResponse<T>.Success(result.Data)
            : ApiResponse<T>.Fail(result.Error);

        return result.Error.ErrorType switch
        {
            ErrorTypes.Conflict => new ConflictObjectResult(apiResponse),
            ErrorTypes.NotFound => new NotFoundObjectResult(apiResponse),
            ErrorTypes.BadRequest => new BadRequestObjectResult(apiResponse),
            ErrorTypes.None => new OkObjectResult(apiResponse),
            _ => new ObjectResult(apiResponse) { StatusCode = 500 }
        };
    }
}