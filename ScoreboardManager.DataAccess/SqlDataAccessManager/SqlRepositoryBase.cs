using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ScoreboardManager.Common.Extension;
using ScoreboardManager.Common.Messages;

namespace ScoreboardManager.DataAccess.SqlDataAccessManager
{
    public abstract class SqlRepositoryBase
    {
        #region "Global Variables"

        private string connectionString = string.Empty;

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or Sets Connection string of database.
        /// </summary>
        protected string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }
        #endregion

        #region "Constructor"

        protected SqlRepositoryBase()
        {
            this.ConnectionString = ConfigurationManager.AppSettings["sqlConnectionString"].ToString();
            if (this.ConnectionString.IsNullOrEmpty())
            {
                throw new Exception(ErrorMessages.CONNECTION_STRING_NOT_FOUND);
            }
        }
        #endregion
    }
}
