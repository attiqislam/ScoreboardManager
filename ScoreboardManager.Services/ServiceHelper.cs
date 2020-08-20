using ScoreboardManager.Common.Enums;
using ScoreboardManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Services
{
    internal static class ServiceHelper
    {
        #region "Global Variables"

        private static IDataAccessManager dataAccessManager = null;

        #endregion

        #region "Public Method"

        /// <summary>
        /// Method to decide data access manager type and get it.
        /// </summary>
        /// <returns></returns>
        public static IDataAccessManager GetDataAccessManager()
        {
            if (dataAccessManager == null)
            {
                dataAccessManager =
                    DataAccessFactory.GetDataAccessManager(CommonEnums.DataAccessManagerType.SqlDataAccessManager);
            }
            return dataAccessManager;
        }

        #endregion
    }
}
