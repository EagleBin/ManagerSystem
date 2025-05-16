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
    /// NoticeInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class NoticeInfoDialog : UserControl
    {
        public NoticeInfoDialog()
        {
            InitializeComponent();
        }

        
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox_LostFocus(null, null);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(noticeName.Text))
            {
                noticeName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                noticeNameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                noticeName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                noticeNameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
