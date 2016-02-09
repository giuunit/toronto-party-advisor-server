using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;
using System.Net.Http;

namespace TorontoPartyAdvisor.Commands.Commands
{
    /// <summary>
    /// to get the names and id of facebook friends
    /// </summary>
    public class GetFacebookFriendsCommand : AbstractCommand, ICommand
    {
        public GetFacebookFriendsCommandArgs Args { get; set; }
        public List<FacebookFriend> Result { get; set; }

        public GetFacebookFriendsCommand()
        {
            Result = new List<FacebookFriend>();
        }

        public void Execute()
        {
            using (var client = new HttpClient())
            {
                var link = FacebookHelper.GenerateGetFriendsRequest(Args.FacebookAccessToken, Args.FacebookId);

                var task = client.GetStringAsync(link);

                task.Wait();
                var result = task.Result;
                var mapping = JsonConvert.DeserializeObject<FacebookFriends>(result);
                Result = mapping.Data;

            }
        }
    }
}
