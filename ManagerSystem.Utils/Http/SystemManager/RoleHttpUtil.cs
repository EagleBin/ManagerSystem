using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.SystemManager
{
    /// <summary>
    /// 权限 Http 请求方法类
    /// </summary>
    public class RoleHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static int AddRole(Role role)
        {
            var result = Post(UrlConfig.ROLE_ADDROLE, role);
            return int.Parse(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteRole(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.ROLE_DELETEROLE, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool UpdateRole(Role role)
        {
            var result = Put<Role>(UrlConfig.ROLE_UPDATEROLE, role);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 判断是否存在该权限名称
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool ExistRoleName(string roleName)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["roleName"] = roleName.ToString();
            var ret = Get(UrlConfig.ROLE_EXISTROLENAME, data);
            return int.Parse(ret) != 0;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Role GetRole(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.ROLE_GETROLE, data);
            var result_role = StrToObject<Role>(result_str);
            return result_role;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Role> GetAllRole()
        {
            Dictionary<string, object> datas = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.ROLE_GETAllROLE, datas);
            var result_roles = StrToObject<PageRequest<Role>>(result_str);
            return result_roles;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageRequest<Role> GetRoles(string roleName, string status, string startDate, string endDate, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["roleName"] = roleName;
            data["status"] = status;
            data["startDate"] = startDate;
            data["endDate"] = endDate;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.ROLE_GETROLES, data);
            var roles = StrToObject<PageRequest<Role>>(str);
            return roles;
        }

        /// <summary>
        /// 根据权限的id获取到权限的菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PageRequest<Menu> GetRoleMenu(int roleId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = roleId;
            var result_str = Get(UrlConfig.ROLE_GETROLEMENU, data);
            var result_data = StrToObject<PageRequest<Menu>>(result_str);
            return result_data;
        }

        /// <summary>
        /// 新增权限菜单
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool AddRoleMenu(RoleMenu roleMenu)
        {
            var result = Post<RoleMenu>(UrlConfig.ROLE_ADDROLEMENU, roleMenu);
            return int.Parse(result) != 0;
        }
        /// <summary>
        /// 删除RoleMenu
        /// </summary>
        /// <param name="role_id"></param>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public static bool DeleteRoleMenu(int role_id, int menu_id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["role_id"] = role_id.ToString();
            data["menu_id"] = menu_id.ToString();
            var result = Delete(UrlConfig.USER_DELETEROLEMENU, data);
            return int.Parse(result) != 0;

        }
    }
}
