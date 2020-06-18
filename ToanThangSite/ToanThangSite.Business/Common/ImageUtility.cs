using ToanThangSite.Business.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Business.Common
{
    public static class ImageUtility
    {
        #region Helpers
        /// <summary>
        /// Tìm Image Code theo tên.
        /// Trả về ImageCode tìm thấy. Nếu không tìm thấy thì trả về null.
        /// </summary>
        /// <param name="mimeType">Loại file. Ví dụ: image/jpeg hoặc image/gif hoặc image/png.</param>
        /// <returns>Trả về ImageCode tìm thấy. Nếu không tìm thấy thì trả về null.</returns>
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //1. Chuyển mimeType sang dạng chữ thường
            mimeType = mimeType.ToLower();

            //2. Liệt kê danh sách các image code có thể có
            ImageCodecInfo[] codes = ImageCodecInfo.GetImageEncoders();

            //3. Lặp qua từng code trong danh sách
            for (int i = 0; i < codes.Length; i++)
            {
                //So sánh, nếu có tên giống nhau thì trả kết quả về
                if (codes[i].MimeType.ToLower() == mimeType)
                    return codes[i];
            }

            //4. Nếu chạy hết vòng lặp mà vẫn không tìm thấy, thì trả về null
            return null;
        }

        /// <summary>
        /// Tính toán tọa độ đặt WaterMask
        /// </summary>
        /// <param name="waterMaskPositionType">Kiểu tọa độ đặt WaterMask.</param>
        /// <param name="sourceSize.Width">Chiều dài ảnh ban đầu.</param>
        /// <param name="sourceSize.Height">Chiều cao ảnh ban đầu.</param>
        /// <param name="waterMaskSize">Chiều dài ảnh làm WaterMask.</param>
        /// <param name="newWaterMaskHeight">Chiều cao ảnh làm WaterMask.</param>
        /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu.</param>
        /// <param name="waterMaskPoint.X">Tạo độ X của WaterMask.</param>
        /// <param name="waterMaskPoint.Y">Tạo độ Y của WaterMask.</param>
        private static void GetWaterMaskPosition(WaterMaskPositionType waterMaskPositionType, Size sourceSize, Size waterMaskSize, int waterMaskMargin, ref Point waterMaskPoint)
        {
            switch (waterMaskPositionType)
            {
                case WaterMaskPositionType.TopLeft:
                    waterMaskPoint.X = waterMaskMargin;
                    waterMaskPoint.Y = waterMaskMargin;
                    break;
                case WaterMaskPositionType.TopRight:
                    waterMaskPoint.X = sourceSize.Width - waterMaskSize.Width - waterMaskMargin;
                    waterMaskPoint.Y = waterMaskMargin;
                    break;
                case WaterMaskPositionType.BottomRight:
                    waterMaskPoint.X = sourceSize.Width - waterMaskSize.Width - waterMaskMargin;
                    waterMaskPoint.Y = sourceSize.Height - waterMaskSize.Height - waterMaskMargin;
                    break;
                case WaterMaskPositionType.BottomLeft:
                    waterMaskPoint.X = waterMaskMargin;
                    waterMaskPoint.Y = sourceSize.Height - waterMaskSize.Height - waterMaskMargin;
                    break;
                case WaterMaskPositionType.MiddleCenter:
                default:
                    waterMaskPoint.X = ((sourceSize.Width - waterMaskSize.Width) / 2F).RoundToInt();
                    waterMaskPoint.Y = ((sourceSize.Height - waterMaskSize.Height) / 2F).RoundToInt();
                    break;
            }
        }

        /// <summary>
        /// Trả về đối tượng ImageAttributes có hỗ trợ độ trong suốt
        /// </summary>
        /// <param name="opacityPecent">Độ trong suốt của hình. Có giá trị nằm trong khoảng 0 - 100</param>
        /// <returns>Trả về đối tượng ImageAttributes có hỗ trợ độ trong suốt</returns>
        private static ImageAttributes GetImageAttributes(int opacityPecent)
        {
            //1. Chuyển độ trong suốt từ số nguyên sang dạng phần trăm 
            float alphaPercent = opacityPecent / 100F;

            //2. Tạo một đối tượng để thiết lập các thuộc tính của ảnh
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] mapTable = { colorMap };

            //3. Thiết lập độ trong suốt cho ảnh (chú ý vị trí của alphaPercent)
            float[][] colorMatrixElements = {   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  alphaPercent, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                    };

            //4. Thiết lập các thuộc tính của ảnh
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetRemapTable(mapTable, ColorAdjustType.Bitmap);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            //5. Trả về đối tượng đã được thiết lập đầy đủ các thông số.
            return imageAttributes;
        }

        /// <summary>
        /// Tạo một hình Bitmap sử dụng văn bản và các tham số hình.
        /// </summary>
        /// <param name="text">Văn bản cần hiển thị.</param>
        /// <param name="fontUrl">Đường dẫn đến font. Cần sử dụng Font thuộc họ Unicode.</param>
        /// <param name="fontStyle">Kiểu Font: , bình thường, in đậm, in nghiêng hoặc gạch chân.</param>
        /// <param name="textColor1">Màu chữ số 1. Dùng để hòa trộn với Màu chữ số 2.</param>
        /// <param name="textColor2">Màu chữ số 2. Dùng để hòa trộn với Màu chữ số 1.</param>
        /// <param name="backgroundColor">Màu nền của ảnh.</param>
        /// <param name="borderColor">Màu khung.</param>
        /// <param name="borderSize">Cỡ khung. Đơn vị là px</param>
        /// <param name="gradientAngle">Góc hòa trộn màu sử dụng Gradient</param>
        /// <returns></returns>
        private static Bitmap CreateBitmapImageFromText(string text, string fontUrl, FontStyle fontStyle, Color textColor1, Color textColor2, Color backgroundColor, Color borderColor, int borderSize, int gradientAngle)
        {
            //1. Định nghĩa cỡ font thật lớn thu được hình có độ phân giải cao.
            //Lưu ý: chỉ nên thiết lập khoảng 1000 trở lại, nếu lớn hơn có thể gây ra lỗi.
            int fontSize = 1000;

            //2. Tạo font chữ cá nhân từ file Font, fontSize, và fontStyle.
            Font font = CreatePrivateFont(fontUrl, fontSize, fontStyle);

            //3. Tạo ảnh Bitmap trong suốt có kích cỡ phù hợp với nội dung và cỡ chữ.
            Bitmap bitmap = CreateEmptyBitmap(text, font);

            //4. Tạo một đối tượng xử lý ảnh.
            Graphics graphic = Graphics.FromImage(bitmap);

            //5. Thiết lập màu nền cho ảnh
            graphic.Clear(backgroundColor);

            //6. Thiết lập các thông số chất lượng.
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            //7. Thiết lập thông số tối ưu dành cho văn bản
            graphic.TextRenderingHint = TextRenderingHint.AntiAlias;

            //8. Thiết lập kiểu viền bao quan chữ
            Pen pen = new Pen(borderColor, borderSize);
            pen.LineJoin = LineJoin.Round;

            //9. Thiết lập hiệu ứng chuyển sắc Gradient cho vùng chọn
            //9.1 Tạo vùng chọn bọc hết phần chữ
            Rectangle rectangleGradient = new Rectangle(0, bitmap.Height - font.Height, bitmap.Width, font.Height);
            //9.2. Thiết lập hiệu ứng chuyển sắc Gradient cho vùng chọn
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleGradient, textColor1, textColor2, gradientAngle);

            //10. Định dạng canh giữa chữ cả 2 chiều ngang-dọc
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            //11. Tạo đối tượng GraphicsPath để xử lý chữ
            GraphicsPath textGraphicsPath = new GraphicsPath();

            //12. Tạo vùng chọn để đặt chữ vào.
            Rectangle textRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            //13. Chèn chữ vào vùng chọn.
            textGraphicsPath.AddString(text, font.FontFamily, (int)fontStyle, fontSize, textRectangle, stringFormat);

            //14. Tạo hiệu ứng Gradient.
            graphic.FillPath(linearGradientBrush, textGraphicsPath);

            //15. Tạo hiệu ứng chữ có viền xung quanh.
            graphic.DrawPath(pen, textGraphicsPath);

            //16. Trả về hình được tạo ra từ văn bản với các thông số đã chọn
            return bitmap;
        }

        /// <summary>
        /// Tạo một ảnh Bimap rỗng, có chiều dài x chiều cao phù hợp với nội dung và font chữ.
        /// </summary>
        /// <param name="text">Chuỗi cần tạo hình động.</param>
        /// <param name="font">Font chữ cho chuỗi cần tạo hình động.</param>
        /// <returns></returns>
        private static Bitmap CreateEmptyBitmap(string text, Font font)
        {
            //1. Cộng thêm một khoảng trắng vào 2 đầu văn bản để tránh tình trạng bị che mất 1 ký tự đầu hoặc cuối
            text = " " + text + " ";

            //2. Tạo một hình Bitmap rỗng có kích cỡ tối thiểu 1px
            Bitmap bitmap = new Bitmap(1, 1);

            //3. Tạo một đối tượng xử lý ảnh
            Graphics graphic = Graphics.FromImage(bitmap);

            //4. Tính toán kích cỡ của ảnh dựa trên font và độ dài văn bản
            SizeF autoSizeFont = graphic.MeasureString(text, font);

            //5. Thiết lập kích cỡ mới cho ảnh
            bitmap = new Bitmap((int)autoSizeFont.Width, (int)autoSizeFont.Height);

            //6. Trả về ảnh Bitmap đúng kích cỡ. Ảnh này còn trong suốt, chưa có màu sắc gì.
            return bitmap;
        }

        /// <summary>
        /// Tạo một Font chữ cá nhân từ một file font chữ bất kỳ.
        /// Trả về font chữ đúng với các cấu hình.
        /// </summary>
        /// <param name="url">Đường dẫn đến file font. Ví dụ: ../../UVNDUNGDAN.TTF</param>
        /// <param name="fontSize">Cỡ font. Nằm trong khoảng 1 - 1000</param>
        /// <param name="fontStyle">Kiểu chữ. Regular: bình thường; Bold: in đậm; Italic: nghiêng; Underline: gạch chân.</param>
        /// <returns>Trả về font chữ đúng với các cấu hình.</returns>
        private static Font CreatePrivateFont(string url, int fontSize, FontStyle fontStyle)
        {
            //1. Tạo Font chữ cá nhân
            PrivateFontCollection privteFont = new PrivateFontCollection();

            //2. Thiết lập font từ URL
            privteFont.AddFontFile(url);

            //3. Tạo một fontFamily
            FontFamily fontFamily = privteFont.Families[0];

            //4. Cấu hình các tham số cho font
            Font font = new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Pixel);

            //5. Trả về kết quả
            return font;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Load ảnh Bitmap từ Url.
        /// Trả về ảnh có dạng Bitmap.
        /// </summary>
        /// <param name="url">Vị trí dẫn đến file ảnh.</param>
        /// <returns>Trả về ảnh có dạng Bitmap.</returns>
        public static Bitmap LoadImage(string url)
        {
            Bitmap bitmap = new Bitmap(url);
            return bitmap;
        }

        /// <summary>
        /// Thay đổi kích cỡ của ảnh.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần thay đổi kích cỡ.</param>
        /// <param name="newWidth">Chiều dài mới.</param>
        /// <param name="newHeight">Chiều cao mới.</param>
        /// <param name="fitSizeType">
        /// Độ ưu tiên khi tỷ lệ của chiều dài mới và chiều cao mới không tương đồng với nhau.
        /// </param>
        /// <returns>Trả về ảnh với kích cỡ mới.</returns>
        public static Bitmap ResizeImage(Bitmap sourceImage, int size, FitSizeType fitSizeType)
        {
            //1. Lấy chiều dài ban đầu của ảnh.
            int sourceWidth = sourceImage.Width;
            //2. Lấy chiều cao ban đầu của ảnh.
            int sourceHeight = sourceImage.Height;

            //3. Khai báo chiều dài mới và chiều cao mới
            int newWidth = 0;
            int newHeight = 0;

            //4. Kiểm tra độ ưu tiên để thiết lập kích cỡ mới
            if (fitSizeType == FitSizeType.Width)
            {
                newWidth = size;
                newHeight = ((sourceHeight * newWidth) / sourceWidth.ToFloat()).RoundToInt();
            }
            else
            {
                newHeight = size;
                newWidth = ((sourceWidth * newHeight) / sourceHeight.ToFloat()).RoundToInt();
            }

            //5. Tạo một đối tượng Bitmap có kích cỡ theo tỷ lệ.
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            //6. Tạo một đối tượng xử lý ảnh
            Graphics graphic = Graphics.FromImage(newImage);

            //7. Thiết lập chất lượng ảnh là cao nhất
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //8. Tạo ảnh mới với kích cỡ mới
            graphic.DrawImage(sourceImage, 0, 0, newWidth, newHeight);

            //9. Giải phóng bộ nhớ, của đối tượng graphic
            graphic.Dispose();

            //10. Trả về kết quả
            return newImage;
        }

        /// <summary>
        /// Lưu ảnh thành file.
        /// Có thể tùy chọn loại ảnh (jpg|png|gif|v.v..) theo url, tùy chọn resolution và tùy chọn chất lượng ảnh.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần lưu thành file.</param>
        /// <param name="quality">Chất lượng của ảnh sau khi lưu.</param>
        /// <param name="url">Vị trí sẽ lưu ảnh.
        /// Vd: C:\Images\abc.jpeg
        /// </param>
        /// <returns>Kết quả của việc lưu hình.
        /// True: lưu hình thành công; False: lưu hình không thành công.
        /// </returns>
        public static bool SaveImage(Bitmap sourceImage, float resolution, int quality, string url)
        {
            //1. Lấy đuôi hình từ url để save cho đúng kiểu
            string extension = Path.GetExtension(url);

            //2. Nếu đuôi có dạng jpg thì đổi thành jpeg cho đúng chuẩn
            extension = extension.Replace("jpg", "jpeg");

            //3. Thay đuôi có dạng .xyz thành image/xyz
            extension = extension.Replace(".", "image/");

            //4. Thiết lập kiểu hình khi lưu trữ
            ImageCodecInfo imageCode = GetEncoderInfo(extension);

            //5. Nếu loại hình không hợp lệ thì kết thúc
            if (imageCode == null)
                return false;

            //6. Thiết lập chất lượng khi lưu trữ
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            //7. Đưa tham số vào trong danh sách tham số
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            //8. Tạo một ảnh mới có kích cỡ như hình ban đầu
            Bitmap newImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            //9. Thiết lập Resolution cho hình mới
            newImage.SetResolution(resolution, resolution);

            //10. Tạo 1 đối tượng xử lý ảnh
            Graphics graphic = Graphics.FromImage(newImage);

            //11. Thiết lập các thông số ảnh
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            //12. Tạo ảnh mới với kích cỡ mới
            graphic.DrawImage(sourceImage, 0, 0, sourceImage.Width, sourceImage.Height);

            //13. Giải phóng bộ nhớ của đối tượng graphic
            graphic.Dispose();

            //14. Lưu ảnh đúng vị trí, định dạng và chất lượng.
            newImage.Save(url, imageCode, encoderParams);

            //15. Trả về thành công
            return true;
        }

        /// <summary>
        /// Xoay ảnh một góc tùy ý theo RotateFlipType. Trả về ảnh sau khi đã xoay.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần xoay.</param>
        /// <param name="rotateFlipType">Góc xoay.</param>
        /// <returns>Trả về ảnh sau khi đã xoay.</returns>
        public static Bitmap RotateImage(Bitmap sourceImage, RotateFlipType rotateFlipType)
        {
            //1. Tạo một ảnh mới bằng cách nhân bản từ ảnh ban đầu.
            Bitmap newImage = sourceImage.Clone() as Bitmap;

            //2. Xoay ảnh theo kiểu xoay đã chọn
            newImage.RotateFlip(rotateFlipType);

            //3. Trả về kết quả
            return newImage;
        }

        /// <summary>
        /// Xoay ảnh sang trái một góc 90 độ. Trả về ảnh sau khi đã xoay.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần xoay.</param>
        /// <returns>Trả về ảnh sau khi đã xoay.</returns>
        public static Bitmap RotateImageToLeft(Bitmap sourceImage)
        {
            return RotateImage(sourceImage, RotateFlipType.Rotate90FlipXY);
        }

        /// <summary>
        /// Xoay ảnh sang phải một góc 90 độ. Trả về ảnh sau khi đã xoay.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần xoay.</param>
        /// <returns>Trả về ảnh sau khi đã xoay.</returns>
        public static Bitmap RotateImageToRight(Bitmap sourceImage)
        {
            return RotateImage(sourceImage, RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// Đóng dấu lên ảnh sử dụng hình làm WaterMask.
        /// Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.
        /// </summary>
        /// <param name="sourceImage">Ảnh ban đầu.</param>
        /// <param name="waterMaskImage">Ảnh dùng làm WaterMask.</param>
        /// <param name="waterMaskOpacityPecent">Độ rõ của WaterMask. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
        /// <param name="waterMaskRatio">Tỉ lệ kích cỡ của WaterMask so với ảnh ban đầu. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
        /// <param name="waterMaskPositionType">Vị trí đặt WaterMask trên ảnh ban đầu.</param>
        /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu. Không áp dụng khi thiết lập WaterMaskPositionType = MiddleCenter</param>
        /// <returns>Trả về ảnh đã được đóng dấu sử dụng WaterMask.</returns>
        public static Bitmap WaterMaskWithImage(Bitmap sourceImage, Bitmap waterMaskImage, int waterMaskOpacityPecent, int waterMaskRatio, WaterMaskPositionType waterMaskPositionType, int waterMaskMargin)
        {
            //1. Lấy kích cỡ thật của ảnh ban đầu
            Size sourceSize = sourceImage.Size;

            //2. Lấy kích cỡ thật của ảnh WaterMask
            Size sourceWaterMaskSize = waterMaskImage.Size;

            //3. Tính lại kích cỡ mới của WaterMask theo tỉ lệ
            Size waterMaskSize = new Size();
            waterMaskSize.Width = (sourceSize.Width * waterMaskRatio / 100F).RoundToInt();
            waterMaskSize.Height = (sourceWaterMaskSize.Height * waterMaskSize.Width / sourceWaterMaskSize.Width.ToFloat()).RoundToInt();

            //4. Resize ảnh WaterMask theo tỉ lệ
            waterMaskImage = ResizeImage(waterMaskImage, waterMaskSize.Width, FitSizeType.Width);

            //5. Tạo một ảnh mới có kích cỡ như ảnh ban đầu để lưu kết quả
            Bitmap newImage = new Bitmap(sourceSize.Width, sourceSize.Height, PixelFormat.Format24bppRgb);

            //6. Thiết lập độ phân giải của ảnh mới giống như ảnh ban đầu
            newImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            //7. Tạo một đối tượng xử lý ảnh
            Graphics graphic = Graphics.FromImage(newImage);

            //8. Thiết lập chất lượng là tốt nhất
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            //9. Copy ảnh ban đầu lên ảnh mới (layer 1)
            graphic.DrawImage(sourceImage, new Rectangle(0, 0, sourceSize.Width, sourceSize.Height), 0, 0, sourceSize.Width, sourceSize.Height, GraphicsUnit.Pixel);

            //10. Xử lý độ trong suốt của WaterMask
            ImageAttributes imageAttributes = GetImageAttributes(waterMaskOpacityPecent);

            //11. Tính toán tọa độ bắt đầu đặt WaterMask trên ảnh
            Point waterMaskPoint = new Point(0, 0);
            GetWaterMaskPosition(waterMaskPositionType, sourceSize, waterMaskSize, waterMaskMargin, ref waterMaskPoint);

            //12. Tính toán khu vực đặt WaterMask
            Rectangle waterMaskRectangle = new Rectangle();
            waterMaskRectangle.X = waterMaskPoint.X;
            waterMaskRectangle.Y = waterMaskPoint.Y;
            waterMaskRectangle.Width = waterMaskSize.Width;
            waterMaskRectangle.Height = waterMaskSize.Height;

            //13. Đóng dấu Watermark lên ảnh
            graphic.DrawImage(waterMaskImage, waterMaskRectangle, 0, 0, waterMaskSize.Width, waterMaskSize.Height, GraphicsUnit.Pixel, imageAttributes);

            //14. Trả về kết quả
            return newImage;
        }

        /// <summary>
        /// Đóng dấu lên ảnh sử dụng văn bản làm WaterMask.
        /// Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.
        /// </summary>
        /// <param name="sourceImage">Ảnh ban đầu.</param>
        /// <param name="text">Văn bản dùng làm WaterMask</param>
        /// <param name="fontUrl">Đường dẫn đến font của văn bản dùng làm WaterMask</param>
        /// <param name="waterMaskOpacityPecent">Độ rõ của WaterMask. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
        /// <param name="waterMaskRatio">Tỉ lệ kích cỡ của WaterMask so với ảnh ban đầu. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
        /// <param name="waterMaskPositionType">Vị trí đặt WaterMask trên ảnh ban đầu.</param>
        /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu. Không áp dụng khi thiết lập WaterMaskPositionType = MiddleCenter</param>
        /// <param name="fontStyle">Kiểu Font. Regular: bình thường; Bold: in đậm; Italic: in nghiêng; Underline: gạch chân; Strikeout: gạch ngang.</param>
        /// <param name="textColor1">Màu chữ 01.</param>
        /// <param name="textColor2">Màu chữ 02.</param>
        /// <param name="gradientAngle">Góc hòa trộn màu chữ 01 và màu chữ 02. Giá trị nằm trong khoảng 0 - 360.</param>
        /// <param name="backgroundColor">Màu nền</param>
        /// <param name="borderColor">Màu đường viền bo quanh chữ.</param>
        /// <param name="borderSize">Cỡ đường viền bo quanh chữ.</param>
        /// <returns>Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.</returns>
        public static Bitmap WaterMaskWithString(Bitmap sourceImage, string text, string fontUrl, int maskOpacityPecent, int waterMaskRatio, WaterMaskPositionType waterMaskPosition, int waterMaskMargin, FontStyle fontStyle, Color textColor1, Color textColor2, int gradientAngle, Color backgroundColor, Color borderColor, int borderSize)
        {
            //Tạo một hình Bitmap sử dụng văn bản và các thông số.
            Bitmap textBitmap = CreateBitmapImageFromText(text, fontUrl, fontStyle, textColor1, textColor2, backgroundColor, borderColor, borderSize, gradientAngle);
            //Đóng dấu lên hình
            return WaterMaskWithImage(sourceImage, textBitmap, maskOpacityPecent, waterMaskRatio, waterMaskPosition, waterMaskMargin);
        }

        /// <summary>
        /// Cắt cúp ảnh tại 1 vùng được chọn.
        /// Trả về ảnh mới được tạo ra từ vùng chọn cắt cúp.
        /// </summary>
        /// <param name="sourceImage">Ảnh cần được cắt cúp.</param>
        /// <param name="rectangle">Khu vực cần được cắt cúp.</param>
        /// <returns>Trả về ảnh mới được tạo ra từ vùng chọn cắt cúp.</returns>
        public static Bitmap CropImage(Bitmap sourceImage, Rectangle rectangle)
        {
            //1. Tạo một ảnh mới có kích cỡ vừa bằng khu vực cần cắt cúp ảnh
            Bitmap newImage = new Bitmap(rectangle.Width, rectangle.Height);

            //2. Tạo một đối tượng xử lý ảnh
            Graphics graphics = Graphics.FromImage(newImage);

            //3. Tô màu lên ảnh mới với dữ liệu được chọn từ ảnh ban đầu tại khu vực cần cắt cúp ảnh
            graphics.DrawImage(sourceImage, 0, 0, rectangle, GraphicsUnit.Pixel);

            //4. Trả về ảnh mới
            return newImage;
        }
        #endregion

        public enum FitSizeType
        {
            Width = 1,
            Height = 2
        }

        public enum WaterMaskPositionType
        {
            MiddleCenter = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 3,
            BottomRight = 4
        }

        public enum StringCaseType
        {
            None = 0,
            UpperCase = 1,
            LowerCase = 2,
            TitleCase = 3
        }

        
    }
}
