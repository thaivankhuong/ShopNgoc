using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToanThangSite.Business.Common
{
    public static class Commons
    {
        public static string RemoveDoubleSpace(this string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
        public static string ToNoSings(this string value, bool removeDoubleSpace = true)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            value = value.ToString();
            value = value.Normalize(NormalizationForm.FormD);
            value = regex.Replace(value, String.Empty);
            value = value.Replace('\u0111', 'd').Replace('\u0110', 'D');
            if (removeDoubleSpace)
                value = value.RemoveDoubleSpace();
            return value;
        }
        public static string ToUrlFormat(this string value, bool removeSign = true)
        {
            //1. Chuyển chuỗi về dạng chuỗi không Null
            if (value == null || value == string.Empty || value == "")
            {
                return value;
            }
                value = value.ToString();
            //2. Gỡ toàn bộ dấu nếu cần
            if (removeSign)
                value = value.ToNoSings(true);
            //3. Định nghĩa một danh sách các ký tự đặc biệt
            string specialChar = "@#$%^&()+-*/\\={}[]|:;'\"`“”<>.,?!_~";
            //4. Loại bỏ các ký tự đặc biệt
            foreach (char item in specialChar.ToCharArray())
            {
                value = value.Replace(item, ' ');
            }
            //5. Loại bỏ khoảng trắng kép
            value = value.RemoveDoubleSpace();
            //6. Chuyển đổi kiểu chữ hoa - thường
            value = value.ToLower();
            //7. Thay khoảng trắng bằng dấu gạch ngang (-)
            value = value.Replace(' ', '-');
            //8. Loại bỏ dấu gạch ngang ở 2 đầu văn bản
            value = value.Trim('-');
            //9. Trả về kết quả
            return value;
        }
    }
}
