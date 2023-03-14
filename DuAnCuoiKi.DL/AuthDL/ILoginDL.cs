using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.AuthDL
{
    public interface ILoginDL
    {
        public Guid CheckLogin(string userName, string UserPassword);
    }
}
