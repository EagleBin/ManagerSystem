using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("students")]
    public class Students : ModelBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别(男：1，女：2，全部：3)
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
    }
}
