using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TorontoPartyAdvisor.Backend.WebApi.ApiControllers
{
    //used to test elmah tracking
    public class ErrorController : ApiController
    {
        [HttpGet]
        public void Index()
        {
            throw new Exception("Test elmah");
        }
    }
}
