using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapSite2.Models
{
    public class Company
    {
        public int companyId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public string companyType { get; set; }
        public string companySize { get; set; }
    }
}