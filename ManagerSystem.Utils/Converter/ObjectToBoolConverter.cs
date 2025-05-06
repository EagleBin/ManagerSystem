using ManagerSystem.Entity.Dto;
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
    /// Object转bool类
    /// </summary>
    public class ObjectToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            string type = parameter.ToString();
            switch (type)
            {
                case "EditBtnEnabled":
                    {
                        if (value is List<UserDto> userList)
                        {
                            return result = (userList.Count == 1);
                        }
                        else if (value is List<PostDto> postList)
                        {
                            return result = (postList.Count == 1);
                        }
                        else if (value is List<RoleDto> roleList)
                        {
                            return result = (roleList.Count == 1);
                        }
                    }
                    break;
                case "man":
                    {
                        if (value is string gender)
                        {
                            return result = (gender == "男");
                        }
                    }
                    break;
                case "woment":
                    {
                        if (value is string gender)
                        {
                            return result = (gender == "女");
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
