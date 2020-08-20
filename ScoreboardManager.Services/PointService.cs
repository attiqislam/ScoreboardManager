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
    public class PointService
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
        /// Method to insert a Point in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsInsert(out string errorMessage, PointModel pointModel)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.PointsInsert(pointModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsUpdate(out string errorMessage, PointModel pointModel)
        {
            errorMessage = string.Empty;
            bool result = false;
            try
            {
                result = this.DataAccessManager.PointsUpdate(pointModel);
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get Point of a player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public List<PointViewModel> PointsGet(out string errorMessage, int playerId)
        {
            errorMessage = string.Empty;
            List<PointViewModel> result = new List<PointViewModel>();
            try
            {
                result = this.DataAccessManager.PointsGet(playerId).ToList<PointViewModel>();
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        /// <summary>
        /// Method to get total Points of each player.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<PointViewModel> PointsGetAll(out string errorMessage)
        {
            errorMessage = string.Empty;
            List<PointViewModel> result = new List<PointViewModel>();
            try
            {
                result = this.DataAccessManager.PointsGetAll().ToList<PointViewModel>();
            }
            catch (Exception ex)
            {
                //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
                errorMessage = ErrorMessages.CRITICAL_ERROR;
            }
            return result;
        }

        ///// <summary>
        ///// Method to check whether Point of a player is exist in the table.
        ///// </summary>
        ///// <param name="errorMessage"></param>
        ///// <param name="playerId"></param>
        ///// <returns></returns>
        //public bool IsPointExist(out string errorMessage, int playerId)
        //{
        //    errorMessage = string.Empty;
        //    bool result = false;
        //    try
        //    {
        //        result = this.DataAccessManager.IsPointExist(playerId);
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO : Log the exception somewhere, and pass a simple but specific error message to the users.
        //        errorMessage = ErrorMessages.CRITICAL_ERROR;
        //    }
        //    return result;
        //}

        #endregion
    }
}
