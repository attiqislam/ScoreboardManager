using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScoreboardManager.ServiceFacade;
using ScoreboardManager.Common.ViewModels;

namespace ScoreboardManager.WebApiV2.Controllers
{
    public class PlayerController : BaseController
    {
        [Route("Players/GetAll")]
        public List<PlayerViewModel> PostPlayersGet()
        {
            string errorMessage = string.Empty;
            Facade facade = new Facade();
            return facade.PlayersGetAll(out errorMessage);
        }
    }
}
