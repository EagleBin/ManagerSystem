using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyManagerSystem.View.subView.Dialog
{
    /// <summary>
    /// ResetPasswordDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ResetPasswordDialog : UserControl
    {
        public ResetPasswordDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新密码输入框获获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPasswordGoFocus(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(newPassword.Password))
            //{
            //    newPassword.Password = "";
            //}
        }
        /// <summary>
        /// 新密码输入框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            // 为空显示
            if (string.IsNullOrEmpty(newPassword.Password))
            {
                this.newPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                this.newPasswordWarning.Visibility = Visibility.Visible;
            }
            // 不为空不显示
            if (!string.IsNullOrEmpty(newPassword.Password))
            {
                this.newPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                this.newPasswordWarning.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// 确认密码输入框获获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmPasswordGoFocus(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(confirmPassword.Password))
            //{
            //    confirmPassword.Password = "";
                
            //}
        }

        /// <summary>
        /// 确认密码输入框获失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            // 密码框为空
            if (string.IsNullOrEmpty(confirmPassword.Password))
            {
                this.confirmPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                this.confirmPasswordWarning.Visibility = Visibility.Visible;
                this.confirmPasswordWarning.Text = "确认密码不能为空";
            }
            // 密码框不为空
            if (!string.IsNullOrEmpty(confirmPassword.Password))
            {
                this.confirmPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                this.confirmPasswordWarning.Visibility = Visibility.Hidden;
                // 密码不一致
                if (this.confirmPassword.Password != this.newPassword.Password)
                {
                    this.confirmPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                    this.confirmPasswordWarning.Text = "新密码与确认密码不一致，请重新输入";
                    this.confirmPasswordWarning.Visibility = Visibility.Visible;
                }
            }
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ConfirmPasswordLostFocus(sender, e);
            NewPasswordLostFocus(sender, e);
        }
    }
}
