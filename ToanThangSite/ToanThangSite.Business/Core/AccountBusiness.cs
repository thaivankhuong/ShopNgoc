using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;
using ToanThangSite.Business.Common;

namespace ToanThangSite.Business.Core
{
    public class AccountBusiness
    {
        public static bool Login(string username, string password)
        {
            try
            {
                string Pass = SecurityUtility.MD5Encrypt(password, "@3#24#");
                return AccountServices.Login(username, Pass);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Account GetByID(string UserName)
        {
            try
            {
                return AccountServices.GetByID(UserName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static bool ChangePassword(string UserName, string Password)
        {
            try
            {
                DBEntities db = new DBEntities();
                Account item = db.Accounts.FirstOrDefault(x=>x.Username==UserName);
                item.Password = SecurityUtility.MD5Encrypt(Password, "@3#24#");
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
