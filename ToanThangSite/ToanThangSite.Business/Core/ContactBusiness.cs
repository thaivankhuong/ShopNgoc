using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class ContactBusiness
    {
        public static List<Contact> GetAll()
        {
            try
            {
                return ContactServices.GetAll();
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
                return ContactServices.GetByID(ID);
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
                return ContactServices.Create(Model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Contact item = db.Contacts.Find(ID);
                db.Contacts.Remove(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
