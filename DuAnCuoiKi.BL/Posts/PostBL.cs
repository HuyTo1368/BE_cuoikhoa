using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.DL.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.APosts
{
    public class PostBL : IPostBL
    {
        private IPostsDL _postsDL;
        public PostBL(IPostsDL postsDL)
        {
            _postsDL = postsDL;
        }
        /// <summary>
        /// Lấy ra một số lượng bài viết nhất định
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getPost(Guid id, int startPost)
        {
            return _postsDL.getPost(id, startPost);
        }

        /// <summary>
        /// Lấy ra thông tin của một bài viết
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        public object getInforPost(Guid _postID)
        {
            return _postsDL.getInforPost(_postID);
        }

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object updatePost(APost _post)
        {
            return (_postsDL.updatePost(_post));
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deletePost(Guid _postID)
        {
            return _postsDL.deletePost(_postID);
        }
    }
}
