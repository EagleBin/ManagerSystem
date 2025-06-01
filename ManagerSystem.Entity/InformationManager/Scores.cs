using SqlSugar;


namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("scores")]
    public class Scores : ModelBase
    {
        /// <summary>
        /// 分数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 教师ID
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 年级ID
        /// </summary>
        public int GradeId { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public int ExamId { get; set; }
    }
}
