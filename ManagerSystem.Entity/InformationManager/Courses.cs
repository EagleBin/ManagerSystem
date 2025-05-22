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
        /// 课程类型(理科0；文科1；其他课程(语数英，体育音乐)2)
        /// </summary>
        public int CourseType { get; set; }

    }
}
