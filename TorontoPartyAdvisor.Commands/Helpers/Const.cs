using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class Const
    {
        public const string FacebookPictureLink = "https://graph.facebook.com/{0}/picture?type=square";
        public const string FacebookPictureLinkSize = "https://graph.facebook.com/{0}/picture?type=square&height={1}&width={1}";
        
        public const int NewPlaceBonusPoints = 50;
        public const int OldPlaceBonusPoints = 10;

        public const string MaleString = "male";
        public const string FemaleString = "female";
    }
}
