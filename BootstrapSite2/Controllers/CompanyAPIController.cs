using BootstrapSite2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace BootstrapSite2.Controllers
{
    public class CompanyAPIController : ApiController
    {
        private doutormidiaEntities db = new doutormidiaEntities();


        [HttpGet]
        public string getCompany()
        {
            return "Ok - GET";
        }

        [HttpPost]
        public string postCompany(CompanyModel company)
        {
            //Enviando Emails
            sendEmailToClient(company); //Um para o cliente
            sendPrivateEmail(company); // Um para nós


            Company comp = new Company();
            comp.companyName = company.companyName;
            comp.companySize = company.companySize;
            comp.companyType = company.companyType;
            comp.email = company.email;
            comp.fullName = company.fullName;
            comp.identityId = company.identityId;
            comp.DataRegistro = DateTime.UtcNow.AddHours(-3);
            comp.CompanyGuid = Guid.NewGuid();

            db.Company.Add(comp);


            Facebook face = new Facebook();
            face.NumLikes = company.LikesFacebook;
            face.MediaCompartilhamento = company.CompartilhamentoFacebook;
            face.MediaInteracoesPost = company.InteracoesPostFacebook;
            face.MediaPostSemana = company.PostSemanaFacebook;
            face.UserEmail = company.email;
            face.CompanyGuid = comp.CompanyGuid;

            db.Facebook.Add(face);

            Instagram insta = new Instagram();
            insta.NewSeguidores = company.SeguidoresInstagram;
            insta.MediaCurtidaPost = company.CurtidaPostInstagram;
            insta.MediaPostSemana = company.PostSemanaInstagram;
            insta.MediaViewsStory = company.ViewPorStoryInstagram;
            insta.MediaStoriesSemana = company.StoriesSemanaInstagram;
            insta.UserEmail = company.email;
            insta.CompanyGuid = comp.CompanyGuid;


            db.Instagram.Add(insta);


            Linkedin link = new Linkedin();
            link.MediaCurtidasPost = company.CurtidaPostLinkedin;
            link.MediaImpressoesPost = company.ImpressoesPostLinkedin;
            link.MediaPostSemana = company.PostSemanaLinkedin;
            link.NewSeguidores = company.SeguidoresLinkedin;
            link.UserEmail = company.email;
            link.CompanyGuid = comp.CompanyGuid;


            db.Linkedin.Add(link);


            Twitter tw = new Twitter();
            tw.MediaTweetsSemana = company.PorSemanaTwitter;
            tw.NewSeguidores = company.SeguidoresTwitter;
            tw.UserEmail = company.email;
            tw.CompanyGuid = comp.CompanyGuid;


            db.Twitter.Add(tw);

            db.SaveChanges();
            //TODO: Salvar no banco de dados
            return "Ok - POST";
        }

        //Manda email para o clientess
        private void sendEmailToClient(CompanyModel company)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("contato@doutormidias.com.br");
                mail.To.Add(company.email);
                mail.Subject = "Ranking de Impacto Digital";
                mail.Body = "<h3>Olá, Tudo bem?</h3><br><p> Após a confirmação do pagamento, em breve você " +
                    "receberá informações incríveis que vão mudar sua forma de encarar os negócios digitais," +
                    " através de comparação com os seus concorrentes e dicas de como melhorar.</p>" +
                    "<br> Equipe Dr. Mídia";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("~/Assets/Como_Montar_Seu_Ecommerce-Ebook.pdf"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("contato@doutormidias.com.br", "@gama123456");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }

        //Manda o email interno para nossa equipe
        private void sendPrivateEmail(CompanyModel company)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("contato@doutormidias.com.br");
                mail.To.Add("contato@doutormidias.com.br");
                mail.Subject = "Aguardando confirmação do pagamento - Passo 1: " + company.fullName;
                mail.Body = "<h2>Novo Cliente ! </p> <br/> <p> Nome Completo: " + company.fullName +
                    " <br/>E-mail: " + company.email +
                    " <br/>Nome da Empresa: " + company.companyName +
                    " <br/>Ramo da Empresa: " + company.companyType +
                    " <br/>CPF ou CNPJ: " + company.identityId +
                    "<br/>Tamanho da Empresa: " + company.companySize + " </p>" +
                    " <table> " +
                    "<tr>" +
                    "<td rowspan='4'>Facebook</td>" +
                    "<td>Nº Likes na Fanpage</td>" +
                    "<td>" + company.LikesFacebook + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Posts por semana</td>" +
                    "<td>" + company.PostSemanaFacebook + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de interações nos posts</td>" +
                    "<td>" + company.InteracoesPostFacebook + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Compartilhamento</td>" +
                    "<td>" + company.CompartilhamentoFacebook + "</td>" +
                    "</tr>" +
                    "<hr/>" +
                    "<tr>" +
                    "<td rowspan='5'>Instagram</td>" +
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.SeguidoresInstagram + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Posts por semana</td>" +
                    "<td>" + company.PostSemanaInstagram + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de curtidas por post</td>" +
                    "<td>" + company.CurtidaPostInstagram + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Stories por semana</td>" +
                    "<td>" + company.StoriesSemanaInstagram + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de views por Story</td>" +
                    "<td>" + company.ViewPorStoryInstagram + "</td>" +
                    "</tr>" +
                    "<hr/>" +
                    "<tr>" +
                    "<td rowspan='4'>Linkedin</td>" +
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.SeguidoresLinkedin + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Posts por semana</td>" +
                    "<td>" + company.PostSemanaLinkedin + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de curtidas por post</td>" +
                    "<td>" + company.CurtidaPostLinkedin + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de impressões por post</td>" +
                    "<td>" + company.ImpressoesPostLinkedin + "</td>" +
                    "</tr>" +
                    "<hr/>" +
                    "<tr>" +
                    "<td rowspan='4'>Twitter</td>" +
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.SeguidoresTwitter + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de tweets por semana</td>" +
                    "<td>" + company.PorSemanaTwitter + "</td>" +
                    "</tr>" +
                   
                    "</table>";

                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("contato@doutormidias.com.br", "@gama123456");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }
    }
}
