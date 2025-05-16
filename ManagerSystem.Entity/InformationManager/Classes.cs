using SqlSugar;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("classes")]
    public class Classes:ModelBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 班级类型（文科班Art，理科班）
        /// </summary>
        public int ClassType { get; set; }
        /// <summary>
        /// 班主任编号
        /// </summary>
        public int HeadTeacher_Id { get; set; }
        /// <summary>
        /// 年级编号
        /// </summary>
        public int GradeId { get; set; }
    }
}
