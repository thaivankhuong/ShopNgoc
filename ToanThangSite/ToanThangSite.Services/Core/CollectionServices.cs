using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;


namespace ToanThangSite.Services.Core
{
    public static class CollectionServices
    {
        public static List<Collection> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Collection> data = db.Collections.ToList();
                db.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static IPagedList<Collection> GetAll(int page, int pageSize)
        {
            try
            {
                DBEntities db = new DBEntities();
                IPagedList<Collection> Lst = db.Collections.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static Collection GetByID(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Collection data = db.Collections.FirstOrDefault(x => x.Id == id);
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
