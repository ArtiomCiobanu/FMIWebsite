using System;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Results;

namespace NewsWebsiteAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        /*public IActionResult ExecuteAction(
            Func<ResultBase> action,
            Func<ResultBase, IActionResult> successResult,
            Func<ResultBase, IActionResult> failResult)
        {
            var result = action();

            return result.Succeeded ? successResult(result) : failResult(result);
        }*/
    }
}