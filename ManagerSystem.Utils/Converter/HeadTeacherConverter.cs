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
    /// 班主任Id 与 班主任姓名 的转换
    /// </summary>
    public class HeadTeacherConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int teacherId = (int)value;
            string teacherName = string.Empty;
            var teacher = TeacherHttpUtil.GetTeacher(teacherId);
            if (teacher == null)
            {
                teacherName = "无";
                return teacherName;
            }
            teacherName = teacher.Name;
            return teacherName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
