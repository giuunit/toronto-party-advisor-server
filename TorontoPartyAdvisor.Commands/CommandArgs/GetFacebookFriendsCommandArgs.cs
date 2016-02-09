using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class GetFacebookFriendsCommandArgs : AbstractCommandArgs
    {
        public readonly string FacebookAccessToken;
        public readonly string FacebookId;

        public GetFacebookFriendsCommandArgs(string facebookAccessToken, string facebookId)
        {
            FacebookAccessToken = facebookAccessToken;
            FacebookId = facebookId;
        }
    }
}
