using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class FindPeopleCommand : AbstractCommand, ICommand
    {
        public FindPeopleCommandArgs Args { get; set; }
        public IEnumerable<SearchUserViewModel> Results { get; private set; }

        public void Execute()
        {
            List<int> userIds = new List<int>();

            using (var db = new PartyAdvisorEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.FacebookToken == Args.AccessToken);

                //request from an unauthentified user
                if(user == null)
                {
                    //TODO insert log here

                    ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Warn(FormatHelper.FormatCommandToLog(this, Args));


                    Results = new List<SearchUserViewModel>();
                    return;
                }
                
                var place = db.Places.Find(Args.PlaceId);

                var placePosition = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(place.Latitude, place.Longitude);

                //filter by time
                var userPositions = db.Positions.Where(x => DbFunctions.AddMinutes(x.Date, -(Args.Minutes)) > DateTimeOffset.Now).ToList();

                //filter by distance
                foreach(var userPosition in userPositions)
                {
                    var userMathPosition = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(userPosition.Latitude, userPosition.Longitude);
                    if (placePosition.HasPositionInItsRadius(userMathPosition, place.RadiusMeters))
                    {
                        if (!userIds.Contains(userPosition.UserId))
                        {
                            userIds.Add(userPosition.UserId);
                        }
                    }
                }

                //we get the list of id of users at the place, now we get more infos

                var res = (from x in userIds
                           join y in db.Users on x equals y.Id
                           select new SearchUserViewModel() 
                           {
                               Id = y.Id,
                               Gender = y.Gender
                           }).ToList();

                Results = res;
                return;
            }
        }
    }
}
