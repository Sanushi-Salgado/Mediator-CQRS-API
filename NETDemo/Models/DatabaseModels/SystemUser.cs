using System;
using System.Collections.Generic;

#nullable disable

namespace NETDemo.Data.Models.DatabaseModels
{
    public partial class SystemUser
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
