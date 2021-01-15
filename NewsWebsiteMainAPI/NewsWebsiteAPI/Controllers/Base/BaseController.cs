using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Results;

namespace NewsWebsiteAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ExecuteAction(Func<IResult> action)
        {
            var result = action();

            IActionResult response = result.Status switch
            {
                ResponseStatus.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError),
                ResponseStatus.Success => Ok(result),
                ResponseStatus.BadRequest => BadRequest(result),
                ResponseStatus.Conflict => Conflict(result),
                ResponseStatus.NoContent => NoContent(),
                ResponseStatus.NotFound => NotFound(),
                ResponseStatus.Unauthorized => Unauthorized(result),
                ResponseStatus.Created => StatusCode(StatusCodes.Status201Created, result),
                ResponseStatus.Accepted => Accepted(result),
                ResponseStatus.PartialContent => StatusCode(StatusCodes.Status206PartialContent, result),
                ResponseStatus.Forbidden => Forbid(),
                ResponseStatus.TooManyRequests => StatusCode(StatusCodes.Status429TooManyRequests),
                _ => throw new ArgumentOutOfRangeException()
            };

            return response;
        }
    }
}