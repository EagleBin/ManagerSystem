using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Services.Departments;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepService _depService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepService depService)
        {
            this._logger = logger;
            this._depService = depService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddDepartment(Department dep)
        {
           return _depService.AddDepartment(dep);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteDepartment(int id)
        {
            return _depService.DeleteDepartment(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateDepartment(Department dep)
        {
            return _depService.UpdateDepartment(dep);
        }

        /// <summary>
        /// 查询单个部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Department GetDepartment(int id)
        {
            return _depService.GetDepartment(id);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Department> GetAllDepartment()
        {
            return _depService.GetAllDepartments();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="depName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        public PageRequest<Department> GetDepartments(string? depName, string? status)
        {
            return _depService.GetDepartments(depName, status);
        }
    }
}
