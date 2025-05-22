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
    /// 教师类型 的转换
    /// </summary>
    public class TeacherTypeConverter : IValueConverter
    {
        // 后端值 -》 前端显示（int->string）
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int teacherTypeInt = (int)value;
            string teacherTypeStr = string.Empty;
            teacherTypeStr = (teacherTypeInt == 0) ? "班主任" : (teacherTypeInt == 1) ? "普通教师" : "全部";
            return teacherTypeStr;
        }

        // 前端显示-》后端值(string->int)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string teacherTypeStr = value.ToString();
            int teacherTypeInt = 0;
            teacherTypeInt = (teacherTypeStr == "班主任") ? 0 : (teacherTypeStr == "普通教师") ? 1 : 2;
            return teacherTypeInt;
        }
    }
}
