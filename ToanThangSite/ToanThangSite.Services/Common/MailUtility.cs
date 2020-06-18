using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Services.Common
{
    public class MailUtility
    {


        #region Properties
        private string _From = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập địa chỉ gửi.
        /// VD: nguoigui@gmail.com
        /// </summary>
        public string From
        {
            get
            {
                return _From;
            }
            set
            {
                _From = value;
            }
        }

        private string _Password = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập mật khẩu gửi
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private string _Host = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập địa chỉ máy chủ gửi.
        /// VD: smpt.gmail.com
        /// </summary>
        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }

        private int _Port = 0;
        /// <summary>
        /// Trả về hoặc thiết lập cổng dùng để gửi.
        /// Mặc định cổng của gmail là: 587
        /// </summary>
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        private bool _EnableSSL = false;
        /// <summary>
        /// Trả về hoặc thiết lập cơ chế bảo mật SSL.
        /// Thiết lập là true nếu dùng gmail để gửi
        /// </summary>
        public bool EnableSSL
        {
            get
            {
                return _EnableSSL;
            }
            set
            {
                _EnableSSL = value;
            }
        }

        private string _To = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập địa chỉ nhận
        /// VD: nguoinhan@gmail.com
        /// </summary>
        public string To
        {
            get
            {
                return _To;
            }
            set
            {
                _To = value;
            }
        }

        private string _Subject = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập chủ đề của thư
        /// </summary>
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }

        private string _Body = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập nội dung của thư
        /// </summary>
        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }

        private bool _IsBodyHtml = false;
        /// <summary>
        /// Trả về hoặc thiết lập cấu hình sử dụng mã HTML trong nội dung thư
        /// </summary>
        public bool IsBodyHtml
        {
            get
            {
                return _IsBodyHtml;
            }
            set
            {
                _IsBodyHtml = value;
            }
        }

        private string _CC = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập địa chỉ CC.
        /// VD: chiase@gmail.com
        /// </summary>
        public string CC
        {
            get
            {
                return _CC;
            }
            set
            {
                _CC = value;
            }
        }

        private string _BCC = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập địa chỉ BCC.
        /// VD: chiasean@gmail.com
        /// </summary>
        public string BCC
        {
            get
            {
                return _BCC;
            }
            set
            {
                _BCC = value;
            }
        }

        private string _AttachmentFile = string.Empty;
        /// <summary>
        /// Trả về hoặc thiết lập đường dẫn đến file đính kèm
        /// VD: C:\demo\file.txt
        /// </summary>
        public string AttachmentFile
        {
            get
            {
                return _AttachmentFile;
            }
            set
            {
                _AttachmentFile = value;
            }
        }

        private Exception _LastException = null;
        /// <summary>
        /// Trả về hoặc thiết lập lỗi ngoại lệ cuối cùng
        /// </summary>
        public Exception LastException
        {
            get
            {
                return _LastException;
            }
            set
            {
                _LastException = value;
            }
        }
        #endregion

        #region StaticMethods
        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml)
        {
            Exception error = null;
            return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, string.Empty, string.Empty, string.Empty, ref error);
        }

        /// <summary>
        /// Gửi email có CC
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc)
        {
            Exception error = null;
            return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, string.Empty, string.Empty, ref error);
        }

        /// <summary>
        /// Gửi email có CC và BCC
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
        /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc)
        {
            Exception error = null;
            return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, bcc, string.Empty, ref error);
        }

        /// <summary>
        /// Gửi email có CC, BCC và file đính kèm
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
        /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
        /// <param name="attachmentFile">File đính kèm. Thiết lập attachmentFile là rỗng nếu không muốn gửi file đính kèm</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc, string attachmentFile)
        {
            Exception error = null;
            return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, bcc, attachmentFile, ref error);
        }

        /// <summary>
        /// Gửi email có CC, BCC, file đính kèm và bắt lỗi ngoại lệ
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
        /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
        /// <param name="attachmentFile">File đính kèm. Thiết lập attachmentFile là rỗng nếu không muốn gửi file đính kèm</param>
        /// <param name="error">Chứa lỗi ngoại lệ bắt được trong quá trình gửi mail</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc, string attachmentFile, ref Exception error)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtp = new SmtpClient();

            NetworkCredential credential = new NetworkCredential();

            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;
            if (cc != string.Empty)
                mail.CC.Add(cc);
            if (bcc != string.Empty)
                mail.Bcc.Add(bcc);
            if (attachmentFile != string.Empty)
                mail.Attachments.Add(new Attachment(attachmentFile));

            credential.UserName = from;
            credential.Password = password;

            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = enableSSL;
            smtp.Credentials = credential;

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }

            return true;
        }


        #endregion

        #region Methods
        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="from">Địa chỉ gửi</param>
        /// <param name="password">Mật khẩu gửi</param>
        /// <param name="host">Địa chỉ máy chủ</param>
        /// <param name="port">Cổng máy chủ</param>
        /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
        /// <param name="to">Địa chỉ người nhận</param>
        /// <param name="subject">Chủ đề của thư</param>
        /// <param name="body">Nội dung thư</param>
        /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
        /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
        public bool Send()
        {
            Exception error = null;
            bool result = MailUtility.Send(this.From, this.Password, this.Host, this.Port, this.EnableSSL, this.To, this.Subject, this.Body, this.IsBodyHtml, this.CC, this.BCC, this.AttachmentFile, ref error);
            this.LastException = error;

            return result;
        }

        #endregion
    }
}

