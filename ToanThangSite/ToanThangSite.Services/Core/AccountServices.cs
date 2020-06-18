using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class AccountServices
    {
        public static bool Login(string username, string password)
        {
            try
            {
                
                DBEntities db = new DBEntities();
                Account item = db.Accounts.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
                if (item == null)
                {
                    return false;
                }
                db.Dispose();
                return true;
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
                DBEntities db = new DBEntities();
                Account item = db.Accounts.FirstOrDefault(x=>x.Username==UserName);
                db.Dispose();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
