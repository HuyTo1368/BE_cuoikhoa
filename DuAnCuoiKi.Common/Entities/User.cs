using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DuAnCuoiKi.Common.Entities
{
    /// <summary>
    /// Thông tin đăng nhập
    /// </summary>
    public class User
    {
        public Guid UserLoginID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        /// <summary>
        /// mã hóa mật khẩu
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public string MD5String(string passWord)
        {
            string password_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(passWord);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                password_md5 += b.ToString("X2");
            }
            return password_md5;
        }
    }
}
