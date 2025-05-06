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
    /// UserInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoDialog : UserControl
    {
        public UserInfoDialog()
        {
            InitializeComponent();
            this.passwordText.Password = "";
        }

        private void UserNameGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (usernameText.Text == null || usernameText.Text == "")
            {
                usernameText.Text = "";
            }
        }

        private void UserNameLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (usernameText.Text == "")
            {
                usernameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                usernameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (usernameText.Text != "")
            {
                usernameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                usernameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void AccountGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accountText.Text == null || accountText.Text == "")
            {
                accountText.Text = "";
            }
        }

        private void AccountLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accountText.Text == "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                accountInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (accountText.Text != "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                accountInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void PasswordGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (passwordText.Password == null || passwordText.Password == "")
            {
                passwordText.Password = "";
            }
            var items = this.roleCheckComboBox.SelectedItems;
        }

        private void PasswordLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (passwordText.Password == "")
            {
                passwordText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                passwordInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (passwordText.Password != "")
            {
                passwordText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                passwordInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            roleCheckComboBox.IsDropDownOpen = true;
            postCheckComboBox.IsDropDownOpen = true;
            roleCheckComboBox.IsDropDownOpen = false;
            postCheckComboBox.IsDropDownOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserNameLostFocus(sender, e);
            AccountLostFocus(sender, e);
            PasswordLostFocus(sender, e);
        }
    }
}
