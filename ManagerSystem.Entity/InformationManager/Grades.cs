using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("grades")]
    public class Grades : ModelBase
    {
        /// <summary>
        /// 年级名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年级级别
        /// </summary>
        public int Level { get; set; }

    }
}
