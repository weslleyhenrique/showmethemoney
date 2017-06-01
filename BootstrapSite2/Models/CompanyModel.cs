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


        //Facebook
        public double LikesFacebook { get; set; }
        public double PostSemanaFacebook { get; set; }
        public double InteracoesPostFacebook { get; set; }
        public double CompartilhamentoFacebook { get; set; }

        //Instagram
        public double SeguidoresInstagram { get; set; }
        public double PostSemanaInstagram { get; set; }
        public double CurtidaPostInstagram { get; set; }
        public double StoriesSemanaInstagram { get; set; }
        public double ViewPorStoryInstagram { get; set; }

        //Linkedin
        public double SeguidoresLinkedin { get; set; }
        public double PostSemanaLinkedin { get; set; }
        public double CurtidaPostLinkedin { get; set; }
        public double ImpressoesPostLinkedin { get; set; }

        //Twitter
        public double SeguidoresTwitter { get; set; }
        public double PorSemanaTwitter { get; set; }

    }
}