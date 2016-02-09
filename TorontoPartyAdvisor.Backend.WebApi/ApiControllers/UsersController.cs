using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TorontoPartyAdvisor.Backend.WebApi.Helpers;
using TorontoPartyAdvisor.Commands;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.CommandResults;
using TorontoPartyAdvisor.Commands.Commands;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Backend.WebApi.ApiControllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public SuccessBox LogIn(LogInUserCommandArgs args)
        {
            var cmd = new LogInUserCommand()
            {
                Args = args
            };

            Runner.RunCommand(ref cmd);

            //the request was a success : every scenario is managed we just explain the situation
            return cmd.Result;
        }

        [HttpGet]
        public GetUserInfoCommandResults GetInfo(string accessToken)
        {
            var cmd = new GetUserInfoCommand()
            {
                AccessTokenArgs = accessToken
            };

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }
    }
}