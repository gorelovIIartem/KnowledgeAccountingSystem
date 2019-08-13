using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

namespace WebApi.Filters
{
    public class AccessActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (filterContext.ActionArguments["userId"].ToString() != claimsIdentity.FindFirst("Id").Value)
                filterContext.Response = filterContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Forbidden, "Your roots are lowlevel");

            base.OnActionExecuting(filterContext);
        }
    }
}