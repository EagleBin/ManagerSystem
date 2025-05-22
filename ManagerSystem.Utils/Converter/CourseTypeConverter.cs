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
    /// 课程类型的转换
    /// </summary>
    public class CourseTypeConverter : IValueConverter
    {
        // 后端->前端显示(int -> string)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type_Str = string.Empty;
            int type_Int = (int)value;
            switch (type_Int)
            {
                case 0:
                    type_Str = "理科";
                    break;
                case 1:
                    type_Str = "文科";
                    break;
                case 2:
                    type_Str = "普通学科";
                    break;
                default:
                    type_Str = "全部学科";
                    break;
            }
            return type_Str;
        }

        // 前端选择->后端值 (string -> int)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type_Str = (string)value;
            int type_Int = 3;
            switch (type_Str)
            {
                case "全部学科":
                    type_Int = 3;
                    break;
                case "普通学科":
                    type_Int = 2;
                    break;
                case "文科":
                    type_Int = 1;
                    break;
                case "理科":
                    type_Int = 0;
                    break;
                default:
                    type_Int = 3;
                    break;
            }
            return type_Int;

        }
    }
}
