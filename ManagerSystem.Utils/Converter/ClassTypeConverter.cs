using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ManagerSystem.Utils.Converter
{
    /// <summary>
    /// 班级类型 的转换
    /// </summary>
    public class ClassTypeConverter : IValueConverter
    {
        // 后端数据源转换为前端显示
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "全部班级";

            if (int.TryParse(value.ToString(), out int classTypeInt))
            {
                switch (classTypeInt)
                {
                    case 0:
                        return "理科班级";
                    case 1:
                        return "文科班级";
                    case 2:
                        return "全部班级";
                    default:
                        return "全部班级";
                }
            }
            return "全部班级";
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            string classType_string = value.ToString();
            int classType_int = 2;
            switch (classType_string)
            {
                case "全部班级":
                    classType_int = 2;
                    break;
                case "理科班级":
                    classType_int = 0;
                    break;
                case "文科班级":
                    classType_int = 1;
                    break;
                default:
                    break;
            }
            return classType_int;
        }
    }
}
