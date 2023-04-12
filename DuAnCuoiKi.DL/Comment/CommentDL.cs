using Dapper;
using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.Common.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.Comment
{
    public class CommentDL:ICommentDL
    {
        /// <summary>
        /// Lấy ra tất cả bình luận
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getComment(Guid id)
        {
            object result;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"PostID", id);

            string storeProcedureName = string.Format(Resource_Post.Proc_Post_GetInforPost, typeof(Comment_Post).Name);

            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // thực hiện gọi vào DB
                result = mysqlConnection.QueryFirstOrDefault<Comment_Post>(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            return result;
        }

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object updateComment(Guid _commentID, Guid _postID, string content)
        {
            object result;
            var parameters = new DynamicParameters();
            var properties = typeof(APost).GetProperties();

            parameters.Add($"CommentID", _commentID); 
            parameters.Add($"Content", content);


            string storeProdureName = String.Format(Resource_Post.Proc_Post_UpdatePost, typeof(Comment_Post).Name);
            int numberOfAffectdRows = 0;
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                numberOfAffectdRows = mysqlConnection.Execute(storeProdureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            if (numberOfAffectdRows > 0)
            {
                result = getComment(_postID);
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteComment(Guid _commentID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"Comment", _commentID);

            string storeProcedureName = string.Format(Resource_Post.Proc_Post_DeletePost, typeof(Comment_Post).Name);
            int numberOfAffectdRows = 0;
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                numberOfAffectdRows = mysqlConnection.Execute(storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            if (numberOfAffectdRows > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
