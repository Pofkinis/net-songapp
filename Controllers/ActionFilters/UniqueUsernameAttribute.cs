using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SongsApp.Models;

namespace SongsApp.Controllers.ActionFilters;

public class UniqueUsernameAttribute: ActionFilterAttribute
{
    private readonly DatabaseContext _dbContext;

    public UniqueUsernameAttribute()
    {
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var username = context.HttpContext.Request.Form["username"].ToString();
        var userExists = _dbContext.Users.Any(u => u.Username == username);

        if (userExists)
        {
            context.Result = new BadRequestObjectResult("Username already exists.");
            return;
        }

        base.OnActionExecuting(context);
    }
}