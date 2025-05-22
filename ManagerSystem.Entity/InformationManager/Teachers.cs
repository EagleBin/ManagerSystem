using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.InformationManager
{
    [SugarTable("teachers")]
    public class Teachers : ModelBase
    {
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否为班主任
        /// </summary>
        public int IsHeadTeacher { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }
}
