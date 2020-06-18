using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public class BranchServices
    {
        public static List<Branch> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Branch> Lst = db.Branches.Where(x => x.Status == true).ToList();
                db.Dispose();
                return Lst;
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
                DBEntities db = new DBEntities();
                Branch item = db.Branches.FirstOrDefault(x => x.BranchID ==ID);
                db.Dispose();
                return item;
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
                DBEntities db = new DBEntities();
                List<Branch> Lst = new List<Branch>();
                for(int i = 0; i < ID.Length; i++)
                {
                    foreach (var item in db.Branches)
                    {
                        if (item.BranchID == Convert.ToInt32(ID[i]))
                        {
                            Lst.Add(item);
                        }
                    }
                }
                
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
