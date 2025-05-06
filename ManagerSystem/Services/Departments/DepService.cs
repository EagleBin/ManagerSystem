using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using MySqlConnector;

namespace ManagerSystem.Services.Departments
{
    public class DepService : IDepService
    {
        public int AddDepartment(Department department)
        {
            department.insertTime = DateTime.Now;
            return MySqlHelper<Department>.GetInstance().CurrentDb.Insert(department) ? 1 : 0;
        }

        public int DeleteDepartment(int departmentId)
        {
            return MySqlHelper<Department>.GetInstance().CurrentDb.DeleteById(departmentId) ? 1 : 0;
        }

        public PageRequest<Department> GetAllDepartments()
        {
            List<Department> deps = MySqlHelper<Department>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Department> { items = deps, TotalCount = deps.Count };
        }

        public Department GetDepartment(int departmentId)
        {
            return MySqlHelper<Department>.GetInstance().CurrentDb.GetById(departmentId);
        }

        public int UpdateDepartment(Department department)
        {
            return MySqlHelper<Department>.GetInstance().CurrentDb.Update(department) ? 1 : 0;
        }

        public PageRequest<Department> GetDepartments(string? depName, string? status)
        {
            int TotalCount = 0;
            List<Department> deps = MySqlHelper<Department>.GetInstance().Db.Queryable<Department>()
                .WhereIF(!string.IsNullOrEmpty(depName), t => t.DepName.Contains(depName ?? ""))
                .WhereIF(!string.IsNullOrEmpty(status), t => t.Status == ((status ?? "").Contains("启用") ? true : false))
                .ToList();
            return new PageRequest<Department>() { TotalCount = TotalCount, items = deps };
        }
    }
}
