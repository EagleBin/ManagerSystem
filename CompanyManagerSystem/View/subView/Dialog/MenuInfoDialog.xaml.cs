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
    /// MenuInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class MenuInfoDialog : UserControl
    {
        public MenuInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 菜单名称输入框 失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox =(TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                this.menuNameWarning.Visibility = Visibility.Visible;
            }
            else
            {
                textBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                this.menuNameWarning.Visibility = Visibility.Hidden;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox_LostFocus(this.menuName, e);
        }
    }
}
