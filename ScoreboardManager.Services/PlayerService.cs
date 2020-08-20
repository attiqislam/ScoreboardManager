using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.DataAccess;
using ScoreboardManager.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Services
{
    public class PlayerService
    {
        #region "Properties"

        /// <summary>
        /// Property to get data access manager object.
        /// </summary>
        private IDataAccessManager DataAccessManager
        {
            get
            {
                return ServiceHelper.GetDataAccessManager();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public int PlayersInsert(out string errorMessage, PlayerModel playerModel)
        {
            errorMessage = string.Empty;
            int result = 0;
            try
            {
                result = this.DataAccessManager.PlayersInsert(playerModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public bool PlayersUpdate(out string errorMessage, PlayerModel playerModel)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.PlayersUpdate(playerModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get record of a player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerViewModel PlayersGet(out string errorMessage, int playerId)
        {
            errorMessage = string.Empty;
            PlayerViewModel result = new PlayerViewModel();
            try
            {
                result = this.DataAccessManager.PlayersGet(playerId);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<PlayerViewModel> PlayersGetAll(out string errorMessage)
        {
            errorMessage = string.Empty;
            List<PlayerViewModel> result = new List<PlayerViewModel>();
            try
            {
                result = this.DataAccessManager.PlayersGetAll().ToList<PlayerViewModel>();
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsPlayerExist(out string errorMessage, string email)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.IsPlayerExist(email);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        #endregion
    }
}
