using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Services.InformationManage.Teachers;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ILogger<TeacherController> _logger;
        private ITeacherService _teacherService;
        public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost]
        public int AddTeacher(Teachers teacher)
        {
            return _teacherService.AddTeacher(teacher);
        }

        [HttpDelete]
        public int DeleteTeacher(int teacherId)
        {
            return _teacherService.DeleteTeacher(teacherId);
        }

        [HttpPut]
        public int UpdateTeacher(Teachers teacher)
        {
            return _teacherService.UpdateTeacher(teacher);
        }

        [HttpGet]
        public Teachers GetTeacher(int teacherId)
        {
            return _teacherService.GetTeacher(teacherId);
        }

        [HttpGet]
        public PageRequest<Teachers> GetAllTeacher()
        {
            return _teacherService.GetAllTeacher();
        }

        [HttpGet]
        public PageRequest<Teachers> GetTeachers(string? Name, string? Age, string? Phone, string? Subject, int IsHeadTeacher, int PageNum, int PageSize)
        {
            return _teacherService.GetTeachers(Name, Age, Phone, Subject, IsHeadTeacher, PageNum, PageSize);
        }
    }
}
