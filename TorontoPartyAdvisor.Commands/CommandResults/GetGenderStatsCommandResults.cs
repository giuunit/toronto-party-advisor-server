using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandResults
{
    public class GetGenderStatsCommandResults
    {
        public int MaleUsers { get; set; }
        public int FemaleUsers { get; set; }
        public int MinutesRequest { get; set; }
    }
}
