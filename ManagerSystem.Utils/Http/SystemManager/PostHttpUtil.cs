using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.SystemManager
{
    public class PostHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static bool AddPost(Post post)
        {
            var result = Post(UrlConfig.POST_ADDPOST, post);
            return int.Parse(result)!=0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePost(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.POST_DELETEPOST, data);
            return int.Parse(result)!=0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static bool UpdatePost(Post post)
        {
            var result = Put<Post>(UrlConfig.POST_UPDATEPOST, post);
            return int.Parse(result)!=0;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Post GetPost(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result_str = Get(UrlConfig.POST_GETPOST, data);
            var result_post = StrToObject<Post>(result_str);
            return result_post;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Post> GetAllPost()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.POST_GETAllPOST, data);
            var result_post = StrToObject<PageRequest<Post>>(result_str);
            return result_post ;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="postName"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageRequest<Post> GetPosts(string postName, string status, string startDate, string endDate, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["postName"] = postName;
            data["status"] = status;
            data["startDate"] = startDate;
            data["endDate"] = endDate;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.POST_GETPOSTS, data);
            var roles = StrToObject<PageRequest<Post>>(str);
            return roles;
        }
    }
}
