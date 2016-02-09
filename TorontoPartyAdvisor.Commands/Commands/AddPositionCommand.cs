using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.CommandResults;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class AddPositionCommand : AbstractCommand, ICommand
    {
        public AddPositionCommandArgs Args { get; set; }
        public AddPositionCommandResults Results { get; private set; }

        public void Execute()
        {
            using(var db = new PartyAdvisorEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.FacebookToken == Args.AccessToken);

                //user unauthentified
                if(user == null)
                {
                    //TODO add some logs here

                    ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    
                    logger.Warn(FormatHelper.FormatCommandToLog(this, Args));

                    return;
                }

                //authentified user here
                var position = new Position()
                {
                    Latitude = Args.Latitude,
                    Longitude = Args.Longitude,
                    UserId = user.Id,
                    Date = DateTimeOffset.Now
                };

                //we add the position
                db.Entry(position).State = System.Data.Entity.EntityState.Added;


                //we look at related places related to this position
                var places = db.Places.Where(x=>x.Published).ToList();
                PositionPlace positionPlaceEntry = null;

                foreach(var place in places)
                {
                    var mathPosition = new MathPosition(place.Latitude, place.Longitude);
                    var isInDaPlace = mathPosition.HasPositionInItsRadius(new MathPosition(position.Latitude, position.Longitude), place.RadiusMeters);

                    if(isInDaPlace)
                    {
                        positionPlaceEntry = new PositionPlace()
                        {
                            PlaceId = place.Id,
                            PositionId = position.Id
                        };

                        db.Entry(positionPlaceEntry).State = System.Data.Entity.EntityState.Added;

                        break;
                    }
                }

                db.SaveChanges();

                //this position matched a place
                if(positionPlaceEntry != null)
                {
                    int points = 0;

                    var oldPositionPlaces = db.PositionPlaces
                        //search by user
                        .Where(x => x.Position.UserId == user.Id
                            //search by place (first time at this place)
                        && x.PlaceId == positionPlaceEntry.PlaceId
                            //we ignore the newly created record
                        && x.Id != positionPlaceEntry.Id).ToList();

                    //TODO: later this must be optimized instead of getting every match

                    //we check if we have matches of this user at this position
                    if(oldPositionPlaces.Any())

                    //not the first time
                    {
                        //did the user wait long enough to get new points ?
                        var timeOkOldPositionPlaces = 
                            //no match sooner than now - minutes
                            !oldPositionPlaces.Any(x => x.Position.Date > positionPlaceEntry.Position.Date.AddMinutes(- Args.MinutesBetweenMatches));

                        if(timeOkOldPositionPlaces)
                        {
                            points = Const.OldPlaceBonusPoints;
                        }
                        //user sent position at the same bar not long time enough
                        else
                        {
                            //nothing, points = 0
                            Results = new AddPositionCommandResults()
                            {
                                BonusPoint = 0
                            };
                        }
                    }
                    //new position
                    else
                    {
                        points = Const.NewPlaceBonusPoints;
                    }

                    Results = new AddPositionCommandResults()
                    {
                        BonusPoint = points
                    };

                    if(points < 0)
                    {
                        user.Points += points;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();
                    }
                }

                else
                {
                    //nothing, points = 0
                    Results = new AddPositionCommandResults()
                    {
                        BonusPoint = 0
                    };
                }
            }
        }
    }
}
