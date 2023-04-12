using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.Comment
{
    public interface ICommentBL
    {
        /// <summary>
        /// Lấy ra tất cả bình luận
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getAllComment(Guid id);

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object updateComment(Guid _commentID, Guid _postID, string content);

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteComment(Guid _commentID);
    }
}
