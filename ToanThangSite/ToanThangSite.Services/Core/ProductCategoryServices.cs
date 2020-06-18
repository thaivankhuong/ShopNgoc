using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class ProductCategoryServices    
    {
        public static List<ProductCategory> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List< ProductCategory> Lst= db.ProductCategories.ToList();
                db.Dispose();
               
               
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static ProductCategory GetByID(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                ProductCategory item = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
