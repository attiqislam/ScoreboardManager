using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScoreboardManager.ServiceFacade;
using ScoreboardManager.Common.ViewModels;

namespace ScoreboardManager.WebForms.AdminPages
{
    public partial class PlayerList : System.Web.UI.Page
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorMessage = string.Empty;
                List<PlayerViewModel> lstPlayers = new List<PlayerViewModel>();

                Facade facade = new Facade();
                lstPlayers = facade.PlayersGetAll(out errorMessage);

                if (lstPlayers != null && lstPlayers.Count > 0)
                {
                    this.LoadPlayers(lstPlayers);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to load players on UI.
        /// </summary>
        /// <param name="lstPlayers"></param>
        private void LoadPlayers(List<PlayerViewModel> lstPlayers)
        {
            rptPlayers.DataSource = lstPlayers;
            rptPlayers.DataBind();
        }

        #endregion
    }
}