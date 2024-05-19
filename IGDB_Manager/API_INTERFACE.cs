using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommons;

namespace API_Manager
{
    public interface API_INTERFACE
    {
        /// <summary>
        /// This method should fetch a game by its ID.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<CompanyIGDB> FetchCompanyById(int companyId);

        /// <summary>
        /// This method should fetch a game by its name.
        /// </summary>
        /// <param name="gameName"> The name of the game to be fetched.</param>
        /// <returns> A GameIGDB object.</returns>
        Task<GameIGDB> GetGameByName(string gameName);

        /// <summary>
        /// This method should fetch a game's cover image by its URL.
        /// </summary>
        /// <param name="imageUrl"> The URL of the game's cover image.</param>
        /// <returns> A Bitmap object representing the game's cover image.</returns>
        Task<Bitmap> GetGameCoverBitmapByUrl(string imageUrl);

        /// <summary>
        /// This method should fetch a game's cover image by its ID.
        /// </summary>
        /// <param name="gameId">Game ID</param>
        /// <returns> A Bitmap object representing the game's cover image.</returns>
        Task<Bitmap> GetGameCoverBitmap_byID(int gameId);

        /// <summary>
        /// This method should search for games by name, given a query.
        /// </summary>
        /// <param name="query"> A partial or full name of a game.</param>
        /// <param name="appendID"> A boolean value that determines whether the ID of the game should be appended to the name.</param>
        /// <returns> A string representing the search results.</returns>
        Task<string> SearchGameNames(string query, bool appendID = false);
    }
}
