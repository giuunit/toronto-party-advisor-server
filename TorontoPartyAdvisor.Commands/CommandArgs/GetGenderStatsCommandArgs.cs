using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class GetGenderStatsCommandArgs
    {
        public string AccessToken { get; set; }
        public int PlaceId { get; set; }
        public DateTimeOffset Date { get; set; }
        public int MinutesDifference { get; set; }
    }
}
