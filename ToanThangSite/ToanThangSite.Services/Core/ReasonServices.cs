using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class ReasonServices
    {
        public static List<Reason> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Reason> Lst = db.Reasons.ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception)
            {
                return null;            }
        }

        public static Reason GetByProduct(int productID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Reason item = db.Reasons.FirstOrDefault(x=>x.ProductID==productID);
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
