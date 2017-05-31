using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using BootstrapSite2.Models;

namespace BootstrapSite2.Controllers
{
    public class CompanyAPIController : ApiController
    {
        [HttpGet]
        public string getCompany()
        {
            return "Ok - GET";
        }

        [HttpPost]
        public string postCompany(Company company)
        {
            //Enviando Emails
            sendEmailToClient(company); //Um para o cliente
            sendPrivateEmail(company); // Um para nós

            //TODO: Salvar no banco de dados
            return "Ok - POST";
        }

        //Manda email para o clientess
        private void sendEmailToClient(Company company)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("drmidia@gmail.com");
                mail.To.Add(company.email);
                mail.Subject = "Ranking de Impacto Digital";
                mail.Body = "<h3>Olá, Tudo bem?</h3><br><p>Em breve você receberá informações incríveis que vão mudar sua forma de encarar os negócios digitais, através de comparação com os seus concorrentes e dicas de como melhorar.</p>" +
                    "<br> Equipe Dr Mídia";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("~/Assets/Como_Montar_Seu_Ecommerce-Ebook.pdf"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("drmidia@gmail.com", "gama123456");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }

        //Manda o email interno para nossa equipe
        private void sendPrivateEmail(Company company)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("drmidia@gmail.com");
                mail.To.Add("drmidia@gmail.com");
                mail.Subject = company.fullName;
                mail.Body = "<h2>Novo Cliente! </p> <br/> <p> Nome Completo: " + company.fullName + " <br/>E-mail: " + company.email + " <br/>Nome da Empresa: " + company.companyName + " <br/>Ramo da Empresa: " + company.companyType + "<br/>Tamanho da Empresa: " + company.companySize + " </p>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("drmidia@gmail.com", "gama123456");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }
    }
}
