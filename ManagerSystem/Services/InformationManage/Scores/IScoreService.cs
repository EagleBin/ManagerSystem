using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Helper;

namespace ManagerSystem.Services.InformationManage.Scores
{
    public interface IScoreService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int AddScore(Entity.InformationManager.Scores score);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int DeleteScore(int Id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int UpdateScore(Entity.InformationManager.Scores score);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Entity.InformationManager.Scores GetScore(int Id);

        /// <summary>
        /// 根据学生姓名 获取 学生成绩
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetScoreByStudentName(string Name, int PerPageNum, int PageSize);

        /// <summary>
        /// 根据 课程名称 获取 学生成绩
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetScoreByCourse(string? Name,int PerPageNum, int PageSize);

        /// <summary>
        /// 根据学生Id,课程Id,考次Id获取单个成绩
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <param name="ExamId"></param>
        /// <returns></returns>
        public Entity.InformationManager.Scores GetScoreByStuAndCourse(int StudentId, int CourseId, int ExamId);


        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetAllScore();

        /// <summary>
        /// 全科成绩
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="StudentName"></param>
        /// <param name="ClassName"></param>
        /// <param name="GradeName"></param>
        /// <param name="ExamName"></param>
        /// <param name="PerPageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetScoresAll(string? Number, string? StudentName, string? ClassName, string? GradeName, string? ExamName, int PerPageNum, int PageSize);

        /// <summary>
        /// 单科成绩
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="StudentName"></param>
        /// <param name="CourseName"></param>
        /// <param name="ClassName"></param>
        /// <param name="GradeName"></param>
        /// <param name="ExamName"></param>
        /// <param name="PerPageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public PageRequest<Entity.InformationManager.Scores> GetScoresSingle(string? Number, string? StudentName, string? CourseName, string? ClassName, string? GradeName, string? ExamName, int PerPageNum, int PageSize);

        /// <summary>
        /// 根据学生ID删除所有相关成绩
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteAllScoreByStudent(int Id);



    }
}
