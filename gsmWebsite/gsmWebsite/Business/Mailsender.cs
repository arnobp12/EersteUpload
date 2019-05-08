using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace gsmWebsite.Business
{
    public class Mailsender
    {
        //private variables
        
       
       
        

        //public variables
        public string Naam { get; set; }
        public string Mail { get; set; }
        public string Onderwerp { get; set; }
        public string Boodschap { get; set; }
        public string MailAdres { get; set; }
      

        //method
        public string StuurMail()
        {
            //try
            {
                //SMTP-client aanmaken en configureren
                SmtpClient mijnSMTP = new SmtpClient();
                mijnSMTP.Host = "smtp-mail.outlook.com";
                mijnSMTP.Port = 587;
                mijnSMTP.EnableSsl = true;
                mijnSMTP.Credentials = new System.Net.NetworkCredential("zesitnkcst@outlook.com", "Test123456");

                //Mailbericht aanmaken en configureren
                //From werkt in C# niet zoals je zou verwachten (de ontvanger blijft het eigen adres als verzender zien).
                //Wil je toch het mailadres kennen van de verzender, voorzie dan een tekstvak en plak het aan het bericht zelf vast.
                MailMessage mijnMail = new MailMessage("zesitnkcst@outlook.com", "zesitnkcst@outlook.com");
                mijnMail.Subject =Onderwerp;
                mijnMail.Body = "Van: " + Mail + " (" + Naam + ")" + Environment.NewLine + Boodschap;

                //Mailbericht versturen via SMTP-client
                mijnSMTP.Send(mijnMail);

                return "Mail succesvol verzonden.";
            }
        }
}