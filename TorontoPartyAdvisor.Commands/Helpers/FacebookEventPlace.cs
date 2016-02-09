using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookEventPlace
    {
        public readonly FacebookEvent FacebookEvent;
        public readonly int PlaceId;

        public FacebookEventPlace(FacebookEvent facebookEvent, int placeId)
        {
            FacebookEvent = facebookEvent;
            PlaceId = placeId;
        }
    }
}
