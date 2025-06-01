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
    public class CourseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int Id = (int)value;
            string Name = string.Empty;
            var course = CourseHttpUtil.GetCourse(Id);
            if (course == null)
            {
                return null;
            }
            Name = course.Name;
            return Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
