using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.DataAccess.EFDataAccessManager
{
    public class EFDataAccessManager : IDataAccessManager
    {
        #region Players

        /// <summary>
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public int PlayersInsert(PlayerModel playerModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public bool PlayersUpdate(PlayerModel playerModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get record of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerViewModel PlayersGet(int playerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <returns></returns>
        public IList<PlayerViewModel> PlayersGetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsPlayerExist(string email)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Matchs

        /// <summary>
        /// Method to inset record of a match into database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public int MatchsInsert(MatchModel matchModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public bool MatchsUpdate(MatchModel matchModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchViewModel MatchsGet(int matchId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <returns></returns>
        public IList<MatchViewModel> MatchsGetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="matchName"></param>
        /// <returns></returns>
        public bool IsMatchExist(string matchName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Points

        /// <summary>
        /// Method to insert a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsInsert(PointModel pointModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsUpdate(PointModel pointModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get Points of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public IList<PointViewModel> PointsGet(int playerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get total Points of each player.
        /// </summary>
        /// <returns></returns>
        public IList<PointViewModel> PointsGetAll()
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// Method to check whether Point of a player is exist in the table.
        ///// </summary>
        ///// <param name="playerId"></param>
        ///// <returns></returns>
        //public bool IsPointExist(int playerId)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
