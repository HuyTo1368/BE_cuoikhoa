using DuAnCuoiKi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.Comment
{
    public interface ICommentDL
    {
        /// <summary>
        /// Lấy ra tất cả bình luận
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getComment(Guid id);

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
