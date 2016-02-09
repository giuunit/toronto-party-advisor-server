using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class FindPeopleCommandArgs : AbstractCommandArgs
    {
        public int PlaceId { get; set; }
        public int Minutes { get; set; }

        //check user
        public string AccessToken { get; set; }
    }
}
