using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ManagerSystem.Utils.Converter
{
    public class AddOrEditClassConverter : IValueConverter
    {
        // 后端数据=>前端值
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // parameter 是前端ConverterParameter定义的值
            // value 是ViewModel中定义的属性值
            return value.Equals(parameter); // 如果相等 则 返回true
        }

        // 前端值=>后端数据
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 当被选中时，把ConverterParameter的值传给后端（ViewModel的定义的属性值）
           return  (bool)value?parameter:Binding.DoNothing;
        }
    }
}
