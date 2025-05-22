using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Http.InformationManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ManagerSystem.Utils.Converter
{
    /// <summary>
    /// 班级Id 与 班级姓名 的转换
    /// </summary>
    public class ClassIdConverter : IValueConverter
    {
        // 后端数据->前端值 (int -> string)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int classId = (int)value;
            string className = string.Empty;
            Classes result = ClassHttpUtil.GetClass(classId);
            if (result != null)
            {
                className = result.Name;
                return className;
            }
            else
            {
                return null;
            }
        }

        // 前端值->后端数据(string->int)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
