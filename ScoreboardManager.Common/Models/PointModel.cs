using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Common.Models
{
    public class PointModel : BaseModel
    {
        public int PlayerID { get; set; }
        public int MatchID { get; set; }
        public int Point { get; set; }
    }
}
