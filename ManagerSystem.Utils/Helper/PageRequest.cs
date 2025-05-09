using System.Collections.Generic;

namespace ManagerSystem.Utils.Helper
{
    /// <summary>
    /// 数据分页泛型类，用于封装分页请求响应的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageRequest<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; } 
        /// <summary>
        /// 分页查询的结果
        /// </summary>
        public List<T> items { get; set; }
    }
}
