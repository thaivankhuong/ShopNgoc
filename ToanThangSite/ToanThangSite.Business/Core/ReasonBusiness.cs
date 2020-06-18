using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class ReasonBusiness
    {
        public static List<Reason> GetAll()
        {
            try
            {
                return ReasonServices.GetAll();
            }
            catch (Exception)
            {
                return null;            }
        }

        public static Reason GetByProduct(int productID)
        {
            try
            {
                return ReasonServices.GetByProduct(productID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool Create(Reason model)
        {
            try
            {
                DBEntities db = new DBEntities();
                Reason item = new Reason();
                item.Title = model.Title;
                item.Content = model.Content;
                item.ProductID = model.ProductID;
                db.Reasons.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Edit(Reason model,int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Reason item = db.Reasons.Find(id);
                item.Title = model.Title;
                item.Content = model.Content;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
