using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Extension;
using ScoreboardManager.Common.Enums;


namespace ScoreboardManager.WebFormLib
{
    public class SecureBasePage : System.Web.UI.Page
    {
        #region "Public Properties"

        /// <summary>
        /// Property to set and get the current recordID in/from ViewState.
        /// </summary>
        public int RecordID
        {
            get
            {
                return ViewState[StateKeysConstants.ViewStateKeys.RECORD_ID] != null ? ViewState[StateKeysConstants.ViewStateKeys.RECORD_ID].ToString().ToInt() : -1;
            }
            set
            {
                ViewState[StateKeysConstants.ViewStateKeys.RECORD_ID] = value;
            }
        }

        /// <summary>
        /// Property to identify a new record.
        /// </summary>
        public bool IsNewRecord
        {
            get
            {
                return RecordID == -1;
            }
        }

        #endregion

        #region "Event Handlers"

        /// <summary>
        /// Page on init event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Context.Request.QueryString[StateKeysConstants.QueryStringKeys.RECORD_ID] != null)
            {
                this.RecordID = (Context.Request.QueryString[StateKeysConstants.QueryStringKeys.RECORD_ID]).ToInt();
            }
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Method to show info message on the screen.
        /// If you want to call this js script multiple times at the same time, please pass unique key name for each call.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        public void ShowNotificationDialog(string message, string title, CommonEnums.NotificationTypes type = CommonEnums.NotificationTypes.None, string key = "__notificationMsg")
        {
            if (!message.IsNullOrWhiteSpace())
            {
                string script = ScriptHelper.GetNotificationDialogScript(message, title, type);
                if (!ClientScript.IsStartupScriptRegistered(key))
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, GetType(), key, script, true);
                }
            }
        }

        /// <summary>
        /// Method to show warning message to users.
        /// </summary>
        /// <param name="warningMessage"></param>
        public void ShowWarningNotification(string warningMessage, string key = "__noticeMsg")
        {
            this.ShowNotificationDialog(warningMessage, Common.Messages.NotificationMessages.WARNING_MESSAGE_TITLE, CommonEnums.NotificationTypes.Notice, key);
        }

        /// <summary>
        /// Method to show information to users.
        /// </summary>
        /// <param name="infoMessage"></param>
        public void ShowInfoNotification(string infoMessage, string key = "__infoMsg")
        {
            this.ShowNotificationDialog(infoMessage, Common.Messages.NotificationMessages.WARNING_MESSAGE_TITLE, CommonEnums.NotificationTypes.Notice, key);
        }

        /// <summary>
        /// Method to show success message to users.
        /// </summary>
        /// <param name="successMessage"></param>
        public void ShowSuccessNotification(string successMessage, string key = "__successMsg")
        {
            this.ShowNotificationDialog(successMessage, Common.Messages.NotificationMessages.SUCCESS_MESSAGE_TITLE, CommonEnums.NotificationTypes.Success, key);
        }

        /// <summary>
        /// Method to show error message to users.
        /// </summary>
        /// <param name="errorMessage"></param>
        public void ShowErrorNotification(string errorMessage, string key = "__errorMsg")
        {
            this.ShowNotificationDialog(errorMessage, Common.Messages.NotificationMessages.ERROR_MESSAGE_TITLE, CommonEnums.NotificationTypes.Error, key);
        }

        #endregion
    }
}
