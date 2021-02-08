using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Results;

namespace NewsWebsiteAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> ExecuteAction<TResult, TResponse>(
            Func<Task<TResult>> action,
            Func<TResult, TResponse> dataMethod)
            where TResult : Result
        {
            var result = await action();

            var response = dataMethod(result);

            IActionResult actionResult = result.Status switch
            {
                ResponseStatus.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError),
                ResponseStatus.Success => Ok(response),
                ResponseStatus.BadRequest => BadRequest(response),
                ResponseStatus.Conflict => Conflict(response),
                ResponseStatus.NoContent => NoContent(),
                ResponseStatus.NotFound => NotFound(),
                ResponseStatus.Unauthorized => Unauthorized(response),
                ResponseStatus.Accepted => Accepted(response),
                ResponseStatus.PartialContent => StatusCode(StatusCodes.Status206PartialContent, response),
                ResponseStatus.Forbidden => Forbid(),
                ResponseStatus.Created => StatusCode(StatusCodes.Status201Created, response),
                ResponseStatus.TooManyRequests => StatusCode(StatusCodes.Status429TooManyRequests),
                _ => throw new ArgumentOutOfRangeException(
                    $"{result.Status}",
                    "Should be a valid HTTP Status Code")
            };

            return actionResult;
        }

        protected Task<IActionResult> ExecuteAction<TResult>(Func<Task<TResult>> action)
            where TResult : Result
            => ExecuteAction(action, data => data.Message);
    }
}