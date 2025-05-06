using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Menus;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MenuController : ControllerBase
    {

        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            this._logger = logger;
            this._menuService = menuService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPut]
        public int AddMenu(Menu menu)
        {
            return _menuService.AddMenu(menu);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteMenu(int id)
        {
            return _menuService.DeleteMenu(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateMenu(Menu menu)
        {
            return _menuService.UpdateMenu(menu);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Menu GetMenu(int id)
        {
            return _menuService.GetMenu(id);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Menu> GetAllMenu()
        {
            return _menuService.GetAllMenu();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Menu> GetMenus(string? title, string? status)
        {
            return _menuService.GetMenus(title, status);
        }

    }
}
