using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Models;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class SearchResultBusiness
    {
        public static List<SearchResultViewModel> GetAllSearch(string KeyWord)
        {
            try
            {
                return SearchResultServices.GetAllSearch(KeyWord);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
