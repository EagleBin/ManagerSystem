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
        /// <summary> 
        /// object->bool 将数据源的值转换成 视图显示的值
        /// </summary>
        /// <param name="value">需要转换的原始对象</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数（转换规则）</param>
        /// <param name="culture">特定的文化转换</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            string type = parameter.ToString();
            switch (type)
            {
                // 用于判断编辑按钮是否可用，只有当选中一个元素时，编辑按钮才应该可用。
                case "EditBtnEnabled":
                    {
                        if (value is List<UserDto> userList)
                        {
                            result = (userList.Count == 1);
                        }
                        else if (value is List<PostDto> postList)
                        {
                            result = (postList.Count == 1);
                        }
                        else if (value is List<RoleDto> roleList)
                        {
                            result = (roleList.Count == 1);
                        }
                    }
                    break;
                    // 判断性别
                case "man":
                    {
                        if (value is string gender)
                        {
                            result = (gender == "男");
                        }
                    }
                    break;
                case "woment":
                    {
                        if (value is string gender)
                        {
                            result = (gender == "女");
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// bool->object 将视图中用户输入的值转换成 数据源值
        /// </summary>
        /// <param name="value">需要反向转换的布尔值</param>
        /// <param name="targetType">反向转换后的目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">特定的文化转换</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
