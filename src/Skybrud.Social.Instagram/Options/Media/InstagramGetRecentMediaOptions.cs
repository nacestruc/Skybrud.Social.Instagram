using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Time;

namespace Skybrud.Social.Instagram.Options.Media {
    
    /// <summary>
    /// Class representing the search options for getting recent media within a given radius of the location identifier
    /// by the <see cref="Latitude"/> and <see cref="Longitude"/> properties.
    /// </summary>
    /// <see>
    ///     <cref>https://www.instagram.com/developer/endpoints/media/#get_media_search</cref>
    /// </see>
    public class InstagramGetRecentMediaOptions : IGetOptions {
        
        /// <summary>
        /// Gets or sets the latitude of the center search coordinate.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the center search coordinate.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the search distance/radius, specified in meters. Default is <code>1000m</code>, while the max
        /// distance is <code>5000m</code>.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets the minimum timestamp. All media returned will be taken later than this timestamp.
        /// </summary>
        public SocialDateTime MinTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the maximum timestamp. All media returned will be taken earlier than this timestamp.
        /// </summary>
        public SocialDateTime MaxTimestamp { get; set; }

        /// <summary>
        /// Gets an instance of <see cref="SocialQueryString"/> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            
            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Add("lat", Latitude);
            qs.Add("lng", Longitude);

            // Optinal options
            if (Distance > 0) qs.Add("distance", Distance);
            if (MinTimestamp != null) qs.Add("min_timestamp", MinTimestamp.GetUnixTimestamp());
            if (MaxTimestamp != null) qs.Add("max_timestamp", MaxTimestamp.GetUnixTimestamp());

            return qs;

        }
    
    }

}