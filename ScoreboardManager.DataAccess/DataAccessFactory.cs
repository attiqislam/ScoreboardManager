using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Enums;
using ScoreboardManager.DataAccess;

namespace ScoreboardManager.DataAccess
{
    public class DataAccessFactory
    {
        /// <summary>
        /// Factory method to get appropriate data access manager based on type.
        /// </summary>
        /// <param name="managerType"></param>
        /// <returns></returns>
        public static IDataAccessManager GetDataAccessManager(CommonEnums.DataAccessManagerType managerType)
        {
            IDataAccessManager dataAccessManager = null;
            switch (managerType)
            {
                case CommonEnums.DataAccessManagerType.SqlDataAccessManager:
                    dataAccessManager = new SqlDataAccessManager.SqlDataAccessManager();
                    break;

                case CommonEnums.DataAccessManagerType.EntityFramework:
                    dataAccessManager = new EFDataAccessManager.EFDataAccessManager();
                    break;

                case CommonEnums.DataAccessManagerType.OracleDataAccessManager:
                    dataAccessManager = new OracleDataAccessManager.OracleDataAccessManager();
                    break;
            }

            return dataAccessManager;
        }
    }
}
