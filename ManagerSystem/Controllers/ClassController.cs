using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Services.InformationManage.Classes;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

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
        public int DeleteClass(int Id)
        {
            return _classService.DeleteClass(Id);
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
        public PageRequest<Classes> GetClassByGrade(int Id)
        {
            return _classService.GetClassByGrade(Id);
        }

        [HttpGet]
        public Classes GetClassByName(string Name)
        {
            return _classService.GetClassByName(Name);
        }


        [HttpGet]
        public PageRequest<Classes> GetClassByHeadTeacher(int Id)
        {
            return _classService.GetClassByHeadTeacher(Id);
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

        [HttpDelete]
        public int DeleteTeachers_Classes(int TeacherId, int ClassId)
        {
            return _classService.DeleteTeachers_Classes(TeacherId, ClassId);
        }

        [HttpGet]
        public Teachers_Classes GetTeachers_ClassesByClass(int ClassId)
        {
            return _classService.GetTeachers_ClassesByClass(ClassId);
        }
    }
}
