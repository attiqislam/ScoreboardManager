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
    public partial class MatchList : System.Web.UI.Page
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorMessage = string.Empty;
                List<MatchViewModel> lstMatchs = new List<MatchViewModel>();

                Facade facade = new Facade();
                lstMatchs = facade.MatchsGetAll(out errorMessage);

                if (lstMatchs != null && lstMatchs.Count > 0)
                {
                    this.LoadMatchs(lstMatchs);
                }
            }
        }

        #endregion

        #region Private Methods

        private void LoadMatchs(List<MatchViewModel> lstMatchs)
        {
            rptMatchs.DataSource = lstMatchs;
            rptMatchs.DataBind();
        }

        #endregion
    }
}