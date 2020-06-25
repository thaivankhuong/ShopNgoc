using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ToanThangSite.Entities.Core;
using ToanThangSite.Entities.Models;

namespace ToanThangSite.Services.Core
{
    public class OrderServices
    {
        public static List<Order> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Order> Lst = db.Orders.OrderByDescending(x => x.SendTime).Where(x=>x.Status==true).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Order GetByID(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Order item = db.Orders.FirstOrDefault(x => x.OrderID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string Create(Order Model)
        {
            try
            {
                DBEntities db = new DBEntities();
                Order item = new Order();
                item.FullName = Model.FullName;
                item.Address = Model.Address;
                item.Mobi = Model.Mobi;
                item.ProductName = Model.ProductName;
                item.Email = Model.Email;
                item.Content = Model.Content;
                item.SendTime = DateTime.Now;
                item.Status = true;
                db.Orders.Add(item);
                db.SaveChanges();
                db.Dispose();

                string emailTemplateUrl = HttpContext.Current.Server.MapPath("~/Content/EmailTemplate/email.html").ToString();

                Dictionary<string, string> param = new Dictionary<string, string>();

                param.Add("#CustomerName#", item.FullName);
                param.Add("#Address#", item.Address);
                param.Add("#Mobi#", item.Mobi);
                param.Add("#Email#", item.Email);
                param.Add("#Content#", item.Content);
                param.Add("#Product#", item.ProductName);
                param.Add("#TitleMail#", "Đây là thông tin đơn hàng : ");

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
                mail.Subject = string.Format("Thông tin thanh toán từ website thaoduoctoanthang.com : " + item.FullName);
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
                    return ex.ToString();
                }

                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public static List<ProductOrderModel> GetProductByOrderId(int orderId)
        {
            try
            {
                DBEntities db = new DBEntities();
                var list = from od in db.Orders.AsQueryable()
                           join pd in db.ProductOrders.AsQueryable() on od.OrderID equals pd.OrderID
                           join p in db.Products.AsQueryable() on pd.ProductId equals p.ProductID
                           join pc in db.ProductColors.AsQueryable() on pd.ColorId equals pc.Id
                           join ps in db.ProductSizes.AsQueryable() on pd.SizeId equals ps.Id
                           where od.OrderID  == orderId
                           select new ProductOrderModel
                           {
                               CustommerName = od.FullName ,
                               Avatar =  p.Avatar,
                               Color = pc.Name, 
                               Size = ps.Name,
                               NameProduct = p.Title,
                               PriceSale  = p.PriceSale,
                               Quantity = pd.Quantity , 
                               Price = p.Price  
                           } ;
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
