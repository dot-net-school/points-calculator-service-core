using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared;

namespace API.Filters;

public class ValidateModelStateAttribute :ActionFilterAttribute
{
    //TODO ask me why we choose this name fo it?
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();

            var responseObj = OperationResult<int>
                .Failed(string.Join(", ", errors), HttpStatusCode.BadRequest);

            context.Result = new JsonResult(responseObj)
            {
                StatusCode = 400
            };
        }
    }
}