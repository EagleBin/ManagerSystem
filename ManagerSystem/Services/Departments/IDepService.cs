using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Departments
{
    /// <summary>
    /// 部门数据操作接口
    /// </summary>
    public interface IDepService
    {
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int AddDepartment(Department department);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public int DeleteDepartment(int departmentId);

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int UpdateDepartment(Department department);

        /// <summary>
        ///  通过id查询部门信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department GetDepartment(int departmentId);

        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        public PageRequest<Department> GetAllDepartments();

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="depName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Department> GetDepartments(string? depName, string? status);
    }
}
