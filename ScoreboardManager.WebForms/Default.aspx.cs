using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.ServiceFacade;
using ScoreboardManager.WebFormLib;
using ScoreboardManager.Common.Messages;
using ScoreboardManager.Common.Extension;
using ScoreboardManager.Common.Models;

namespace ScoreboardManager.WebForms
{
    public partial class _Default : SecureBasePage
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorMessage;

                List<PointViewModel> lstPoints = this.GetPoints(out errorMessage);

                List<PointViewModel> lstSortedScoreboardData = this.GetSortedScoreboardData(out errorMessage, "TotalPoints", "DESC", lstPoints);

                LoadScoreboardData(lstSortedScoreboardData);

                List<PlayerViewModel> lstPlayers = this.GetPlayers(out errorMessage);
                this.LoadPlayers(lstPlayers);

                List<MatchViewModel> lstMatchs = this.GetMatchs(out errorMessage);
                this.LoadMatchs(lstMatchs);
            }
        }


        #endregion

        #region Control's Events

        protected void gvScoreboard_Sorting(object sender, GridViewSortEventArgs e)
        {
            string errorMessage;

            string currentSortDirection = gvScoreboard.Attributes["CurrentSortDirection"];

            List<PointViewModel> lstPoints = this.GetPoints(out errorMessage);

            List<PointViewModel> lstSortedScoreboardData = this.GetSortedScoreboardData(out errorMessage, e.SortExpression, currentSortDirection, lstPoints);

            LoadScoreboardData(lstSortedScoreboardData);

            this.ChangeCurrentSortDirection(currentSortDirection);
        }

        protected void gvScoreboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

        protected void lbtnAddPoint_Click(object sender, EventArgs e)
        {
            string message;
            bool result = this.SaveData(out message);

            if (result)
            {
                base.ShowSuccessNotification(message);
                this.ResetInputFields();

                List<PointViewModel> lstPoints = this.GetPoints(out message);
                List<PointViewModel> lstSortedScoreboardData = this.GetSortedScoreboardData(out message, "TotalPoints", "DESC", lstPoints);
                LoadScoreboardData(lstSortedScoreboardData);
            }
            else
            {
                base.ShowErrorNotification(message);
            }
        }



        #endregion

        #region Private Methods

        /// <summary>
        /// Method to reset the values of input fields.
        /// </summary>
        private void ResetInputFields()
        {
            ddlPlayers.SelectedIndex = 0;
            ddlMatchs.SelectedIndex = 0;
            txtNewPoint.Text = string.Empty;
        }

        /// <summary>
        /// Method to insert new point for a player in database.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool SaveData(out string message)
        {
            bool result = false;
            message = string.Empty;
            Facade facade = new Facade();

            if (this.ValidateData(out message))
            {
                if (!this.IsPointExist(out message, ddlPlayers.SelectedValue.ToInt(), ddlMatchs.SelectedValue.ToInt()))
                {
                    PointModel pointModel = this.GetPointData();

                    result = facade.PointsInsert(out message, pointModel);

                    if (result)
                    {
                        message = OperationMessages.OPERATION_SUCCESSFUL;
                    }
                }
                else
                {
                    message = ErrorMessages.POINT_IS_EXISTING;
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get point data from UI.
        /// </summary>
        /// <returns></returns>
        private PointModel GetPointData()
        {
            PointModel pointModel = new PointModel();

            pointModel.PlayerID = ddlPlayers.SelectedValue.ToInt();
            pointModel.MatchID = ddlMatchs.SelectedValue.ToInt();
            pointModel.Point = txtNewPoint.Text.ToInt();

            return pointModel;
        }

        /// <summary>
        /// Method to check whether Point of a particular match of a player is exist in the table.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="playerId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        private bool IsPointExist(out string message, int playerId, int matchId)
        {
            Facade facade = new Facade();
            return facade.IsPointExist(out message, playerId, matchId);
        }

        /// <summary>
        /// Method to validate required input data.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateData(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (this.ddlPlayers.SelectedIndex <= 0)
            {
                this.ddlPlayers.Focus();
                this.ddlPlayers.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.ddlMatchs.SelectedIndex <= 0)
            {
                this.ddlMatchs.Focus();
                this.ddlMatchs.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.txtNewPoint.Text.IsNullOrWhiteSpace())
            {
                this.txtNewPoint.Focus();
                this.txtNewPoint.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to load matchs in dropdown.
        /// </summary>
        /// <param name="lstMatchs"></param>
        private void LoadMatchs(List<MatchViewModel> lstMatchs)
        {
            ddlMatchs.DataSource = lstMatchs;
            ddlMatchs.DataValueField = "MatchID";
            ddlMatchs.DataTextField = "MatchName";
            ddlMatchs.DataBind();

            ddlMatchs.Items.Insert(0, new ListItem("---- Select Match -----", "-1"));
        }

        /// <summary>
        /// Method to get all matchs from database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private List<MatchViewModel> GetMatchs(out string errorMessage)
        {
            Facade facade = new Facade();
            return facade.MatchsGetAll(out errorMessage);
        }

        /// <summary>
        /// Method to load players in dropdown.
        /// </summary>
        /// <param name="lstPlayers"></param>
        private void LoadPlayers(List<PlayerViewModel> lstPlayers)
        {
            ddlPlayers.DataSource = lstPlayers;
            ddlPlayers.DataTextField = "LastName";
            ddlPlayers.DataValueField = "PlayerID";
            ddlPlayers.DataBind();

            ddlPlayers.Items.Insert(0, new ListItem("---- Select Player -----", "-1"));

        }

        /// <summary>
        /// Method to get all the players from database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private List<PlayerViewModel> GetPlayers(out string errorMessage)
        {
            Facade facade = new Facade();
            return facade.PlayersGetAll(out errorMessage);
        }

        /// <summary>
        /// Method to change current sort direction.
        /// </summary>
        /// <param name="currentSortDirection"></param>
        private void ChangeCurrentSortDirection(string currentSortDirection)
        {
            if (currentSortDirection == "DESC")
            {
                gvScoreboard.Attributes["CurrentSortDirection"] = "ASC";
            }
            else
            {
                gvScoreboard.Attributes["CurrentSortDirection"] = "DESC";
            }
        }

        /// <summary>
        /// Method to get sorted scoreboard data.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="sortDirection"></param>
        /// <param name="lstPoints"></param>
        /// <returns></returns>
        private List<PointViewModel> GetSortedScoreboardData(out string errorMessage, string sortExpression, string currentSortDirection, List<PointViewModel> lstPoints)
        {
            errorMessage = string.Empty;
            List<PointViewModel> lstSortedPoints = new List<PointViewModel>();

            switch (sortExpression)
            {
                case "FirstName":

                    lstSortedPoints = this.SortScoreboardByFirstName(currentSortDirection, lstPoints);
                    break;

                case "LastName":

                    lstSortedPoints = this.SortScoreboardByLastName(currentSortDirection, lstPoints);
                    break;

                case "TotalPoints":

                    lstSortedPoints = this.SortScoreboardByTotalPoints(currentSortDirection, lstPoints);
                    break;

                default:
                    break;
            }

            return lstSortedPoints;
        }

        /// <summary>
        /// Method to sort scoreboard data by total points of players.
        /// </summary>
        /// <param name="currentSortDirection"></param>
        /// <param name="lstPoints"></param>
        /// <returns></returns>
        private List<PointViewModel> SortScoreboardByTotalPoints(string currentSortDirection, List<PointViewModel> lstPoints)
        {
            List<PointViewModel> lstSortedPoints = new List<PointViewModel>();

            switch (currentSortDirection)
            {
                case "ASC":
                    lstSortedPoints = lstPoints.OrderBy(p => p.TotalPoints).ToList<PointViewModel>();
                    break;
                case "DESC":
                    lstSortedPoints = lstPoints.OrderByDescending(p => p.TotalPoints).ToList<PointViewModel>();
                    break;
                default:
                    lstSortedPoints = lstPoints.OrderByDescending(p => p.TotalPoints).ToList<PointViewModel>();
                    break;
            }

            return lstSortedPoints;
        }

        /// <summary>
        /// Method to sort scoreboard data by last name.
        /// </summary>
        /// <param name="currentSortDirection"></param>
        /// <param name="lstPoints"></param>
        /// <returns></returns>
        private List<PointViewModel> SortScoreboardByLastName(string currentSortDirection, List<PointViewModel> lstPoints)
        {
            List<PointViewModel> lstSortedPoints = new List<PointViewModel>();

            switch (currentSortDirection)
            {
                case "ASC":
                    lstSortedPoints = lstPoints.OrderBy(p => p.LastName).ToList<PointViewModel>();
                    break;
                case "DESC":
                    lstSortedPoints = lstPoints.OrderByDescending(p => p.LastName).ToList<PointViewModel>();
                    break;
                default:
                    lstSortedPoints = lstPoints.OrderBy(p => p.LastName).ToList<PointViewModel>();
                    break;
            }

            return lstSortedPoints;
        }

        /// <summary>
        /// Method to sort scoreboard data by first name.
        /// </summary>
        /// <param name="currentSortDirection"></param>
        /// <param name="lstPoints"></param>
        /// <returns></returns>
        private List<PointViewModel> SortScoreboardByFirstName(string currentSortDirection, List<PointViewModel> lstPoints)
        {
            List<PointViewModel> lstSortedPoints = new List<PointViewModel>();

            switch (currentSortDirection)
            {
                case "ASC":
                    lstSortedPoints = lstPoints.OrderBy(p => p.FirstName).ToList<PointViewModel>();
                    break;
                case "DESC":
                    lstSortedPoints = lstPoints.OrderByDescending(p => p.FirstName).ToList<PointViewModel>();
                    break;
                default:
                    lstSortedPoints = lstPoints.OrderBy(p => p.FirstName).ToList<PointViewModel>();
                    break;
            }

            return lstSortedPoints;
        }

        /// <summary>
        /// Method to load scoreboard data.
        /// </summary>
        /// <param name="lstPoints"></param>
        private void LoadScoreboardData(List<PointViewModel> lstPoints)
        {
            gvScoreboard.DataSource = lstPoints;
            gvScoreboard.DataBind();
        }

        /// <summary>
        /// Method to get points of all players.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private List<PointViewModel> GetPoints(out string errorMessage)
        {
            Facade facade = new Facade();
            return facade.PointsGetAll(out errorMessage);
        }

        #endregion


    }
}