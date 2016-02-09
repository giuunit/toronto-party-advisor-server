using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandResults;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetUserInfoCommand : AbstractCommand, ICommand
    {
        public string AccessTokenArgs { get; set; }
        public GetUserInfoCommandResults Results { get; private set; }

        public void Execute()
        {
            using (var db = new PartyAdvisorEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.FacebookToken == AccessTokenArgs);
                
                if(user == null)
                {
                    Results = null;
                    return;
                }

                Results = new GetUserInfoCommandResults()
                {
                    FacebookId = user.FacebookId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Points = user.Points,
                    Gender = user.Gender
                };
            }
        }
    }
}
