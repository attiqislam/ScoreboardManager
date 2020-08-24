using ScoreboardManager.Common.Extension;
using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.DataAccess.SqlDataAccessManager
{
    public partial class SqlRepository
    {
        #region Public Methods

        /// <summary>
        /// Method to inset record of a match into database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public int MatchsInsert(MatchModel matchModel)
        {
            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("MatchsInsert", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MatchName", matchModel.MatchName);
                sqlCommand.Parameters.AddWithValue("@MatchVenue", matchModel.MatchVenue);
                sqlCommand.Parameters.AddWithValue("@MatchDateTime", matchModel.MatchDateTime);

                using (sqlCommand)
                {
                    sqlConnection.Open();
                    result = (int)sqlCommand.ExecuteScalar();
                }
            }

            return result;
        }

        /// <summary>
        /// Method to update record of a match in database.
        /// </summary>
        /// <param name="matchModel"></param>
        /// <returns></returns>
        public bool MatchsUpdate(MatchModel matchModel)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("MatchsUpdate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MatchID", matchModel.MatchID);
                sqlCommand.Parameters.AddWithValue("@MatchName", matchModel.MatchName);
                sqlCommand.Parameters.AddWithValue("@MatchVenue", matchModel.MatchVenue);
                sqlCommand.Parameters.AddWithValue("@MatchDateTime", matchModel.MatchDateTime);

                using (sqlCommand)
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteScalar();
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get record of a match.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchViewModel MatchsGet(int matchId)
        {
            MatchViewModel result = new MatchViewModel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("MatchsGet", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MatchID", matchId);

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = dataTable.ToList<MatchViewModel>().FirstOrDefault(m => m.MatchID == matchId);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get record of all match.
        /// </summary>
        /// <returns></returns>
        public IList<MatchViewModel> MatchsGetAll()
        {
            IList<MatchViewModel> result = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("MatchsGetAll", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = dataTable.ToList<MatchViewModel>();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to check whether a match is existing in database or not.
        /// </summary>
        /// <param name="matchName"></param>
        /// <returns></returns>
        public bool IsMatchExist(string matchName)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("IsMatchExist", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MatchName", matchName);

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
