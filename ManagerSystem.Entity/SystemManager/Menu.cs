using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.SystemManager
{
    /// <summary>
    /// 菜单
    /// </summary>
    [SugarTable("menu")] // C#类与数据库进行映射，menu代表数据库对应的表名
    public class Menu : ModelBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)] //不会将该属性的值插入到数据库表对应的列中
        public string Icon { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int parent_Id { get; set; }

    }
}
