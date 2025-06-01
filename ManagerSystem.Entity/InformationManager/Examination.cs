using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("Examination")]
    public class Examination : ModelBase
    {
        /// <summary>
        /// 考试名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime ExamTime { get; set; }




    }
}
