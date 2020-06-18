using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Business.Common
{
    public class SecurityUtility
    {
        #region Encrypt
        /// <summary>
        /// Mã hóa dùng thuật toán băm MD5.
        /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.
        /// </summary>
        /// <param name="value">Giá trị cần mã hóa.</param>
        /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.</returns>
        public static string MD5Encrypt(string value)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            //2. Chuyển value về dạng byte[] UTF8
            byte[] byteArray = Encoding.UTF8.GetBytes(value);

            //3. Tạo đối tượng hỗ trợ mã hóa MD5
            MD5 md5 = new MD5CryptoServiceProvider();

            //4. Mã hóa MD5
            byte[] md5Value = md5.ComputeHash(byteArray);

            //5. Chuyển byte[] về dạng String
            string result = BitConverter.ToString(md5Value);

            //6. Gỡ bỏ cách dấu phân cách
            result = result.Replace("-", string.Empty);

            //7. Trả về kết quả
            return result;
        }

        /// <summary>
        /// Mã hóa dùng thuật toán băm MD5 kết hợp với salt.
        /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.
        /// </summary>
        /// <param name="value">Giá trị cần mã hóa.</param>
        /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
        /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.</returns>
        public static string MD5Encrypt(string value, string salt)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            //2. Thêm mật mã vào đầu giá trị cần mã hóa
            value = salt + value;

            //3. Mã hóa và trả về kết quả
            return MD5Encrypt(value);
        }

        /// <summary>
        /// Mã hóa dùng thuật toán băm SHA256.
        /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.
        /// </summary>
        /// <param name="value">Giá trị cần mã hóa.</param>
        /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.</returns>
        public static string SHA256Encrypt(string value)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            //2. Chuyển value về dạng byte[] UTF8
            byte[] byteArray = Encoding.UTF8.GetBytes(value);

            //3. Tạo đối tượng hỗ trợ mã hóa SHA256
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            //4. Mã hóa SHA256
            byte[] sha256Value = sha256.ComputeHash(byteArray);

            //5. Chuyển byte[] về dạng String
            string result = BitConverter.ToString(sha256Value);

            //6. Gỡ bỏ cách dấu phân cách
            result = result.Replace("-", string.Empty);

            //7. Trả về kết quả
            return result;
        }

        /// <summary>
        /// Mã hóa dùng thuật toán băm SHA256 kết hợp với salt.
        /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.
        /// </summary>
        /// <param name="value">Giá trị cần mã hóa.</param>
        /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
        /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.</returns>
        public static string SHA256Encrypt(string value, string salt)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            //2. Thêm mật mã vào đầu giá trị cần mã hóa
            value = salt + value;

            //3. Mã hóa và trả về kết quả
            return SHA256Encrypt(value);
        }

        /// <summary>
        /// Mã hóa dữ liệu với thuật toán AES256.
        /// Trả về giá trị sau khi được mã hóa.
        /// </summary>
        /// <param name="value">Giá trị cần mã hóa.</param>
        /// <param name="password">Mật khẩu dùng để mã hóa</param>
        /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
        /// <returns>Trả về giá trị sau khi được mã hóa.</returns>
        public static string AES256Encrypt(string value, string password, string salt)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            //2. Chuyển value về dạng byte[] UTF8
            byte[] byteArray = UnicodeEncoding.Unicode.GetBytes(value);

            //3. Tạo fullPassword bằng cách kết hợp password và salt với nhau
            string fullPassword = password + salt;

            //4. Băm fullPassword bằng thuật toán SHA256
            SHA256 sha256 = SHA256.Create();
            byte[] key = sha256.ComputeHash(UnicodeEncoding.Unicode.GetBytes(fullPassword));

            //5. Tạo đối tượng hỗ trợ mã hóa AES 
            Aes aes = new AesCryptoServiceProvider();

            //6. Thiết lập mã hóa với kích thước 256 bit
            aes.KeySize = 256;

            //7. Thiết lập key
            aes.Key = key;

            //8. Phát sinh ngẫu nhiên một Vector mã hóa IV dựa trên fullPassword
            aes.GenerateIV();

            //9. Khởi tạo bộ mã hóa từ đối tượng hỗ trợ mã hóa
            ICryptoTransform encryptor = aes.CreateEncryptor();

            //10. Mã hóa dữ liệu
            byte[] secureBytes = encryptor.TransformFinalBlock(byteArray, 0, byteArray.Length);

            //11.Nối Vector IV vào phần đầu của dữ liệu đã mã hóa
            secureBytes = aes.IV.Concat(secureBytes).ToArray();

            //12.Chuyển byte[] về dạng String
            string result = Convert.ToBase64String(secureBytes);

            //13.Trả về kết quả
            return result;
        }

        /// <summary>
        /// Giải mã dữ liệu với thuật toán AES256.
        /// Trả về giá trị sau khi được giải mã.
        /// </summary>
        /// <param name="value">Giá trị đã mã hóa cần được giải mã.</param>
        /// <param name="password">Mật khẩu dùng để giải hóa</param>
        /// <param name="salt">Giá trị dùng làm khóa giải hóa</param>
        /// <returns>Trả về giá trị sau khi được giải mã.</returns>
        public static string AES256Decrypt(string value, string password, string salt)
        {
            //1. Nếu value = null hoặc empty thì trả về rỗng
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            //2. Chuyển value về dạng byte[] Unicode
            byte[] byteArray = Convert.FromBase64String(value);

            //3. Tạo fullPassword bằng cách kết hợp password và salt với nhau
            string fullPassword = password + salt;

            //4. Băm fullPassword bằng thuật toán SHA256
            SHA256 sha256 = SHA256.Create();
            byte[] key = sha256.ComputeHash(UnicodeEncoding.Unicode.GetBytes(fullPassword));

            //5. Tạo đối tượng hỗ trợ mã hóa AES 
            Aes aes = new AesCryptoServiceProvider();

            //6. Thiết lập mã hóa với kích thước 256 bit
            aes.KeySize = 256;

            //7. Thiết lập key
            aes.Key = key;

            //8. Kiểm tra tính hợp lệ của IV
            if (byteArray.Length < 16)
                return string.Empty;

            //9. Trích lọc Vector IV từ 16 bit đầu của dữ liệu mã hóa
            aes.IV = byteArray.Take(16).ToArray();

            //10. Khởi tạo bộ mã hóa từ đối tượng hỗ trợ mã hóa
            ICryptoTransform decryptor = aes.CreateDecryptor();

            //11. Tạo đối tượng chứa kết quả
            byte[] result = null;

            try
            {
                //12. Giải mã dữ liệu sau khi đã trích lọc Vector IV
                result = decryptor.TransformFinalBlock(byteArray, 16, byteArray.Length - 16);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            //13. Trả về kết quả
            return UnicodeEncoding.Unicode.GetString(result);
        }
        #endregion
    }
}
