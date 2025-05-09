using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ManagerSystem.Utils.Http.SystemManager
{
    /// <summary>
    /// 部门相关的 HTTP 请求方法类
    /// </summary>
    public class DepHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static bool AddDepartment(Department department)
        {
            var result = Post<Department>(UrlConfig.DEP_ADDDEP, department);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static bool DeleteDepartment(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.DEP_DELETEDEP, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 更改部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static bool UpdateDepartment(Department department)
        {
            var result = Put<Department>(UrlConfig.DEP_UPDATEDEP, department);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 获取单个部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Department GetDepartment(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result_str = Get(UrlConfig.DEP_GETDEP, data);
            var result_dep = StrToObject<Department>(result_str); // 反序列化
            return result_dep;
        }

        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Department> GetAllDepartment()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.DEP_GETAllDEP, data);
            var result_dep = StrToObject<PageRequest<Department>>(result_str);
            return result_dep;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="depName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static PageRequest<Department> GetDepartments(string depName, string status)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["depName"] = depName;
            data["status"] = status;
            var result_str = Get(UrlConfig.DEP_GETDEPS, data);
            var result_deps = StrToObject<PageRequest<Department>>(result_str);
            return result_deps;
        }

    }
}
