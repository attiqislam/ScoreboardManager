using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.Common.Models;
using ScoreboardManager.Common.Messages;
using ScoreboardManager.Common.Extension;
using ScoreboardManager.ServiceFacade;
using ScoreboardManager.WebFormLib;

namespace ScoreboardManager.WebForms.AdminPages
{
    public partial class MatchAdd : SecureBasePage
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!base.IsNewRecord)
                {
                    string errorMessage;
                    MatchViewModel matchViewModel = new MatchViewModel();
                    matchViewModel = this.GetMatchByID(out errorMessage, base.RecordID);

                    if (matchViewModel != null)
                    {
                        this.SetData(matchViewModel);
                    }
                }
            }
        }

        #endregion

        #region Control Events

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            string message;

            bool result = this.SaveData(out message);

            if (result)
            {
                base.ShowSuccessNotification(message);
                Response.Redirect(UrlConstants.MATCH_LIST_PAGE_URL);
            }
            else
            {
                base.ShowErrorNotification(message);
            }
        }

        protected void lbtnReset_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            bool result = false;

            result = this.DeleteMatch(out message);

            if (result)
            {
                base.ShowSuccessNotification(message);
            }
            else
            {
                base.ShowErrorNotification(message);
            }
        }



        #endregion

        #region Private Methods

        /// <summary>
        /// Method to delete record of a match.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool DeleteMatch(out string message)
        {
            message = "Method was not implemented!";
            return false;
        }

        /// <summary>
        /// Method to reset UI data.
        /// </summary>
        private void ResetForm()
        {
            txtMatchName.Text = string.Empty;
            txtMatchVenue.Text = string.Empty;
            txtMatchDateTime.Text = string.Empty;
        }

        /// <summary>
        /// Method to save data of a match in database.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool SaveData(out string message)
        {
            bool result = false;
            message = string.Empty;

            if (this.ValidateData(out message))
            {
                Facade facade = new Facade();
                MatchModel matchModel = new MatchModel();
                matchModel = this.GetData();

                if (!base.IsNewRecord)
                {
                    matchModel.MatchID = base.RecordID;

                    bool isMatchUpdateSuccessful = facade.MatchsUpdate(out message, matchModel);
                    if (isMatchUpdateSuccessful)
                    {
                        //TODO : Pass a simple but specific message to the users.
                        message = OperationMessages.OPERATION_SUCCESSFUL;
                        result = true;
                    }
                }
                else
                {
                    int matchId = facade.MatchsInsert(out message, matchModel);

                    if (matchId > 0)
                    {
                        //TODO : Pass a simple but specific message to the users.
                        message = OperationMessages.OPERATION_SUCCESSFUL;
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get data from UI.
        /// </summary>
        /// <returns></returns>
        private MatchModel GetData()
        {
            MatchModel matchModel = new MatchModel();

            matchModel.MatchName = txtMatchName.Text;
            matchModel.MatchVenue = txtMatchVenue.Text;
            matchModel.MatchDateTime = DateTime.Parse(txtMatchDateTime.Text);

            return matchModel;
        }

        /// <summary>
        /// Method to validate UI data.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateData(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (this.txtMatchName.Text.IsNullOrWhiteSpace())
            {
                this.txtMatchName.Focus();
                this.txtMatchName.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.txtMatchVenue.Text.IsNullOrWhiteSpace())
            {
                this.txtMatchVenue.Focus();
                this.txtMatchVenue.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.txtMatchDateTime.Text.IsNullOrWhiteSpace())
            {
                this.txtMatchDateTime.Focus();
                this.txtMatchDateTime.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;

                //TDO: Validate datetime formate as well.
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to set data of an existing match on UI.
        /// </summary>
        /// <param name="matchViewModel"></param>
        private void SetData(MatchViewModel matchViewModel)
        {
            txtMatchName.Text = matchViewModel.MatchName;
            txtMatchVenue.Text = matchViewModel.MatchVenue;
            txtMatchDateTime.Text = matchViewModel.MatchDateTime.ToShortDateString();
        }

        /// <summary>
        /// Method to get record of a match from database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        private MatchViewModel GetMatchByID(out string errorMessage, int matchId)
        {
            Facade facade = new Facade();
            return facade.MatchsGet(out errorMessage, matchId);
        }

        #endregion
    }
}