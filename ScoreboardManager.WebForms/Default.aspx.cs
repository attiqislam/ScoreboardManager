using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.ServiceFacade;

namespace ScoreboardManager.WebForms
{
    public partial class _Default : Page
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

        #endregion

        #region Private Methods

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