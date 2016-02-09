using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class GetFacebookPlaceHoursCommandArgs : AbstractCommandArgs
    {
        public string AccessToken { get; set; }
        public string FacebookId { get; set; }
        public DayOfWeek? Day { get; set; }
    }
}
