using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Posts;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            this._logger = logger;
            this._postService = postService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut]
        public int AddPost(Post post)
        {
            return _postService.AddPost(post);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int intDeletePost(int id)
        {
            return _postService.DeletePost(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdatePost(Post post)
        {
            return _postService.UpdatePost(post);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Post GetPost(int id)
        {
            return _postService.GetPost(id);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Post> GetAllPost()
        {
            return _postService.GetAllPost();
        }

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
        [HttpGet]
        public PageRequest<Post> GetPosts(string? postName, string? status, string? startDate, string? endDate, int pageNum, int pageSize)
        {
            return _postService.GetPosts(postName, status, startDate, endDate, pageNum, pageSize);
        }
    }
}
