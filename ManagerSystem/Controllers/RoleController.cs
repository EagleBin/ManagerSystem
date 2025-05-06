using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Roles;
using ManagerSystem.Services.Users;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            this._logger = logger;
            this._roleService = roleService;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPut]
        public int AddRole(Role role)
        {
            return _roleService.AddRole(role);
        }

        /// <summary>
        /// 添加角色菜单
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        [HttpPut]
        public int AddRoleMenu(RoleMenu roleMenu)
        {
            return _roleService.AddRoleMenu(roleMenu);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteRole(int id)
        {
            return _roleService.DeleteRole(id);
        }

        /// <summary>
        /// 删除角色菜单
        /// </summary>
        /// <param name="role_id"></param>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteRoleMenu(int role_id, int menu_id)
        {
            return _roleService.DeleteRoleMenu(role_id, menu_id);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateRole(Role role)
        {
            return _roleService.UpdateRole(role);
        }

        /// <summary>
        /// 是否存在用户名
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        public int ExistRoleName(string roleName)
        {
            return _roleService.ExistRoleName(roleName);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Role GetRole(int id)
        {
            return _roleService.GetRole(id);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Role> GetAllRole()
        {
            return _roleService.GetAllRole();
        }

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
        [HttpGet]
        public PageRequest<Role> GetRoles(string? roleName, string? status, string? startDate, string? endDate, int pageNum, int pageSize)
        {
            return _roleService.GetRoles(roleName, status, startDate, endDate, pageNum, pageSize);
        }
    }
}
