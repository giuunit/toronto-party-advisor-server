﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class GetPlacesCommandArgs : AbstractCommandArgs
    {
        public string AccessToken { get; set; }
    }
}