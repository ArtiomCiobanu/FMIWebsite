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
        protected async Task<ActionResult<TResponse>> ExecuteAction<TResult, TResponse>(
            Func<Task<TResult>> action,
            Func<TResult, TResponse> dataMethod)
            where TResult : BaseResult
        {
            var result = await action();

            var response = dataMethod(result);

            ActionResult<TResponse> actionResult = result.Status switch
            {
                ResponseStatus.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, response),
                ResponseStatus.Success => Ok(response),
                ResponseStatus.BadRequest => BadRequest(response),
                ResponseStatus.Conflict => Conflict(response),
                ResponseStatus.NoContent => StatusCode(StatusCodes.Status204NoContent, response),
                ResponseStatus.NotFound => NotFound(response),
                ResponseStatus.Unauthorized => Unauthorized(response),
                ResponseStatus.Accepted => Accepted(response),
                ResponseStatus.PartialContent => StatusCode(StatusCodes.Status206PartialContent, response),
                ResponseStatus.Forbidden => StatusCode(StatusCodes.Status403Forbidden, response),
                ResponseStatus.Created => StatusCode(StatusCodes.Status201Created, response),
                ResponseStatus.TooManyRequests => StatusCode(StatusCodes.Status429TooManyRequests),
                _ => throw new ArgumentOutOfRangeException(
                    $"{result.Status}",
                    "Should be a valid HTTP Status Code")
            };

            return actionResult;
        }

        protected Task<ActionResult<string>> ExecuteAction<TResult>(Func<Task<TResult>> action)
            where TResult : BaseResult
            => ExecuteAction(action, data => data.Message);
    }
}