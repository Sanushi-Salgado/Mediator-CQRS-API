using System;
using System.Collections.Generic;

#nullable disable

namespace NETDemo.Data.Models.DatabaseModels
{
    public partial class Customer
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country_code { get; set; }
        public string contact_no { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
