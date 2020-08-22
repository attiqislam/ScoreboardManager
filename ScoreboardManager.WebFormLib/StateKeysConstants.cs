using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.WebFormLib
{
    public class StateKeysConstants
    {
        public class QueryStringKeys
        {
            public const string RECORD_ID = "rid";
        }

        public class SessionKeys
        {

        }

        public class ViewStateKeys
        {
            public const string RECORD_ID = "__RecordID";
            public const string IS_NEW_RECORD = "__IsNewRecord";
        }

        public class CacheKeys
        {

        }
    }
}
