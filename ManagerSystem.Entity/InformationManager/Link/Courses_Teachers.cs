using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager.Link
{
    [SugarTable("courses_teachers")]
    public class Courses_Teachers : ModelBase
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 教师Id
        /// </summary>
        public int TeacherId { get; set; }
    }
}
