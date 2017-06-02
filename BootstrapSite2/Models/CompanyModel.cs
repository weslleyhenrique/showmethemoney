using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapSite2.Models
{
    public class CompanyModel
    {
        public int companyId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public string companyType { get; set; }
        public string companySize { get; set; }
        public string identityId { get; set; }
        public string Plan { get; set; }


        //Facebook
        public string Facebook { get; set; }

        //Instagram
        public string Instagram { get; set; }

        //Linkedin
        public string Linkedin { get; set; }

        //Twitter
        public string Twitter { get; set; }

    }
}