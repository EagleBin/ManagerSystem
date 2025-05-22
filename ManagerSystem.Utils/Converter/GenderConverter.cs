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
    /// 性别 的转换
    /// </summary>
    public class GenderConverter : IValueConverter
    {
        // 后端数据->前端值
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string genderStr = string.Empty;
            int genderInt = (int)value;
            switch (genderInt)
            {
                case 1:
                    genderStr = "男";
                    break;
                case 2:
                    genderStr = "女";
                    break;
                default:
                    genderStr = "全部";
                    break;
            }
            return genderStr;
        }

        // 前端值 -> 后端数据 (string -> int)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string genderStr = (string)value;
            int genderInt = 0;
            switch (genderStr)
            {
                case "男":
                    genderInt = 1;
                    break;
                case "女":
                    genderInt = 2;
                    break;
                default:
                    genderInt = 3;
                    break;
            }
            return genderInt;

        }
    }
}
