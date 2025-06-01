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
    public class StudentConverter : IValueConverter
    {
        // 后端数据->前端值
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int Id = (int)value;
            string Name = string.Empty;
            var student = StudentHttpUtil.GetStudent(Id);
            if (student ==null)
            {
                return null;
            }
            Name = student.Name;
            return Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null ;
        }
    }
}
