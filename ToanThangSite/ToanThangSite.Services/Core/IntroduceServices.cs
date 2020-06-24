using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class IntroduceServices
    {
        public static List<Introduce> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Introduce> data = db.Introduces.Where(x=>x.Status==1).ToList();
                db.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Introduce GetTop1()
        {
            try
            {
                DBEntities db = new DBEntities();
                Introduce data = db.Introduces.FirstOrDefault(x => x.Status == 1);
                db.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Introduce> GetTop3()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Introduce>  data = db.Introduces.Where(x => x.Status == 1).Take(3).ToList();
                db.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Introduce GetByID(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Introduce data = db.Introduces.FirstOrDefault(x=>x.IntroduceID==id);
                db.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
