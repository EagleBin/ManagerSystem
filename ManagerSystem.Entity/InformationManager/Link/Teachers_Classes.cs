using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager.Link
{
    [SugarTable("teachers_classes")]
    public class Teachers_Classes : ModelBase
    {
        /// <summary>
        /// 教师Id
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public int ClassId { get; set; }
    }
}
