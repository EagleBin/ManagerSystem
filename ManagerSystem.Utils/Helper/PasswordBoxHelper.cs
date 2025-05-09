using System.Windows;
using System.Windows.Controls;

namespace ManagerSystem.Utils.Helper
{
    public class PasswordBoxHelper
    {

        #region PasswordBox密码

        // 用于绑定 PasswordBox 的密码。
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        /// <summary>
        /// 附加属性值改变，就会触发
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= PasswordChanged; // 移除PasswordChanged事件，防止在设置密码值时触发事件
                if (!(bool)GetIsUpdating(passwordBox)) // 判断是否正在更新密码
                {
                    passwordBox.Password = (string)e.NewValue;
                }
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }




        #endregion

        #region 是否附加 PasswordChanged 事件处理程序

        // 用于控制是否为 PasswordBox 附加 PasswordChanged 事件处理程序
        public static bool GetAttach(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachProperty, value);
        }

        // Using a DependencyProperty as the backing store for Attach.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, Attach));

        private static void Attach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            if (passwordBox == null)
            {
                return;
            }

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }
            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        #endregion

        #region 用于标记密码是否正在更新

        // 这是一个私有附加属性，用于标记密码是否正在更新，避免事件处理时的循环调用。
        public static bool GetIsUpdating(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatingProperty);
        }

        public static void SetIsUpdating(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatingProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsUpdating.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordBoxHelper));


        #endregion

        //在 PasswordBox 中输入或删除字符，会执行 PasswordChanged 方法。
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true); // 密码正在更新，避免循环调用
            SetPassword(passwordBox, passwordBox.Password); // 将Password控件的密码设置到passwordBox.Password附加属性中，附加属性值改变，进而触发其他事件
            SetIsUpdating(passwordBox, false); // 密码更新完成
        }
    }
}
