using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// StudentInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class StudentInfoDialog : UserControl
    {
        public StudentInfoDialog()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StudentName_LostFocus(sender, e);
            Gender_LostFocus(sender, e);
            Classes_LostFocus(sender, e);
        }



        private void StudentName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(StudentName.Text))
            {
                StudentName.Text = "";
            }
        }
        /// <summary>
        /// 姓名框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(StudentName.Text))
            {
                StudentName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                StudentNameInfo.Visibility = Visibility.Visible;
            }
            else
            {
                StudentName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                StudentNameInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Gender_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Gender.Text))
            {
                Gender.Text = "";
            }
        }
        /// <summary>
        /// 性别框失去交点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gender_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Gender.Text))
            {
                Gender.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                GenderInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Gender.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                GenderInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Classes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Classes.Text))
            {
                Classes.Text = "";
            }
        }
        /// <summary>
        /// 班级框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Classes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Classes.Text))
            {
                Classes.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                ClassesInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Classes.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                ClassesInfo.Visibility = Visibility.Hidden;
            }
        }


    }
}
