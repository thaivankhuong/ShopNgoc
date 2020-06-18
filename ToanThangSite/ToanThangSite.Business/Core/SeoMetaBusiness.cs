using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public static class SeoMetaBusiness
    {
        public static List<SeoMeta> GetAll()
        {
            try
            {
                return SeoMetaServices.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SeoMeta GetById(int ID)
        {
            try
            {
                return SeoMetaServices.GetById(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool Update(int ID,SeoMeta item)
        {
            try
            {
                return SeoMetaServices.Update(ID, item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
