using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetFacebookEventsCommand : AbstractCommand, ICommand
    {
        public GetFacebookEventsCommandArgs Args { get; set; }
        public FacebookEvents Results { get; private set; }

        public void Execute()
        {
            using (var client = new HttpClient())
            {
                var link = FacebookHelper.GenerateGetEventsRequest(Args.FacebookAccessToken, Args.FacebookId, Args.Limit);

                var task = client.GetStringAsync(link);

                task.Wait();
                var result = task.Result;

                var jsonResults = JsonConvert.DeserializeObject<FacebookEvents>(result);

                if(jsonResults !=null && jsonResults.Items != null)
                {
                    Results = new FacebookEvents()
                    {
                        Items = jsonResults.Items.OrderBy(x => x.StartTime).Where(x => x.EndTime > DateTimeOffset.Now).ToList()
                    };
                }
            }
        }
    }
}
