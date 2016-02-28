using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Media;
using Skybrud.Social.Instagram.Objects.Pagination;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses.Locations {
    
    /// <summary>
    /// Class representing the response of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramLocationRecentMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramLocationRecentMediaResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramLocationRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationRecentMediaResponse"/>.</returns>
        public static InstagramLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramLocationRecentMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramLocationRecentMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramLocationRecentMediaResponseBody(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramLocationRecentMediaResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramLocationRecentMediaResponseBody"/>.</returns>
        public static InstagramLocationRecentMediaResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramLocationRecentMediaResponseBody(obj);
        }

        #endregion

    }

}