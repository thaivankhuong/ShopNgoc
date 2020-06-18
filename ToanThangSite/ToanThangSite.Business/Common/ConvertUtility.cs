using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Business.Common
{
    public static class ConvertUtility
    {
        #region ToByte
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static byte ToByte(this object value, byte defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            byte convertedValue = 0;
            bool isConverted = byte.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ không âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static byte? ToByte(this object value, byte? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên nhỏ không âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToByte(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            byte convertedValue = 0;
            bool isConverted = byte.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static byte ToByte(this object value)
        {
            return ToByte(value, 0);
        }
        #endregion

        #region ToSByte
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static sbyte ToSByte(this object value, sbyte defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            sbyte convertedValue = 0;
            bool isConverted = sbyte.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ có âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static sbyte? ToSByte(this object value, sbyte? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên nhỏ có âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToSByte(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            sbyte convertedValue = 0;
            bool isConverted = sbyte.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên nhỏ có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static sbyte ToSByte(this object value)
        {
            return ToSByte(value, 0);
        }
        #endregion

        #region ToInt
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static int ToInt(this object value, int defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            int convertedValue = 0;
            bool isConverted = int.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static int? ToInt(this object value, int? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToInt(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            int convertedValue = 0;
            bool isConverted = int.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static int ToInt(this object value)
        {
            return ToInt(value, 0);
        }
        #endregion

        #region ToUInt
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static uint ToUInt(this object value, uint defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            uint convertedValue = 0;
            bool isConverted = uint.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên không âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static uint? ToUInt(this object value, uint? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên không âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToUInt(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            uint convertedValue = 0;
            bool isConverted = uint.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static uint ToUInt(this object value)
        {
            return ToUInt(value, 0);
        }
        #endregion

        #region ToLong
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static long ToLong(this object value, long defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            long convertedValue = 0;
            bool isConverted = long.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn có âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static long? ToLong(this object value, long? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên lớn có âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToLong(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            long convertedValue = 0;
            bool isConverted = long.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static long ToLong(this object value)
        {
            return ToLong(value, 0);
        }
        #endregion

        #region ToULong
        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số nguyên lớn không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static ulong ToULong(this object value, ulong defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            ulong convertedValue = 0;
            bool isConverted = ulong.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn không âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số nguyên lớn không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static ulong? ToULong(this object value, ulong? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số nguyên lớn không âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToULong(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            ulong convertedValue = 0;
            bool isConverted = ulong.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số nguyên lớn không âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số nguyên lớn không âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static ulong ToULong(this object value)
        {
            return ToULong(value, 0);
        }
        #endregion

        #region ToFloat
        /// <summary>
        /// Chuyển đổi sang kiểu số thực nhỏ có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số thực nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static float ToFloat(this object value, float defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            float convertedValue = 0;
            bool isConverted = float.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực nhỏ có âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số thực nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static float? ToFloat(this object value, float? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số thực nhỏ có âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToFloat(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            float convertedValue = 0;
            bool isConverted = float.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực nhỏ có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số thực nhỏ có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static float ToFloat(this object value)
        {
            return ToFloat(value, 0);
        }
        #endregion

        #region ToDouble
        /// <summary>
        /// Chuyển đổi sang kiểu số thực lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số thực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static double ToDouble(this object value, double defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            double convertedValue = 0;
            bool isConverted = double.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực lớn có âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số thực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static double? ToDouble(this object value, double? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số thực lớn có âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToDouble(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            double convertedValue = 0;
            bool isConverted = double.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số thực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static double ToDouble(this object value)
        {
            return ToDouble(value, 0);
        }
        #endregion

        #region ToDecimal
        /// <summary>
        /// Chuyển đổi sang kiểu số thực cực lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng số thực cực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static decimal ToDecimal(this object value, decimal defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            decimal convertedValue = 0;
            bool isConverted = decimal.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (!isConverted)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực cực lớn có âm cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng số thực cực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static decimal? ToDecimal(this object value, decimal? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang số thực cực lớn có âm với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToDecimal(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            decimal convertedValue = 0;
            bool isConverted = decimal.TryParse(value.ToString().Trim(), out convertedValue);

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (!isConverted)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu số thực cực lớn có âm.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng số thực cực lớn có âm của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 0
        /// </returns>
        public static decimal ToDecimal(this object value)
        {
            return ToDecimal(value, 0);
        }
        #endregion

        

        #region ToBool
        /// <summary>
        /// Chuyển đổi sang kiểu luận lý. Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng luận lý của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static bool ToBool(this object value, bool defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Chuyển dữ liệu cần chuyển đổi về dạng chuỗi
            string valueString = value.ToString().Trim().ToLower();

            //Nếu là chuỗi chứa giá trị 1|true thì trả về true
            if (valueString == "1" || valueString == "true")
                return true;

            //Nếu là chuỗi chứa giá trị 0|false thì trả về false
            if (valueString == "0" || valueString == "false")
                return false;

            //Trả về giá trị đã được chuyển đổi kiểu
            return defaultValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu luận lý cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue. 
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn</param>
        /// <returns>
        /// Trả về dạng luận lý của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue</returns>
        public static bool? ToBool(this object value, bool? defaultValue)
        {
            //Nếu kết quả trả về không được null, thì gọi hàm chuyển đổi sang luận lý với giá trị mặc định là false
            if (defaultValue.HasValue)
                return ToBool(value, false);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định là null
            if (value == null)
                return null;

            //Chuyển dữ liệu cần chuyển đổi về dạng chuỗi
            string valueString = value.ToString().Trim().ToLower();

            //Nếu là chuỗi chứa giá trị 1|true thì trả về true
            if (valueString == "1" || valueString == "true")
                return true;

            //Nếu là chuỗi chứa giá trị 0|false thì trả về false
            if (valueString == "0" || valueString == "false")
                return false;

            //Nếu không chuyển đổi được thì trả về giá trị mặc định
            return defaultValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu luận lý.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là false
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng luận lý của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là false</returns>
        public static bool ToBool(this object value)
        {
            //Gọi hàm chuyển đổi sang luận lý với giá trị mặc định là false
            return ToBool(value, false);
        }
        #endregion

        #region ToStringSafe
        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <param name="isTrim">
        /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
        /// True: có cắt khoảng trắng ở 2 đầu;
        /// False: không cắt khoảng trắng ở 2 đầu
        /// </param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static string ToStringSafe(this object value, string defaultValue, bool isTrim)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Chuyển sang kiểu chuổi
            string convertedValue = value.ToString();

            //Cắt khoảng trắng nếu có thiết lập isTrim
            if (isTrim)
                convertedValue = convertedValue.Trim();

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static string ToStringSafe(this object value, string defaultValue)
        {
            return ToStringSafe(value, defaultValue, false);
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="isTrim">
        /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
        /// True: có cắt khoảng trắng ở 2 đầu;
        /// False: không cắt khoảng trắng ở 2 đầu
        /// </param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </returns>
        public static string ToStringSafe(this object value, bool isTrim)
        {
            return ToStringSafe(value, string.Empty, isTrim);
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </returns>
        public static string ToStringSafe(this object value)
        {
            return ToStringSafe(value, string.Empty, false);
        }
        #endregion

        #region ToChar
        /// <summary>
        /// Chuyển đổi sang kiểu ký tự.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng ký tự của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static char ToChar(this object value, char defaultValue)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Thử chuyển đổi
            string convertedValue = value.ToString();

            //Nếu không chuyển đổi được, thì trả về giá trị mặc định
            if (convertedValue.Length == 0)
                return defaultValue;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue[0];
        }

        /// <summary>
        /// Chuyển đổi sang kiểu ký tự cho phép null.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">
        /// Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ.
        /// DefaultValue có thể thiết lập là null nếu muốn
        /// </param>
        /// <returns>
        /// Trả về dạng ký tự của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static char? ToChar(this object value, char? defaultValue)
        {
            //Nếu defaultValue không null,
            //thì gọi hàm chuyển đổi sang ký tự với giá trị mặc định là defaultValue
            if (defaultValue != null)
                return ToChar(value, defaultValue.Value);

            //Nếu dữ liệu cần chuyển đổi là null, thì trả về null
            if (value == null)
                return null;

            //Thử chuyển đổi
            string convertedValue = value.ToString();

            //Nếu không chuyển đổi được, thì trả về giá trị null
            if (convertedValue.Length == 0)
                return null;

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue[0];
        }

        /// <summary>
        /// Chuyển đổi sang kiểu ký tự.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 1 khoảng trắng
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng ký tự của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là 1 khoảng trắng
        /// </returns>
        public static char ToChar(this object value)
        {
            return ToChar(value, ' ');
        }
        #endregion

        #region RoundToInt
        /// <summary>
        /// Làm tròn một số có kiểu float, lấy 0 số thập phân, sau đó chuyển đổi sang kiểu int.
        /// Trả về số sau khi đã làm tròn và chuyển sang kiểu int.
        /// </summary>
        /// <param name="value">Số cần làm tròn và chuyển đổi kiểu.</param>
        /// <returns>Trả về số sau khi đã làm tròn và chuyển sang kiểu int.</returns>
        public static int RoundToInt(this float value)
        {
            return Math.Round(value).ToInt();
        }

        /// <summary>
        /// Làm tròn một số có kiểu double, lấy 0 số thập phân, sau đó chuyển đổi sang kiểu int.
        /// Trả về số sau khi đã làm tròn và chuyển sang kiểu int.
        /// </summary>
        /// <param name="value">Số cần làm tròn và chuyển đổi kiểu.</param>
        /// <returns>Trả về số sau khi đã làm tròn và chuyển sang kiểu int.</returns>
        public static int RoundToInt(this double value)
        {
            return Math.Round(value).ToInt();
        }
        #endregion
    }
}
