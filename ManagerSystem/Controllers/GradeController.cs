using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Services.InformationManage.Grades;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Reflection.Metadata.Ecma335;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {

        private readonly ILogger<GradeController> _logger;
        private readonly IGradeService _gradeService;

        public GradeController(ILogger<GradeController> logger, IGradeService gradeService)
        {
            _logger = logger;
            _gradeService = gradeService;
        }


        [HttpPost]
        public int AddGrade(Grades grade)
        {
            return _gradeService.AddGrade(grade);
        }

        [HttpDelete]
        public int DeleteGrade(int gradeId)
        {
            return _gradeService.DeleteGrade(gradeId);
        }

        [HttpPut]
        public int UpdateGrade(Grades grade)
        {
            return _gradeService.UpdateGrade(grade);
        }

        [HttpGet]
        public Grades GetGrade(int id)
        {
            return _gradeService.GetGrade(id);
        }

        [HttpGet]
        public PageRequest<Grades> GetAllGrade()
        {
            return _gradeService.GetAllGrade();
        }

        [HttpGet]
        public PageRequest<Grades> GetGrades(string? Name, int PerPageNum, int PageSize)
        {
            return _gradeService.GetGrades(Name, PerPageNum, PageSize);
        }

        [HttpGet]
        public bool ExistName(string Name)
        {
            return _gradeService.ExistName(Name);
        }

        [HttpGet]
        public Entity.InformationManager.Grades GetGradeByName(string Name)
        {
            return _gradeService.GetGradeByName(Name);
        }
    }
}
