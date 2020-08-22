using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Enums;

namespace ScoreboardManager.WebFormLib
{
    public class ScriptHelper
    {
        #region "Public Methods"

        /// <summary>
        /// Method to get script to show notification in front end.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetNotificationDialogScript(string message, string title, CommonEnums.NotificationTypes type = CommonEnums.NotificationTypes.None)
        {
            string script = String.Format(ScriptResources.SHOW_NOTIFICATION_DIALOG_SCRIPT, message, title, type.ToString());
            return ScriptWithDocumentReadyFunction(script);
        }

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Method to get script with document ready function of JQuery.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        private static string ScriptWithDocumentReadyFunction(string script)
        {
            return "$(function(){" + script + "});";

        }

        #endregion
    }
}
