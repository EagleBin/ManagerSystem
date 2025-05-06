using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Roles
{
    public class RoleService : IRoleService
    {
        public int AddRole(Role role)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.Insert(role) ? 1 : 0;
        }

        public int AddRoleMenu(RoleMenu roleMenu)
        {
            return MySqlHelper<RoleMenu>.GetInstance().CurrentDb.Insert(roleMenu) ? 1 : 0;
        }

        public int DeleteRole(int id)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public int DeleteRoleMenu(int role_id, int menu_id)
        {
            // ExecuteCommand() 方法用于执行前面构建的删除操作，并返回受影响的记录行数。
            return MySqlHelper<RoleMenu>.GetInstance().Db.Deleteable<RoleMenu>().Where(t => t.role_Id == role_id && t.memu_Id == menu_id).ExecuteCommand();
        }

        public int ExistRoleName(string roleName)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.GetSingleAsync(r => r.RoleName == roleName).Result != null ? 1 : 0;
        }

        public PageRequest<Role> GetAllRole()
        {
            List<Role> roleList = MySqlHelper<Role>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Role> { items = roleList, TotalCount = roleList.Count };
        }

        public Role GetRole(int id)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Menu> GetRoleMenu(int id)
        {
            List<Menu> roleMenuList = MySqlHelper<Menu>.GetInstance().Db.Queryable<RoleMenu>().
                LeftJoin<Menu>((rm, m) => rm.memu_Id == m.Id).
                Where(rm => rm.role_Id == id).Select((rm, m) => m).ToList();
            return new PageRequest<Menu> { items = roleMenuList, TotalCount = roleMenuList.Count };
        }

        public PageRequest<Role> GetRoles(string? roleName, string? status, string? startDate, string? endDate, int pageNum, int pageSize)
        {
            int TotalCount = 0;
            DateTime StartDate = DateTime.Parse(startDate ?? DateTime.MinValue.ToShortDateString()).Date;
            DateTime EndDate = DateTime.Parse(endDate ?? DateTime.MaxValue.ToShortDateString()).Date;
            List<Role> roles = MySqlHelper<Role>.GetInstance().Db.Queryable<Role>()
                .WhereIF(!string.IsNullOrEmpty(roleName), t => t.RoleName.Contains(roleName ?? ""))
                .WhereIF(!string.IsNullOrEmpty(status), t => t.Status == ((status ?? "").Contains("启用") ? true : false))
                .WhereIF(!string.IsNullOrEmpty(startDate), t => t.insertTime.Date >= StartDate)
                .WhereIF(!string.IsNullOrEmpty(endDate), t => t.insertTime.Date <= EndDate)
                .ToPageList(pageNum, pageSize, ref TotalCount);
            return new PageRequest<Role>() { TotalCount = TotalCount, items = roles };
        }

        public int UpdateRole(Role role)
        {
            return MySqlHelper<Role>.GetInstance().CurrentDb.Update(role) ? 1 : 0;
        }
    }
}
