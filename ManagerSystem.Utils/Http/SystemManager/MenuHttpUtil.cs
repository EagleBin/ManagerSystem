using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Http.SystemManager
{
    public class MenuHttpUtil : HttpUtil
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static bool AddMenu(Menu menu)
        {
            var result = Post(UrlConfig.MENU_ADDMENU, menu);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static bool DeleteMenu(int id)
        {
            Dictionary<string,string> data  = new Dictionary<string,string>();
            data["id"] = id.ToString();
            var result = Delete(UrlConfig.MENU_DELETEMENU, data);
            return int.Parse(result) != 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static bool UpdateMenu(Menu menu)
        {
            var result = Put<Menu>(UrlConfig.MENU_UPDATEMENU, menu);
            return int.Parse(result)!= 0;
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Menu GetMenu(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id.ToString();
            var result_str = Get(UrlConfig.MENU_GETMENU, data);
            var result_menu = StrToObject<Menu>(result_str);
            return result_menu;
        }
        
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public static PageRequest<Menu> GetAllMenu()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            var result_str = Get(UrlConfig.MENU_GETAllMENU, data);
            var result_menus = StrToObject<PageRequest<Menu>>(result_str);
            return result_menus;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static PageRequest<Menu> GetMenus(string title, string status)
        {
            Dictionary<string,object> data = new Dictionary<string,object>();
            data["title"] = title;
            data["status"] = status;
            var result_str = Get(UrlConfig.MENU_GETMENUS, data);
            var result_menus = StrToObject<PageRequest<Menu>>(result_str);
            return result_menus;
        }
    }
}
