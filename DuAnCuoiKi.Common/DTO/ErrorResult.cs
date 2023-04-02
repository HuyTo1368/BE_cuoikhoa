using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.Common.DTO
{
    public class ErrorResult
    {
        public string DevMsg { get; set; }
        public string UserMsg { get; set; }
        public object MoreInfo { get; set; }

        public ErrorResult(string devMsg, string userMsg, object moreInfo)
        {
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
        }
    }
}
