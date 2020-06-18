using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class SliderServices
    {
        public static List<Slider> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Slider> Lst = db.Sliders.ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static Slider GetByID(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Slider Lst = db.Sliders.FirstOrDefault(x => x.SliderID==ID);
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
