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
    public partial class PlayerAdd : SecureBasePage
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!base.IsNewRecord)
                {
                    string errorMessage;
                    PlayerViewModel playerViewModel = new PlayerViewModel();
                    playerViewModel = this.GetPlayerByID(out errorMessage, base.RecordID);

                    if (playerViewModel != null)
                    {
                        this.SetData(playerViewModel);
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
                Response.Redirect(UrlConstants.PLAYER_LIST_PAGE_URL);
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

            result = this.DeletePlayer(out message);

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
        /// Method to delete record of a player.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool DeletePlayer(out string message)
        {
            message = "Method was not implemented!";
            return false;
        }

        /// <summary>
        /// Method to reset UI controls.
        /// </summary>
        private void ResetForm()
        {
            base.RecordID = 0;
            this.txtFirstName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        /// <summary>
        /// Method to save data.
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
                PlayerModel playerModel = new PlayerModel();
                playerModel = this.GetData();

                if (!base.IsNewRecord)
                {
                    playerModel.PlayerID = base.RecordID;

                    bool isPlayerInsertSuccessful = facade.PlayersUpdate(out message, playerModel);
                    if (isPlayerInsertSuccessful)
                    {
                        message = OperationMessages.OPERATION_SUCCESSFUL;
                        result = true;
                    }
                }
                else
                {
                    int playerId = facade.PlayersInsert(out message, playerModel);

                    if (playerId > 0)
                    {
                        message = OperationMessages.OPERATION_SUCCESSFUL;
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Method to get input data.
        /// </summary>
        /// <returns></returns>
        private PlayerModel GetData()
        {
            PlayerModel playerModel = new PlayerModel();

            playerModel.FirstName = txtFirstName.Text;
            playerModel.LastName = txtLastName.Text;
            playerModel.Email = txtEmail.Text;

            return playerModel;
        }

        /// <summary>
        /// Method to validate input data.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateData(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (this.txtFirstName.Text.IsNullOrWhiteSpace())
            {
                this.txtFirstName.Focus();
                this.txtFirstName.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.txtLastName.Text.IsNullOrWhiteSpace())
            {
                this.txtLastName.Focus();
                this.txtLastName.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            if (this.txtEmail.Text.IsNullOrWhiteSpace())
            {
                this.txtEmail.Focus();
                this.txtEmail.BorderColor = System.Drawing.Color.Red;
                errorMessage = ErrorMessages.REQUIRED_FILD_IS_MISSING;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to set data of an existing player on UI.
        /// </summary>
        /// <param name="playerViewModel"></param>
        private void SetData(PlayerViewModel playerViewModel)
        {
            txtFirstName.Text = playerViewModel.FirstName;
            txtLastName.Text = playerViewModel.LastName;
            txtEmail.Text = playerViewModel.Email;
        }

        /// <summary>
        /// Method to get record of a player from database.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        private PlayerViewModel GetPlayerByID(out string errorMessage, int playerId)
        {
            Facade facade = new Facade();
            return facade.PlayersGet(out errorMessage, playerId);
        }

        #endregion
    }
}