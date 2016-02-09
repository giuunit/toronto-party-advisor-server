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
    public class GetFacebookPlaceHoursCommand : AbstractCommand, ICommand
    {
        public GetFacebookPlaceHoursCommandArgs Args { get; set; }
        public FacebookHoursFormatted Results { get; private set; }

        public void Execute()
        {
            using (var client = new HttpClient())
            {
                var url = FacebookHelper.GenerateGetHoursPlaceRequest(Args.AccessToken, Args.FacebookId);

                var task = client.GetStringAsync(url);

                task.Wait();
                var result = task.Result;

                var fbHours = JsonConvert.DeserializeObject<FacebookHoursBox>(result);

                if (fbHours != null && fbHours.Hours != null)
                {
                    var hours = fbHours.Hours;
                    Results = FormatHelper.FormatFacebookHoursDay(fbHours);
                }    
            }
        }
    }
}
