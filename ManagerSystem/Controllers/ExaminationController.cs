using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Services.InformationManage.ExaminationServices;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {

        private readonly ILogger<ExaminationController> _logger;
        private readonly IExaminationService _gradeService;

        public ExaminationController(ILogger<ExaminationController> logger, IExaminationService gradeService)
        {
            _logger = logger;
            _gradeService = gradeService;
        }


        [HttpPost]
        public int AddExamination(Examination grade)
        {
            return _gradeService.AddExamination(grade);
        }

        [HttpDelete]
        public int DeleteExamination(int gradeId)
        {
            return _gradeService.DeleteExamination(gradeId);
        }

        [HttpPut]
        public int UpdateExamination(Examination grade)
        {
            return _gradeService.UpdateExamination(grade);
        }

        [HttpGet]
        public Examination GetExamination(int id)
        {
            return _gradeService.GetExamination(id);
        }

        [HttpGet]
        public PageRequest<Examination> GetAllExamination()
        {
            return _gradeService.GetAllExamination();
        }

        [HttpGet]
        public PageRequest<Entity.InformationManager.Examination> GetExaminations(string? Name, string? ExamStartTime, string? ExamEndTime, int PerPageNum, int PageSize)
        {
            return _gradeService.GetExaminations(Name, ExamStartTime, ExamEndTime,PerPageNum, PageSize);
        }


        [HttpGet]
        public Entity.InformationManager.Examination GetExaminationByName(string Name)
        {
            return _gradeService.GetExaminationByName(Name);
        }

    }
}
