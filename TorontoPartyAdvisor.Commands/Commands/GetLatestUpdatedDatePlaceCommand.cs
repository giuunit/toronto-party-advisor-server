using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetLatestUpdatedDatePlaceCommand : AbstractCommand, ICommand
    {
        public DateTimeOffset Result { get; private set; }
        public string AccessTokenArg { get; set; }

        public void Execute()
        {
            using(var db = new PartyAdvisorEntities())
            {
                Result = db.Places.Max(x => x.DateUpdated);
            }
        }
    }
}
