using ManagerSystem.Data;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Menus
{
    /// <summary>
    /// 菜单操作方法类
    /// </summary>
    public class MenuService : IMenuService
    {
        public int AddMenu(Menu menu)
        {
            return MySqlHelper<Menu>.GetInstance().CurrentDb.Insert(menu) ? 1 : 0;
        }

        public int DeleteMenu(int id)
        {
            return MySqlHelper<Menu>.GetInstance().CurrentDb.DeleteById(id) ? 1 : 0;
        }

        public PageRequest<Menu> GetAllMenu()
        {
            List<Menu> menus = MySqlHelper<Menu>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Menu> { items = menus, TotalCount = menus.Count };
        }

        public Menu GetMenu(int id)
        {
           return MySqlHelper<Menu>.GetInstance().CurrentDb.GetById(id);
        }

        public PageRequest<Menu> GetMenus(string? title, string? status)
        {
            List<Menu> menus = MySqlHelper<Menu>.GetInstance().Db.Queryable<Menu>()
                .WhereIF(!string.IsNullOrEmpty(title),t=>t.Title.Contains(title??""))
                .WhereIF(!string.IsNullOrEmpty(status), t => t.Status == ((status ?? "").Contains("启用") ? true : false)).ToListAsync().Result;
            return new PageRequest<Menu> { items = menus,TotalCount = menus.Count};
        }

        public int UpdateMenu(Menu menu)
        {
            return MySqlHelper<Menu>.GetInstance().CurrentDb.Update(menu)?1:0;
        }
    }
}
