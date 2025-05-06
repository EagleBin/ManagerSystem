using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompanyManagerSystem.View
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //// 当鼠标左键在控件上按下时触发。
            //// o 是事件的发送者（即 grid 控件），e 是事件参数。
            //this.grid.MouseLeftButtonDown += (o, e) =>
            //{
            //    // 让用户能够拖动窗口
            //    DragMove();
            //};
        }

        /// <summary>
        /// 拖动窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// 左键点击窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus(); // 清除焦点
            this.textbox.Focus();
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinSizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 关闭按钮-鼠标触碰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closePath.Fill = new SolidColorBrush(Colors.White);
        }

        /// <summary>
        /// 关闭按钮-鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            // 字符转换颜色
            closePath.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#494949"));
        }

        /// <summary>
        /// 账号获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountGotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(accountText.Text))
            {
                accountText.Text = "";
            }
        }

        private void AccountLostFocus(object sender, RoutedEventArgs e)
        {
            if (accountText.Text == "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                accountInfo.Visibility = Visibility.Visible;
            }
            if (accountText.Text != "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                accountInfo.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// 密码获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordText.Password))
            {
                passwordText.Password = "";
            }
        }

        /// <summary>
        /// 密码失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordText.Password == "")
            {
                passwordText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                passwordInfo.Visibility = Visibility.Visible;
            }
            if (passwordText.Password != "")
            {
                passwordText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                passwordInfo.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// 验证获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeGotFocus(object sender, RoutedEventArgs e)
        {
            if (codeText.Text == null || codeText.Text == "")
            {
                codeText.Text = "";
            }
        }

        /// <summary>
        /// 验证码失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeLostFocus(object sender, RoutedEventArgs e)
        {
            if (codeText.Text == "")
            {
                codeText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                codeInfo.Visibility = Visibility.Visible;
            }
            if (codeText.Text != "")
            {
                codeText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                codeInfo.Visibility = Visibility.Hidden;
            }
        }


        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 失去焦点
            AccountLostFocus(sender, e);
            PasswordLostFocus(sender, e);
            CodeLostFocus(sender, e);
        }


    }
}
