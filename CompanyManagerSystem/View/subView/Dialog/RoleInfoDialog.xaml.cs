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
    /// RoleInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class RoleInfoDialog : UserControl
    {
        public RoleInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleNameLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (rolenameText.Text == "")
            {
                rolenameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                rolenameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (rolenameText.Text != "")
            {
                rolenameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                rolenameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoleNameLostFocus(sender, e);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RoleNameLostFocus(sender, e);
        }
    }
}
