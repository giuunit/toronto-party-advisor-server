using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class MathPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public MathPosition()
        {

        }

        public MathPosition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool HasPositionInItsRadius(MathPosition obj, int radiusMeters)
        {
            return this.Distance(obj) <= radiusMeters;
        }

        /// <summary>
        /// http://www.geodatasource.com/developers/c-sharp
        /// </summary>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <returns>Distance in meters</returns>
        public double Distance(double lat, double lon)
        {
            double theta = Longitude - lon;
            double dist = Math.Sin(GeometryHelper.DegreeToRadian(Latitude)) * Math.Sin(GeometryHelper.DegreeToRadian(lat)) + Math.Cos(GeometryHelper.DegreeToRadian(Latitude)) * Math.Cos(GeometryHelper.DegreeToRadian(lat)) * Math.Cos(GeometryHelper.DegreeToRadian(theta));
            dist = Math.Acos(dist);
            dist = GeometryHelper.RadianToDegree(dist);
            dist = dist * 60 * 1.1515;

            //meters by default
            dist = dist * 1.609344 * 1000;

            return (dist);
        }

        public double Distance(MathPosition obj)
        {
            return Distance(obj.Latitude, obj.Longitude);
        }
    }
}
