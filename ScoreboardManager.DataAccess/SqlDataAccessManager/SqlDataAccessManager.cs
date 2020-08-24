using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;

namespace ScoreboardManager.DataAccess.SqlDataAccessManager
{
    public class SqlDataAccessManager : IDataAccessManager
    {
        #region "Global Variable"

        private SqlRepository repository = null;

        #endregion

        #region "Private Properties"

        private SqlRepository Repository
        {
            get { return repository ?? (repository = new SqlRepository()); }
        }

        #endregion

        #region "Constructor"

        public SqlDataAccessManager()
        {

        }

        #endregion

        #region Public Methods

        #region Players

        /// <summary>
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public int PlayersInsert(PlayerModel playerModel)
        {
            return this.Repository.PlayersInsert(playerModel);
        }

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public bool PlayersUpdate(PlayerModel playerModel)
        {
            return this.Repository.PlayersUpdate(playerModel);
        }

        /// <summary>
        /// Method to get record of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerViewModel PlayersGet(int playerId)
        {
            return this.Repository.PlayersGet(playerId);
        }

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <returns></returns>
        public IList<PlayerViewModel> PlayersGetAll()
        {
            return this.Repository.PlayersGetAll();
        }

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsPlayerExist(string email)
        {
            return this.Repository.IsPlayerExist(email);
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
            return this.Repository.MatchsInsert(matchModel);
        }

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public bool MatchsUpdate(MatchModel matchModel)
        {
            return this.Repository.MatchsUpdate(matchModel);
        }

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchViewModel MatchsGet(int matchId)
        {
            return this.Repository.MatchsGet(matchId);
        }

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <returns></returns>
        public IList<MatchViewModel> MatchsGetAll()
        {
            return this.Repository.MatchsGetAll();
        }

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="matchName"></param>
        /// <returns></returns>
        public bool IsMatchExist(string matchName)
        {
            return this.Repository.IsMatchExist(matchName);
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
            return this.Repository.PointsInsert(pointModel);
        }

        /// <summary>
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsUpdate(PointModel pointModel)
        {
            return this.Repository.PointsUpdate(pointModel);
        }

        /// <summary>
        /// Method to get Points of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public IList<PointViewModel> PointsGet(int playerId)
        {
            return this.Repository.PointsGet(playerId);
        }

        /// <summary>
        /// Method to get total Points of each player.
        /// </summary>
        /// <returns></returns>
        public IList<PointViewModel> PointsGetAll()
        {
            return this.Repository.PointsGetAll();
        }

        /// <summary>
        /// Method to check whether Point of a player is exist in the table.
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public bool IsPointExist(int playerId, int matchId)
        {
            return this.Repository.IsPointExist(playerId, matchId);
        }

        #endregion

        #endregion
    }
}
