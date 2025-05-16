using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Global;
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
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ClassId"] = value;
            var result_str = ClassHttpUtil.Get(UrlConfig.CLA_GETCLA,data);
            var result_obj = HttpUtil.StrToObject<Classes>(result_str);
            return result_obj.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
