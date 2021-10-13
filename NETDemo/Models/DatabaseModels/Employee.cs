using System;
using System.Collections.Generic;

#nullable disable

namespace NETDemo.Data.Models.DatabaseModels
{
    public partial class Employee
    {
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public decimal? salary { get; set; }
    }
}
