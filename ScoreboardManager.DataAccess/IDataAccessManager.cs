using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;

namespace ScoreboardManager.DataAccess
{
    public interface IDataAccessManager
    {
        #region Players

        /// <summary>
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        int PlayersInsert(PlayerModel playerModel);

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        bool PlayersUpdate(PlayerModel playerModel);

        /// <summary>
        /// Method to get record of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        PlayerViewModel PlayersGet(int playerId);

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <returns></returns>
        IList<PlayerViewModel> PlayersGetAll();

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsPlayerExist(string email);

        #endregion

        #region Matchs

        /// <summary>
        /// Method to inset record of a match into database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        int MatchsInsert(MatchModel matchModel);

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        bool MatchsUpdate(MatchModel matchModel);

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        MatchViewModel MatchsGet(int matchId);

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <returns></returns>
        IList<MatchViewModel> MatchsGetAll();

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="matchName"></param>
        /// <returns></returns>
        bool IsMatchExist(string matchName);

        #endregion

        #region Points

        /// <summary>
        /// Method to insert a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        bool PointsInsert(PointModel pointModel);

        /// <summary>
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        bool PointsUpdate(PointModel pointModel);

        /// <summary>
        /// Method to get Points of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        IList<PointViewModel> PointsGet(int playerId);

        /// <summary>
        /// Method to get total Points of each player.
        /// </summary>
        /// <returns></returns>
        IList<PointViewModel> PointsGetAll();

        ///// <summary>
        ///// Method to check whether Point of a player is exist in the table.
        ///// </summary>
        ///// <param name="playerId"></param>
        ///// <returns></returns>
        //bool IsPointExist(int playerId);

        #endregion
    }
}
