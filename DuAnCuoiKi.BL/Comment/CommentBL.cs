using DuAnCuoiKi.DL.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.Comment
{
    public class CommentBL:ICommentBL
    {
        private ICommentDL _commentDL;

        public CommentBL(ICommentDL commentDL)
        {
            _commentDL = commentDL;
        }
        /// <summary>
        /// Lấy ra tất cả bình luận
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getAllComment(Guid id)
        {
           return _commentDL.getComment(id);
        }

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object updateComment(Guid _commentID, Guid _postID, string content)
        {
            return _commentDL.updateComment(_commentID, _postID, content);
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteComment(Guid _commentID)
        {
            return _commentDL.deleteComment(_commentID);
        }
    }
}
