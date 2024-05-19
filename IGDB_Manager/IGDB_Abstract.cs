using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryCommons.LibraryCommons;

namespace API_Manager
{
    public abstract class IGDB_Abstract : API_INTERFACE
    {
        private readonly string _clientId;
        private readonly string _accessToken;

        /// <summary>
        /// Constructor for IGDB_Abstract. Requires a client ID and an access token.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="accessToken"></param>
        public IGDB_Abstract(string clientId, string accessToken)
        {
            _clientId = clientId;
            _accessToken = accessToken;
        }

        /// <summary>
        /// Accessor method for the client ID.
        /// </summary>
        /// <returns>String representing the client ID.</returns>
        public string getClientId()
        {
            return _clientId;
        }

        /// <summary>
        /// Accessor method for the access token.
        /// </summary>
        /// <returns>String representing the access token.</returns>
        public string getAccessToken()
        {
            return _accessToken;
        }
        /// <summary>
        /// This method fetches a company by its ID.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns> A CompanyIGDB object.</returns>
        public abstract Task<CompanyIGDB> FetchCompanyById(int companyId);
        /// <summary>
        /// This method searches for games by name, given a query.
        /// </summary>
        /// <param name="query">A partial or full name of a game.</param>
        /// <param name="appendID"> A boolean value that determines whether the ID of the game should be appended to the name.</param>
        /// <returns> A string representing the search results.</returns>
        public abstract Task<string> SearchGameNames(string query, bool appendID = false);
        /// <summary>
        /// This
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public abstract Task<Bitmap> GetGameCoverBitmap_byID(int gameId);
        /// <summary>
        /// This method fetches a game cover image by its URL.
        /// </summary>
        /// <param name="imageUrl"> A string representing the URL of the image.</param>
        /// <returns> A Bitmap object representing the game cover image.</returns>
        public abstract Task<Bitmap> GetGameCoverBitmapByUrl(string imageUrl);

        /// <summary>
        /// This method fetches a game by its name.
        /// </summary>
        /// <param name="gameName"> The name of the game to be fetched.</param>
        /// <returns> A GameIGDB object.</returns>
        public abstract Task<GameIGDB> GetGameByName(string gameName);

    }
}
