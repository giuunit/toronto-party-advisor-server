using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace TorontoPartyAdvisor.Backend.WebApi.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //TODO: add log here

            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            base.OnException(context);
        }
    }
}