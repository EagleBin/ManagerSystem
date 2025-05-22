using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Services.InformationManage.Courses;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpPost]
        public int AddCourse(Courses course)
        {
            return _courseService.AddCourse(course);
        }

        [HttpPut]
        public int UpdateCourse(Courses course)
        {
            return _courseService.UpdateCourse(course);
        }

        [HttpDelete]
        public int DeleteCourse(int id)
        {
            return _courseService.DeleteCourse(id);
        }

        [HttpGet]
        public Courses GetCourse(int id)
        {
            return _courseService.GetCourse(id);
        }

        [HttpGet]
        public Courses GetCourseByName(string Name)
        {
            return _courseService.GetCourseByName(Name);
        }

        [HttpGet]
        public PageRequest<Courses> GetCourses(string? Name, int CourseType, int PerPageNum, int PageSize)
        {
            return _courseService.GetCourses(Name, CourseType, PerPageNum, PageSize);
        }

        [HttpGet]
        public PageRequest<Courses> GetAllCourse()
        {
            return _courseService.GetAllCourse();
        }
    }
}
