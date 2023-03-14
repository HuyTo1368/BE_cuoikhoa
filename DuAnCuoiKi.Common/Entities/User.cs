using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
