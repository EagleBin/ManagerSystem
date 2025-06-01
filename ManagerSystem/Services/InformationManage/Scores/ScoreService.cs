using ManagerSystem.Data;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Printing;

namespace ManagerSystem.Services.InformationManage.Scores
{
    public class ScoreService : IScoreService
    {
        public int AddScore(Entity.InformationManager.Scores score)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.AsInsertable(score).ExecuteReturnIdentity();
        }

        public int DeleteScore(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.DeleteById(Id) ? 1 : 0;
        }

        public PageRequest<Entity.InformationManager.Scores> GetAllScore()
        {
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.GetListAsync().Result;
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = list.Count };

        }

        public Entity.InformationManager.Scores GetScore(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.GetById(Id);
        }

        public PageRequest<Entity.InformationManager.Scores> GetScoreByStudentName(string Name, int PerPageNum, int PageSize)
        {
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().Db.Queryable<Entity.InformationManager.Scores>()
                        .LeftJoin<Entity.InformationManager.Students>((score, student) => score.StudentId == student.Id) // 左连接-学生
                        .WhereIF(!(string.IsNullOrEmpty(Name)), (score, student) => student.Name == Name)
                        .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = totalCount };
        }

        public PageRequest<Entity.InformationManager.Scores> GetScoreByCourse(string? Name, int PerPageNum, int PageSize)
        {
            
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().Db.Queryable<Entity.InformationManager.Scores>()
                        .LeftJoin<Entity.InformationManager.Courses>((score, course) => score.StudentId == course.Id) // 左连接-学生
                        .WhereIF(!(string.IsNullOrEmpty(Name)), (score, course)=>course.Name == Name)
                        .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = totalCount };
        }

        public Entity.InformationManager.Scores GetScoreByStuAndCourse(int StudentId, int CourseId, int ExamId)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.GetSingleAsync(s => s.StudentId == StudentId && s.CourseId == CourseId && s.ExamId == ExamId).Result;
        }

        public PageRequest<Entity.InformationManager.Scores> GetScoresSingle(string? Number, string? StudentName,string? CourseName, string? ClassName,string? GradeName,string? ExamName, int PerPageNum, int PageSize)
        {
           
            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().Db.Queryable<Entity.InformationManager.Scores>()
                        .LeftJoin<Entity.InformationManager.Students>((score, stu) => score.StudentId == stu.Id) // 左连接-学生
                        .LeftJoin<Entity.InformationManager.Courses>((score, stu, course) => score.CourseId == course.Id) // 左连接-课程
                        .LeftJoin<Entity.InformationManager.Classes>((score, stu, course,  classes) => score.ClassId == classes.Id) // 左连接-班级
                        .LeftJoin<Entity.InformationManager.Grades>((score, stu, course,  classes, grade) => score.GradeId == grade.Id) // 左连接-年级
                        .LeftJoin<Entity.InformationManager.Examination>((score, stu, course,  classes, grade, exam) => score.ExamId == exam.Id) // 左连接-考试
                        .WhereIF(!string.IsNullOrEmpty(Number) && int.Parse(Number) >= 0 && int.Parse(Number) <= 150, s=>s.Number == int.Parse(Number)) // 分数
                        .WhereIF(!string.IsNullOrEmpty(StudentName), (score, stu, course, classes, grade, exam) => stu.Name.Contains(StudentName??"")) // 学生名称查询
                        .WhereIF(!string.IsNullOrEmpty(CourseName), (score, stu, course, classes, grade, exam) => course.Name.Contains(CourseName ?? "")) // 课程名称查询
                        .WhereIF(!string.IsNullOrEmpty(ClassName), (score, stu, course, classes, grade, exam) => classes.Name.Contains(ClassName ?? "")) // 班级名称查询
                        .WhereIF(!string.IsNullOrEmpty(GradeName), (score, stu, course, classes, grade, exam) => grade.Name.Contains(GradeName ?? "")) // 年级名称查询
                        .WhereIF(!string.IsNullOrEmpty(ExamName), (score, stu, course, classes, grade, exam) => exam.Name.Contains(ExamName ?? "")) // 考试名称查询
                        .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = totalCount };
        }

        public PageRequest<Entity.InformationManager.Scores> GetScoresAll(string? Number, string? StudentName, string? ClassName, string? GradeName, string? ExamName, int PerPageNum, int PageSize)
        {

            int totalCount = 0;
            var list = MySqlHelper<Entity.InformationManager.Scores>.GetInstance().Db.Queryable<Entity.InformationManager.Scores>()
                        .LeftJoin<Entity.InformationManager.Students>((score, stu) => score.StudentId == stu.Id) // 左连接-学生
                        .LeftJoin<Entity.InformationManager.Classes>((score, stu, classes) => score.ClassId == classes.Id) // 左连接-班级
                        .LeftJoin<Entity.InformationManager.Grades>((score, stu, classes, grade) => score.GradeId == grade.Id) // 左连接-年级
                        .LeftJoin<Entity.InformationManager.Examination>((score, stu, classes, grade, exam) => score.ExamId == exam.Id) // 左连接-考试
                        .WhereIF(!string.IsNullOrEmpty(Number) && int.Parse(Number) >= 0 && int.Parse(Number) <= 150, s => s.Number == int.Parse(Number)) // 分数
                        .WhereIF(!string.IsNullOrEmpty(StudentName), (score, stu, classes, grade, exam) => stu.Name.Contains(StudentName ?? "")) // 学生名称查询
                        .WhereIF(!string.IsNullOrEmpty(ClassName), (score, stu, classes, grade, exam) => classes.Name.Contains(ClassName ?? "")) // 班级名称查询
                        .WhereIF(!string.IsNullOrEmpty(GradeName), (score, stu, classes, grade, exam) => grade.Name.Contains(GradeName ?? "")) // 年级名称查询
                        .WhereIF(!string.IsNullOrEmpty(ExamName), (score, stu, classes, grade, exam) => exam.Name.Contains(ExamName ?? "")) // 考试名称查询
                        .ToPageList(PerPageNum, PageSize, ref totalCount);
            return new PageRequest<Entity.InformationManager.Scores> { items = list, TotalCount = totalCount };
        }

        public int UpdateScore(Entity.InformationManager.Scores _score)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.Update(_score) ? 1 : 0;
        }

        public int DeleteAllScoreByStudent(int Id)
        {
            return MySqlHelper<Entity.InformationManager.Scores>.GetInstance().CurrentDb.AsDeleteable().Where(c => c.StudentId == Id).ExecuteCommandAsync().Result;
        }
    }
}
