﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookFriends
    {
        public Paging Paging { get; set; }
        public List<FacebookFriend> Data { get; set; }
    }
}
