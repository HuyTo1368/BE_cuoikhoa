using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.Common.Entities
{
    public class APost
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public string Caption { get; set; }
        public Guid photoID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
