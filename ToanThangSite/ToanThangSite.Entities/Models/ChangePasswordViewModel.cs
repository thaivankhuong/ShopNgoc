using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        public string NewPassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    }
}
