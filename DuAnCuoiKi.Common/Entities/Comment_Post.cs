using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.Common.Entities
{
    public class Comment_Post
    {
        public Guid CommentID { get; set; }
        public Guid UserID { get; set; }
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public DateTime CrateDateComment { get; set; }
    }
}
