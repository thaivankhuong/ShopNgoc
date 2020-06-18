using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
   public class OrderBusiness
    {
        public static List<Order> GetAll()
        {
            try
            {
                return OrderServices.GetAll();
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
                return OrderServices.GetByID(ID);
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
                return OrderServices.Create(Model);
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public static bool ChangeStatus(int ID, bool status)
        {
            try
            {
                DBEntities db = new DBEntities();
                Order item = db.Orders.Find(ID);
                item.Status = status;
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
