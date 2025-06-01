using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Services.InformationManage.Scores;
using ManagerSystem.Utils.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ManagerSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {

        private readonly ILogger<ScoreController> _logger;
        private readonly IScoreService _scoreService;

        public ScoreController(ILogger<ScoreController> logger, IScoreService scoreService)
        {
            _logger = logger;
            _scoreService = scoreService;
        }

        [HttpPost]
        public int AddScore(Scores scores)
        {
            return _scoreService.AddScore(scores);
        }

        [HttpPut]
        public int UpdateScore(Scores scores)
        {
            return _scoreService.UpdateScore(scores);
        }

        [HttpDelete]
        public int DeleteScore(int Id)
        {
            return _scoreService.DeleteScore(Id);
        }

        [HttpDelete]
        public int DeleteAllScoreByStudent(int Id)
        {
            return _scoreService.DeleteAllScoreByStudent(Id);
        }

        [HttpGet]
        public Scores GetScore(int Id)
        {
           return  _scoreService.GetScore(Id);
        }

        [HttpGet]
        public Scores GetScoreByStuAndCourse(int StudentId, int CourseId, int ExamId)
        {
            return _scoreService.GetScoreByStuAndCourse(StudentId, CourseId, ExamId);
        }

        [HttpGet]
        public PageRequest<Scores> GetAllScore()
        {
            return _scoreService.GetAllScore();
        }

        [HttpGet]
        public PageRequest<Entity.InformationManager.Scores> GetScoresAll(string? Number, string? StudentName, string? ClassName, string? GradeName, string? ExamName, int PerPageNum, int PageSize)
        {
            return _scoreService.GetScoresAll(Number, StudentName, ClassName, GradeName, ExamName, PerPageNum, PageSize);
        }

        [HttpGet]
        public PageRequest<Entity.InformationManager.Scores> GetScoresSingle(string? Number, string? StudentName, string? CourseName, string? ClassName, string? GradeName, string? ExamName, int PerPageNum, int PageSize)
        {
            return _scoreService.GetScoresSingle(Number, StudentName,CourseName, ClassName, GradeName, ExamName, PerPageNum, PageSize);
        }

        [HttpGet]
        public PageRequest<Scores> GetScoreByCourse(string? Name, int PerPageNum, int PageSize)
        {
            return _scoreService.GetScoreByCourse(Name, PerPageNum, PageSize);
        }

    }
}
