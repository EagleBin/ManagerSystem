using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Posts
{
    /// <summary>
    /// 岗位数据操作接口类
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int AddPost(Post post);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePost(int id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int UpdatePost(Post post);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetPost(int id);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public PageRequest<Post> GetAllPost();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="postName"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageRequest<Post> GetPosts(string? postName, string? status, string? startDate, string? endDate, int pageNum, int pageSize);

    }
}
