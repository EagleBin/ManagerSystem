using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Users
{
    /// <summary>
    /// 用户数据操作接口类
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(int id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(User user);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int ExistAccount(string account);

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int GetLoginUser(string Account, string Password);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<User> GetAllUser();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="account"></param>
        /// <param name="phoneNum"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="depId"></param>
        /// <returns></returns>
        public PageRequest<User> GetUsers(string? account, string? phoneNum, string? status, string? startDate, string? endDate, int pageNum, int pageSize, int depId);

        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PageRequest<Role> GetUserRole(int id);

        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public int AddUserRole(UserRole userRole);

        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public int DeleteUserRole(int user_id, int role_id);

        /// <summary>
        /// 查询用户岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PageRequest<Post> GetUserPost(int id);

        /// <summary>
        /// 新增用户岗位
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        public int AddUserPost(UserPost userPost);
    }
}
