using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookHelper
    {
        public static string GenerateLinkToPicture(string facebookId, int? side = null)
        {
            return side.HasValue ? string.Format(Const.FacebookPictureLinkSize, facebookId, side.Value) : string.Format(Const.FacebookPictureLink, facebookId);
        }

        public static string GenerateGetFriendsRequest(string accessToken, string facebookId)
        {
            return string.Format("https://graph.facebook.com/{1}/friends?access_token={0}", accessToken, facebookId);
        }

        public static string GenerateGetEventsRequest(string accessToken, string facebookId, int? limit=null)
        {
            if(limit.HasValue)
                return string.Format("https://graph.facebook.com/v2.4/{1}/events?access_token={0}&limit={2}&fields=name,id,end_time,description,start_time,picture,attending_count,maybe_count", accessToken, facebookId, limit.Value);
            else
                return string.Format("https://graph.facebook.com/v2.4/{1}/events?access_token={0}&fields=name,id,end_time,description,start_time,picture,attending_count,maybe_count", accessToken, facebookId);
        }

        public static string GenerateGetHoursPlaceRequest(string accessToken, string facebookId)
        {
            return string.Format("https://graph.facebook.com/v2.4/{1}?access_token={0}&fields=hours", accessToken, facebookId);
        }
    }
}
