using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using System.Net.Http.Headers;

namespace ManagerSystem.Services.Posts
{
    /// <summary>
    /// 岗位数据操作类
    /// </summary>
    public class PostService : IPostService
    {
        public int AddPost(Post post)
        {
            return MySqlHelper<Post>.GetInstance().CurrentDb.Insert(post)?1:0;
        }

        public int DeletePost(int id)
        {
           return MySqlHelper<Post>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0; ;
        }

        public PageRequest<Post> GetAllPost()
        {
            List<Post> posts = MySqlHelper<Post>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Post>() { items = posts, TotalCount = posts.Count };
        }

        public Post GetPost(int id)
        {
            return MySqlHelper<Post>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Post> GetPosts(string? postName, string? status, string? startDate, string? endDate, int pageNum, int pageSize)
        {
            int TotalCount = 0;
            DateTime StartDate = DateTime.Parse(startDate ?? DateTime.MinValue.ToShortDateString()).Date;
            DateTime EndDate = DateTime.Parse(endDate ?? DateTime.MaxValue.ToShortDateString()).Date;
            List<Post> posts = MySqlHelper<Post>.GetInstance().Db.Queryable<Post>()
                .WhereIF(!string.IsNullOrEmpty(postName), t => t.PostName.Contains(postName ?? ""))
                .WhereIF(!string.IsNullOrEmpty(status), t => t.Status == ((status ?? "").Contains("启用") ? true : false))
                .WhereIF(!string.IsNullOrEmpty(startDate), t => t.insertTime.Date >= StartDate)
                .WhereIF(!string.IsNullOrEmpty(endDate), t => t.insertTime.Date <= EndDate)
                .ToPageList(pageNum, pageSize, ref TotalCount);
            return new PageRequest<Post>() { TotalCount = TotalCount, items = posts };
        }

        public int UpdatePost(Post post)
        {
           return MySqlHelper<Post>.GetInstance().CurrentDb.Update(post)?1:0;
        }
    }
}
