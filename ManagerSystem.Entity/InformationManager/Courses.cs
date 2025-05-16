using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("courses")]
    public class Courses : ModelBase
    {
        /// <summary>
        /// 课程
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// 课程类型
        /// </summary>
        public int CourseType { get; set; }

    }
}
