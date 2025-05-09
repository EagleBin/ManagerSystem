using SqlSugar;
using System;

namespace ManagerSystem.Entity
{
    /// <summary>
    /// 模型通用继承类。定义主键、插入时间和克隆方法
    /// </summary>
    public class ModelBase : ICloneable
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity = true)] //主键且自增
        public int Id { get; set; }

        public DateTime insertTime { get; set; }

        /// <summary>
        /// 克隆(提供副本)
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone(); // 克隆功能
        }
    }
}
