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

namespace CompanyManagerSystem.View.subView.InformationManager.Dialog
{
    /// <summary>
    /// CourseInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CourseInfoDialog : UserControl
    {
        public CourseInfoDialog()
        {
            InitializeComponent();
        }

        private void courseType_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseType.Text))
            {
                courseType.Text = "";
            }
        }

        private void courseType_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseTypeInfo.Text))
            {
                courseType.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                courseTypeInfo.Visibility = Visibility.Visible;
            }
            else
            {
                courseType.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                courseTypeInfo.Visibility = Visibility.Hidden;
            }
        }



        private void courseName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseName.Text))
            {
                courseName.Text = "";
            }

        }

        private void courseName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseName.Text))
            {
                courseName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                courseNameInfo.Visibility = Visibility.Visible;
            }
            else
            {
                courseName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                courseNameInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            courseType_LostFocus(sender, e);
            courseName_LostFocus(sender, e);
        }
    }
}
