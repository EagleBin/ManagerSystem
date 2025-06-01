using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Helper
{
    /// <summary>
    /// 数字校验类
    /// </summary>
    public class NumberValidator
    {
        /// <summary>
        /// 验证整数是否在指定范围内
        /// </summary>
        /// <param name="value">要验证的整数</param>
        /// <param name="min">最小值（包含）</param>
        /// <param name="max">最大值（包含）</param>
        /// <returns>如果在范围内返回true，否则返回false</returns>
        public static bool IsInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// 验证长整数是否在指定范围内
        /// </summary>
        public static bool IsInRange(long value, long min, long max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// 验证小数是否在指定范围内
        /// </summary>
        public static bool IsInRange(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// 验证数字是否为非负数（大于等于0）
        /// </summary>
        public static bool IsNonNegative(int value)
        {
            return value >= 0;
        }

        /// <summary>
        /// 验证数字是否为非负数（大于等于0）
        /// </summary>
        public static bool IsNonNegative(long value)
        {
            return value >= 0;
        }

        /// <summary>
        /// 验证数字是否为非负数（大于等于0）
        /// </summary>
        public static bool IsNonNegative(double value)
        {
            return value >= 0;
        }

        /// <summary>
        /// 验证字符串是否可以转换为有效的整数
        /// </summary>
        public static bool IsValidInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        /// <summary>
        /// 验证字符串是否可以转换为有效的长整数
        /// </summary>
        public static bool IsValidLong(string input)
        {
            return long.TryParse(input, out _);
        }

        /// <summary>
        /// 验证字符串是否可以转换为有效的小数
        /// </summary>
        public static bool IsValidDouble(string input)
        {
            return double.TryParse(input, out _);
        }

        /// <summary>
        /// 验证字符串是否为有效的正数（整数或小数）
        /// </summary>
        public static bool IsPositiveNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (double.TryParse(input, out double result))
            {
                return result > 0;
            }

            return false;
        }

        /// <summary>
        /// 验证字符串是否为有效的非负数字（整数或小数）
        /// </summary>
        public static bool IsNonNegativeNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (double.TryParse(input, out double result))
            {
                return result >= 0;
            }

            return false;
        }

        /// <summary>
        /// 验证字符串是否为有效的整数且在指定范围内
        /// </summary>
        public static bool IsValidIntegerInRange(string input, int min, int max)
        {
            if (!int.TryParse(input, out int value))
                return false;

            return IsInRange(value, min, max);
        }

        /// <summary>
        /// 验证字符串是否为有效的小数且在指定范围内
        /// </summary>
        public static bool IsValidDoubleInRange(string input, double min, double max)
        {
            if (!double.TryParse(input, out double value))
                return false;

            return IsInRange(value, min, max);
        }


    }
}
