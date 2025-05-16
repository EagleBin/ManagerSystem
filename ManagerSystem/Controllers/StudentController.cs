using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Services;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http.InformationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private Logger<StudentController> _logger;
        private IStudentService _studentService;
        public StudentController(Logger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost]
        public int AddStudent(Students student)
        {
            return _studentService.AddStudent(student);
        }

        [HttpDelete]
        public int DeleteStudent(int studentId)
        {
            return _studentService.DeleteStudent(studentId);
        }

        [HttpPut]
        public int UpdateStudent(Students student)
        {
            return _studentService.UpdateStudent(student);
        }

        [HttpGet]
        public Students GetStudent(int studentId)
        {
            return _studentService.GetStudent(studentId);
        }

        [HttpGet]
        public PageRequest<Students> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }

        [HttpGet]
        public PageRequest<Students> GetStudents(string? studentName, string? gender, int classId, int PerPageNum, int PageSize)
        {
            return _studentService.GetStudents(studentName, gender, classId, PerPageNum, PageSize);
        }
    }
}
