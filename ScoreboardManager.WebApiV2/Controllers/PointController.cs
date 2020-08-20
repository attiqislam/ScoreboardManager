using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScoreboardManager.Common.ViewModels;
using ScoreboardManager.ServiceFacade;

namespace ScoreboardManager.WebApiV2.Controllers
{
    public class PointController : BaseController
    {
        [Route("Points/GetAll")]
        public List<PointViewModel> PostPointsGet()
        {
            string errorMessage = string.Empty;
            Facade facade = new Facade();
            return facade.PointsGetAll(out errorMessage);
        }
    }
}
