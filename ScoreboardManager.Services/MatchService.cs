using ScoreboardManager.Common.Messages;
using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Services
{
    public class MatchService
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
        /// Method to inset record of a match into database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public int MatchsInsert(out string errorMessage, MatchModel matchModel)
        {
            errorMessage = string.Empty;
            int result = 0;
            try
            {
                result = this.DataAccessManager.MatchsInsert(matchModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public bool MatchsUpdate(out string errorMessage, MatchModel matchModel)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.MatchsUpdate(matchModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchViewModel MatchsGet(out string errorMessage, int matchId)
        {
            errorMessage = string.Empty;
            MatchViewModel result = new MatchViewModel();
            try
            {
                result = this.DataAccessManager.MatchsGet(matchId);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<MatchViewModel> MatchsGetAll(out string errorMessage)
        {
            errorMessage = string.Empty;
            List<MatchViewModel> result = new List<MatchViewModel>();
            try
            {
                result = this.DataAccessManager.MatchsGetAll().ToList<MatchViewModel>();
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchName"></param>
        /// <returns></returns>
        public bool IsMatchExist(out string errorMessage, string matchName)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.IsMatchExist(matchName);
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
