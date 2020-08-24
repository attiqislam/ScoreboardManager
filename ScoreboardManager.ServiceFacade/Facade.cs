using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Services;

namespace ScoreboardManager.ServiceFacade
{
    public class Facade
    {
        #region Players

        /// <summary>
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public int PlayersInsert(out string errorMessage, PlayerModel playerModel)
        {
            PlayerService playerService = new PlayerService();
            return playerService.PlayersInsert(out errorMessage, playerModel);
        }

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public bool PlayersUpdate(out string errorMessage, PlayerModel playerModel)
        {
            PlayerService playerService = new PlayerService();
            return playerService.PlayersUpdate(out errorMessage, playerModel);
        }

        /// <summary>
        /// Method to get record of a player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerViewModel PlayersGet(out string errorMessage, int playerId)
        {
            PlayerService playerService = new PlayerService();
            return playerService.PlayersGet(out errorMessage, playerId);
        }

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<PlayerViewModel> PlayersGetAll(out string errorMessage)
        {
            PlayerService playerService = new PlayerService();
            return playerService.PlayersGetAll(out errorMessage);
        }

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsPlayerExist(out string errorMessage, string email)
        {
            PlayerService playerService = new PlayerService();
            return playerService.IsPlayerExist(out errorMessage, email);
        }

        #endregion

        #region Matchs

        /// <summary>
        /// Method to inset record of a match into database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public int MatchsInsert(out string errorMessage, MatchModel matchModel)
        {
            MatchService matchService = new MatchService();
            return matchService.MatchsInsert(out errorMessage, matchModel);
        }

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public bool MatchsUpdate(out string errorMessage, MatchModel matchModel)
        {
            MatchService matchService = new MatchService();
            return matchService.MatchsUpdate(out errorMessage, matchModel);
        }

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchViewModel MatchsGet(out string errorMessage, int matchId)
        {
            MatchService matchService = new MatchService();
            return matchService.MatchsGet(out errorMessage, matchId);
        }

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<MatchViewModel> MatchsGetAll(out string errorMessage)
        {
            MatchService matchService = new MatchService();
            return matchService.MatchsGetAll(out errorMessage);
        }

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchName"></param>
        /// <returns></returns>
        public bool IsMatchExist(out string errorMessage, string matchName)
        {
            MatchService matchService = new MatchService();
            return matchService.IsMatchExist(out errorMessage, matchName);
        }

        #endregion

        #region Points

        /// <summary>
        /// Method to insert a Point in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsInsert(out string errorMessage, PointModel pointModel)
        {
            PointService Pointservice = new PointService();
            return Pointservice.PointsInsert(out errorMessage, pointModel);
        }

        /// <summary>
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsUpdate(out string errorMessage, PointModel pointModel)
        {
            PointService Pointservice = new PointService();
            return Pointservice.PointsUpdate(out errorMessage, pointModel);
        }

        /// <summary>
        /// Method to get Points of a player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public List<PointViewModel> PointsGet(out string errorMessage, int playerId)
        {
            PointService Pointservice = new PointService();
            return Pointservice.PointsGet(out errorMessage, playerId);
        }

        /// <summary>
        /// Method to get total Points of each player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<PointViewModel> PointsGetAll(out string errorMessage)
        {
            PointService Pointservice = new PointService();
            return Pointservice.PointsGetAll(out errorMessage);
        }

        /// <summary>
        /// Method to check whether Point of a player is exist in the table.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public bool IsPointExist(out string errorMessage, int playerId, int matchId)
        {
            PointService Pointservice = new PointService();
            return Pointservice.IsPointExist(out errorMessage, playerId, matchId);
        }

        #endregion
    }
}
