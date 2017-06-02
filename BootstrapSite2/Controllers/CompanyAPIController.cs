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
            comp.Facebook = company.Facebook;
            comp.Instagram = company.Instagram;
            comp.Linkedin = company.Linkedin;
            comp.Twitter = company.Twitter;
            comp.DataRegistro = DateTime.UtcNow.AddHours(-3);
            comp.CompanyGuid = Guid.NewGuid();

            db.Company.Add(comp);


          
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
                    "<td>" + company.Facebook + "</td>" +
                   
                    "<td rowspan='5'>Instagram</td>" +
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.Instagram + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.Linkedin + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td>Média de Posts por semana</td>" +
                   
                    "<td rowspan='4'>Twitter</td>" +
                    "<td>Nº Seguidores</td>" +
                    "<td>" + company.Twitter + "</td>" +
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
