using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Global
{
    /// <summary>
    /// 全局字典
    /// </summary>
    public class GlobalDic
    {
        /// <summary>
        /// 导航字典-存储导航页面
        /// </summary>
        public static Dictionary<string, object> pageDic = new Dictionary<string, object>();
        /// <summary>
        /// 图标字典-存储图标
        /// </summary>
        public static readonly Dictionary<string, string> iconDic = new Dictionary<string, string>()
        {
                { "ue615", "\ue615" },
                { "ue67d", "\ue67d" },
                { "ue661", "\ue661" },
                { "ue620", "\ue620" },
                { "ue601", "\ue601" },
                { "ue60d", "\ue60d" },
                { "ue63b", "\ue63b" },
                { "ue62a", "\ue62a" },
                { "ue654", "\ue654" },
                { "ue61f", "\ue61f" },
                { "ue649", "\ue649" },
                { "ue6a8", "\ue6a8" },
                { "ue604", "\ue604" },
                { "ue61e", "\ue61e" },
                { "ue63e", "\ue63e" }

        };
    }
}
