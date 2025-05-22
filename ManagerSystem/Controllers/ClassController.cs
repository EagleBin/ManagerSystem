using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Services.InformationManage.Classes;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ILogger<ClassController> _logger;
        private readonly IClassService _classService;

        public ClassController(ILogger<ClassController> logger, IClassService classService)
        {
            _logger = logger;
            _classService = classService;
        }

        [HttpPost]
        public int AddClass(Classes _class)
        {
            return _classService.AddClass(_class);
        }

        [HttpPost]
        public int AddTeachers_Classes(Teachers_Classes tclass)
        {
            return _classService.AddTeachers_Classes(tclass);
        }

        [HttpDelete]
        public int DeleteClass(int classId)
        {
            return _classService.DeleteClass(classId);
        }

        [HttpPut]
        public int UpdateClass(Classes _class)
        {
            return _classService.UpdateClass(_class);
        }

        [HttpGet]
        public Classes GetClass(int Id)
        {
            return _classService.GetClass(Id);
        }

        [HttpGet]
        public Classes GetClassByName(string Name)
        {
            return _classService.GetClassByName(Name);
        }

        [HttpGet]
        public PageRequest<Classes> GetAllClass()
        {
            return _classService.GetAllClass();
        }

        [HttpGet]
        public PageRequest<Classes> GetClasses(string? Name, string? GradeId,int ClassType, int PerPageNum, int PageSize)
        {
            return _classService.GetClasss(Name, GradeId, ClassType, PerPageNum, PageSize);
        }
    }
}
