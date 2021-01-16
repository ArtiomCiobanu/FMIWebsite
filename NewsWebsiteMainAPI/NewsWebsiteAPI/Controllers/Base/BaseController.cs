using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Results;

namespace NewsWebsiteAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ExecuteAction<TResult, TResponse>(
            Func<TResult> action,
            Func<TResult, TResponse> dataMethod)
            where TResult : IResult
        {
            var result = action();

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
                _ => throw new ArgumentOutOfRangeException()
            };

            return actionResult;
        }

        protected IActionResult ExecuteAction<TResult>(Func<TResult> action)
            where TResult : IResult
            => ExecuteAction(action, data => data);
    }
}