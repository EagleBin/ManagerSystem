using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
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

        [HttpPost]
        public int AddCourses_Teachers(Courses_Teachers courses_Teachers)
        {
            return _teacherService.AddCourses_Teachers(courses_Teachers);
        }

        [HttpDelete]
        public int DeleteTeacher(int Id)
        {
            return _teacherService.DeleteTeacher(Id);
        }

        [HttpDelete]
        public int DeleteCourses_Teachers(int CourseId, int TeacherId)
        {
            return _teacherService.DeleteCourses_Teachers(CourseId, TeacherId);
        }

        [HttpPut]
        public int UpdateTeacher(Teachers teacher)
        {
            return _teacherService.UpdateTeacher(teacher);
        }

        [HttpGet]
        public Teachers GetTeacher(int Id)
        {
            return _teacherService.GetTeacher(Id);
        }

        [HttpGet]
        public Teachers GetTeacherByName(string? Name)
        {
            return _teacherService.GetTeacherByName(Name);
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

        [HttpGet]
        public Courses_Teachers GetTeacher_CourseByCourse(int Id)
        {
            return _teacherService.GetTeacher_CourseByCourse(Id);
        }

        [HttpGet]
        public PageRequest<Teachers> GetTeacherByCourse(string? Name)
        {
           return _teacherService.GetTeacherByCourse(Name);
        }
    }
}
