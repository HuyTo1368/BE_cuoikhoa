using Dapper;
using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.Common.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnCuoiKi.DL.Posts
{
    public class PostsDL : IPostsDL
    {
        /// <summary>
        /// Lấy ra thông tin các bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startPost"></param>
        /// <returns></returns>
        public object getPost(Guid id, int startPost)
        {
            object result;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"id", id);
            parameters.Add($"startPost", startPost);
            string storeProcedureName = string.Format(Resource_Post.Proc_Post_GetPost, typeof(APost).Name);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                result = mysqlConnection.QueryMultiple(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            return result;
        }

        /// <summary>
        /// Lấy thông tin cụ thể của một bài viết
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        public object getInforPost(Guid _postID)
        {
            object result;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"PostID", _postID);

            string storeProcedureName = string.Format(Resource_Post.Proc_Post_GetInforPost, typeof(APost).Name);

            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // thực hiện gọi vào DB
                result = mysqlConnection.QueryFirstOrDefault<APost>(
                storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            return result;

        }

        /// <summary>
        /// Cập nhật thông tin bài viết
        /// </summary>
        /// <param name="_post"></param>
        /// <returns></returns>
        public object updatePost(APost _post)
        {
            object result;
            var parameters = new DynamicParameters();
            var properties = typeof(APost).GetProperties();

            foreach (var property in properties)
            {
                string propertyName = property.Name;
                var propertyValue = property.GetValue(_post, null);
                parameters.Add($"{propertyName}", propertyValue);
            }

            string storeProdureName = String.Format(Resource_Post.Proc_Post_UpdatePost, typeof(APost).Name);
            int numberOfAffectdRows = 0;
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                numberOfAffectdRows = mysqlConnection.Execute(storeProdureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            if ( numberOfAffectdRows > 0 )
            {
                result = getInforPost(_post.PostID);
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Xóa baì viết
        /// </summary>
        /// <param name="_postID"></param>
        /// <returns></returns>
        public bool deletePost(Guid _postID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"PostID", _postID);

            string storeProcedureName = string.Format(Resource_Post.Proc_Post_DeletePost, typeof(APost).Name);
            int numberOfAffectdRows = 0;
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                numberOfAffectdRows = mysqlConnection.Execute(storeProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            }
            if( numberOfAffectdRows > 0 )
            {
                return true;
            }
            else { return false; }
        }
    }
}
