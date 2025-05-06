using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity
{
    public class ModelBase : ICloneable
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public int Id { get; set; }

        public DateTime insertTime { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
