using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.Common.Entities
{
    public class UserInformation
    {
        public Guid userInforID { get; set; }
        public string fullName { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
        public DateTime birthday { get; set; }

    }
}
