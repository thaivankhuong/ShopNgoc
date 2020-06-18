using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using System.Web;
using System.Configuration;
using ToanThangSite.Services.Common;
using System.Web.UI;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ToanThangSite.Services.Core
{
    public class ContactServices
    {
        public static List<Contact> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Contact> Lst = db.Contacts.OrderByDescending(x => x.SendTime).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Contact GetByID(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Contact item = db.Contacts.FirstOrDefault(x => x.ContactID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool Create(Contact Model)
        {
            try
            {
                DBEntities db = new DBEntities();
                Contact item = new Contact();
                item.FullName = Model.FullName;
                item.Email = Model.Email;
                item.Content = Model.Content;
                item.SendTime = DateTime.Now;
                item.Status = 0;
                db.Contacts.Add(item);
                db.SaveChanges();
                db.Dispose();

                string emailTemplateUrl = HttpContext.Current.Server.MapPath("~/Content/EmailTemplate/email.html").ToString();

                Dictionary<string, string> param = new Dictionary<string, string>();

                param.Add("#CustomerName#", item.FullName);
                param.Add("#Address#", "");
                param.Add("#Mobi#", "");
                param.Add("#Email#", item.Email);
                param.Add("#Content#", item.Content);
                param.Add("#TitleMail#", "Thông tin liên hệ từ tomhumalaska.vn");

                StreamReader reader = new StreamReader(emailTemplateUrl);

                string body = reader.ReadToEnd();

                foreach (var i in param)
                {
                    body = body.Replace(i.Key, i.Value);
                }

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                NetworkCredential credential = new NetworkCredential();

                mail.From = new MailAddress(ConfigurationSettings.AppSettings["mail-address"]);
                mail.To.Add(ConfigurationSettings.AppSettings["mail-emailTo"]);
                mail.Subject = string.Format("Thông tin liên hệ từ website tomhumalaska.vn : " + item.FullName);
                mail.Body = body;
                mail.IsBodyHtml = true;

                credential.UserName = ConfigurationSettings.AppSettings["mail-address"];
                credential.Password = ConfigurationSettings.AppSettings["mail-password"];

                smtp.Host = ConfigurationSettings.AppSettings["mail-host"];
                smtp.Port = int.Parse(ConfigurationSettings.AppSettings["mail-port"]);
                smtp.EnableSsl = true;
                smtp.Credentials = credential;

                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
