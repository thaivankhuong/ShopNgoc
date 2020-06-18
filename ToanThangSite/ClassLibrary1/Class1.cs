using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
namespace ClassLibrary1
{
    public class Class1
    {
        public static List<ProductCategory> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();

                List<ProductCategory> Lst = db.ProductCategories.ToList();
              
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
