using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetPlacesCommand : AbstractCommand, ICommand
    {
        public GetPlacesCommandArgs Args { get; set; }
        public IEnumerable<PlaceViewModel> Result { get; private set; }

        public void Execute()
        {
            using (var db = new PartyAdvisorEntities())
            {                
                //not authentified user
                if(!db.Users.Any(x => x.FacebookToken == Args.AccessToken))
                {
                    //TODO add some logs here;

                    ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Warn(FormatHelper.FormatCommandToLog(this, Args));


                    Result = new List<PlaceViewModel>();
                    return;
                }

                Result = db.Places.Where(x=>x.Published).OrderBy(x=>x.Order).Select(x => new PlaceViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Address = x.Address,
                    ImagePath = x.ImagePath,
                    FacebookId = x.FacebookId
                }).ToList();
            }
        }
    }
}
