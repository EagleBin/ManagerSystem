using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Users;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public int AddUser(User user)
        {
            return _userService.AddUser(user);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpPost]
        public int UpdateUser(User user)
        {
            return _userService.UpdateUser(user);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        public int ExistAccount(string account)
        {
            return _userService.ExistAccount(account);
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetLoginUser(string Account, string Password)
        {
            return _userService.GetLoginUser(Account, Password);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public User GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }
        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<User> GetUsers(string? account, string? phoneNum, string? status, string? startDate, string? endDate, int pageNum, int pageSize, int depId)
        {
            return _userService.GetUsers(account, phoneNum, status, startDate, endDate, pageNum, pageSize, depId);
        }

        /// <summary>
        /// 根据用户的id获取用户的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Role> GetUserRole(int id)
        {
            return _userService.GetUserRole(id);
        }
        /// <summary>
        /// 新增用户角色
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddUserRole(UserRole userRole)
        {
            return _userService.AddUserRole(userRole);
        }
        /// <summary>
        /// 新增用户岗位
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddUserPost(UserPost userPost)
        {
            return _userService.AddUserPost(userPost);
        }
        /// <summary>
        /// 删除UserRole
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteUserRole(int user_id, int role_id)
        {
            return _userService.DeleteUserRole(user_id, role_id);
        }
        /// <summary>
        /// 根据用户的id获取用户的岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Post> GetUserPost(int id)
        {
            return _userService.GetUserPost(id);
        }
    }
}
