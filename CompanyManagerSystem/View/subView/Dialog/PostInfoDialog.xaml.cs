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
    /// PostInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PostInfoDialog : UserControl
    {
        public PostInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostNameGotFocus(object sender, RoutedEventArgs e)
        {
            if (postnameText.Text == null || postnameText.Text == "")
            {
                postnameText.Text = "";
            }
        }

        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostNameLostFocus(object sender, RoutedEventArgs e)
        {
            if (postnameText.Text == "")
            {
                postnameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                postnameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (postnameText.Text != "")
            {
                postnameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                postnameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PostNameLostFocus(sender, e);
        }
    }
}
