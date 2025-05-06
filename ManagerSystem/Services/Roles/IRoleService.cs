using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Roles
{
    public interface IRoleService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddRole(Role role);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int UpdateRole(Role role);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public int ExistRoleName(string roleName);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRole(int id);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public PageRequest<Role> GetAllRole();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageRequest<Role> GetRoles(string? roleName, string? status, string? startDate, string? endDate, int pageNum, int pageSize);

        /// <summary>
        /// 查询角色菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PageRequest<Menu> GetRoleMenu(int id);

        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        public int AddRoleMenu(RoleMenu roleMenu);

        /// <summary>
        /// 删除角色菜单
        /// </summary>
        /// <param name="role_id"></param>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public int DeleteRoleMenu(int role_id, int menu_id);

    }
}
