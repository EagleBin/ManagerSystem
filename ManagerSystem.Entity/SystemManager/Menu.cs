using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.SystemManager
{
    public class Menu:ModelBase
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
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string Icon { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status{ get; set; }
        /// <summary>
        /// 父节点
        /// </summary>

        public int parent_Id { get; set; }

    }
}
