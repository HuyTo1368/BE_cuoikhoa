using DuAnCuoiKi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.BL.APosts
{
    public interface IPostBL
    {
        /// <summary>
        /// Lấy ra một số lượng bài viết nhất định
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getPost(Guid id, int startPost);

        /// <summary>
        /// Lấy ra thông tin của một bài viết
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        public object getInforPost(Guid _postID);

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object updatePost(APost _post);

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deletePost(Guid _postID);
    }
}
