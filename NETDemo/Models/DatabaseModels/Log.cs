using System;
using System.Collections.Generic;

#nullable disable

namespace NETDemo.Data.Models.DatabaseModels
{
    public partial class Log
    {
        public int log_id { get; set; }
        public int record_id { get; set; }
        public string event_type { get; set; }
        public int user_id { get; set; }
    }
}
