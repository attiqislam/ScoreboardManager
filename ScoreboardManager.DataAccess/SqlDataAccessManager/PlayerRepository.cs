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
        /// Method to insert record of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public int PlayersInsert(PlayerModel playerModel)
        {
            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("PlayersInsert", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", playerModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", playerModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", playerModel.Email);

                using (sqlCommand)
                {
                    sqlConnection.Open();
                    result = (int)sqlCommand.ExecuteScalar();
                }
            }

            return result;
        }

        /// <summary>
        /// Method to update recorde of a player in database.
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public bool PlayersUpdate(PlayerModel playerModel)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("PlayersUpdate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PlayerID", playerModel.PlayerID);
                sqlCommand.Parameters.AddWithValue("@FirstName", playerModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", playerModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", playerModel.Email);

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
        /// Method to get record of a player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerViewModel PlayersGet(int playerId)
        {
            PlayerViewModel result = new PlayerViewModel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PlayersGet", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@PlayerID", playerId);

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = dataTable.ToList<PlayerViewModel>().FirstOrDefault(p => p.PlayerID == playerId);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get record of all players.
        /// </summary>
        /// <returns></returns>
        public IList<PlayerViewModel> PlayersGetAll()
        {
            IList<PlayerViewModel> result = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("PlayersGetAll", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result = dataTable.ToList<PlayerViewModel>();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to check whether a player is already exist or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsPlayerExist(string email)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("IsPlayerExist", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Email", email);

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
