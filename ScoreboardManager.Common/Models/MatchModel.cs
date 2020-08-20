using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Common.Models
{
    public class MatchModel : BaseModel
    {
        public int MatchID { get; set; }
        public int Primary { get; set; }
        public string MatchName { get; set; }
        public string MatchVenue { get; set; }
        public DateTime MatchDateTime { get; set; }
    }
}
