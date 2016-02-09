using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public sealed class CacheHelper
    {
        private static volatile IEnumerable<Place> _places;
        private static object syncRoot = new Object();

        private CacheHelper() { }

        public static IEnumerable<Place> Places
        {
            get
            {
                if(_places == null)
                {
                    lock(syncRoot)
                    {
                        if (_places == null)
                        {
                            using(var db = new PartyAdvisorEntities())
                            {
                                _places = db.Places.ToList();
                            }
                        }
                    }
                }

                return _places;
            }
        }

        //this function should be executed ONLY when new places are added to the database
        public static void RefreshPlaces()
        {
            lock (syncRoot)
            {
                using (var db = new PartyAdvisorEntities())
                {
                    _places = db.Places.ToList();
                }   
            }
        }
    }
}
