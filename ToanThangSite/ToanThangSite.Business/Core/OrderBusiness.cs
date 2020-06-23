using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Entities.Models;
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

        public static string Create(Order Model , List<ProductCart> listpro)
        {
            try
            {
                DBEntities db = new DBEntities();
                Model.ProductName = string.Empty;

                
                db.Orders.Add(Model);
                db.SaveChanges();

                List<ProductOrder> listadd = new List<ProductOrder>();
                foreach (var item in listpro)
                {
                    ProductOrder obj = new ProductOrder();
                    obj.ColorId = Convert.ToInt32(item.colorid);
                    obj.OrderID = Convert.ToInt32(Model.OrderID);
                    obj.ProductId = Convert.ToInt32(item.productId);
                    obj.SizeId = Convert.ToInt32(item.sizeid);
                    listadd.Add(obj);
                }

                db.ProductOrders.AddRange(listadd);
                db.SaveChanges();
                db.Dispose();
                return "true";
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
