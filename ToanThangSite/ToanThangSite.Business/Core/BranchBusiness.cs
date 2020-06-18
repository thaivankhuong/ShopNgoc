using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
   public class BranchBusiness
    {
        public static List<Branch> GetAll()
        {
            try
            {
                return   BranchServices.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Branch> GetListID(string[] ID)
        {
            try
            {
                return BranchServices.GetListID(ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Branch GetByID(int ID)
        {
            try
            {
                return BranchServices.GetByID(ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool Create(Branch model)
        {
            try
            {
                DBEntities db = new DBEntities();
                Branch item = new Branch();
                item.Address = model.Address;
                item.Map = model.Map;
                item.Mobi = model.Mobi;
                item.Title = model.Title;
                item.Status = model.Status;
                db.Branches.Add(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Update(Branch model, int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Branch item = db.Branches.Find(ID);
                item.Address = model.Address;
                item.Map = model.Map;
                item.Mobi = model.Mobi;
                item.Title = model.Title;
                item.Status = model.Status;
                db.SaveChanges();
                db.Dispose();
                return true;
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
                Branch item = db.Branches.Find(ID);
                db.Branches.Remove(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
