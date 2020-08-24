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
        /// Method to insert a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsInsert(PointModel pointModel)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("PointsInsert", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PlayerID", pointModel.PlayerID);
                sqlCommand.Parameters.AddWithValue("@MatchID", pointModel.MatchID);
                sqlCommand.Parameters.AddWithValue("@Point", pointModel.Point);

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
        /// Method to update a Point in database.
        /// </summary>
        /// <param name="pointModel"></param>
        /// <returns></returns>
        public bool PointsUpdate(PointModel pointModel)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("PointsUpdate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PlayerID", pointModel.PlayerID);
                sqlCommand.Parameters.AddWithValue("@MatchID", pointModel.MatchID);
                sqlCommand.Parameters.AddWithValue("@Point", pointModel.Point);

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
            IList<PointViewModel> result = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PointsGetAll", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = dataTable.ToList<PointViewModel>();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to check whether Point of a player is exist in the table.
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public bool IsPointExist(int playerId, int matchId)
        {
           bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("IsPointExist", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@PlayerID", playerId);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@MatchID", matchId);

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
