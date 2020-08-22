using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Common.Enums
{
    public class CommonEnums
    {
        public enum DataAccessManagerType
        {
            SqlDataAccessManager = 1,
            EntityFramework = 2,
            OracleDataAccessManager = 3
        }

        public enum NotificationTypes
        {
            None = 1,
            Notice = 2,
            Info = 3,
            Success = 4,
            Error = 5
        }
    }
}
