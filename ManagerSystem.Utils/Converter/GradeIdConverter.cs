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
    public class GradeIdConverter : IValueConverter
    {
        // 数据源->前端显示
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int gradeId = (int)value;
            string gradeName = string.Empty;
            var grade = GradeHttpUtil.GetGrade(gradeId);
            if(grade == null) return null;
            gradeName = grade.Name;
            return gradeName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gradeName = value.ToString();
            int gradeId = 0;
            var grade = GradeHttpUtil.GetGradeByName(gradeName);
            if (grade == null) return null;
            gradeId = grade.Id;
            return gradeId;
            //return null;
        }
    }
}
