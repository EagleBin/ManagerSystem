using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.Menus
{
    /// <summary>
    /// 菜单数据操作接口
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int AddMenu(Menu menu);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int DeleteMenu(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int UpdateMenu(Menu menu);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetMenu(int id);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Menu> GetAllMenu();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public PageRequest<Menu> GetMenus(string? title, string? status);
    }
}
