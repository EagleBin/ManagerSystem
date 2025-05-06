using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Helper
{
    public class PageRequest<T>
    {
        public int TotalCount { get; set; } 

        public List<T> items { get; set; }
    }
}
