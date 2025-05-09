using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.SystemManager
{
    /// <summary>
    /// 部门
    /// </summary>
    [SugarTable("department")] // C# 类和数据库表进行映射, department代表数据库里对应的表名
    public class Department : ModelBase
    {

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string DepHead { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string DepPhoneNum { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string DepMail { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 父部门ID
        /// </summary>
        public int parent_id { get; set; }

    }
}
