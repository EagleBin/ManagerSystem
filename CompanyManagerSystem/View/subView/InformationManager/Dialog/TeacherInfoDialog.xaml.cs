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
    /// TeacherInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherInfoDialog : UserControl
    {
        public TeacherInfoDialog()
        {
            InitializeComponent();
        }


        private void TeacherNameGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (teachernameText.Text == null || teachernameText.Text == "")
            {
                teachernameText.Text = "";
            }
        }

        private void TeacherNameLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (teachernameText.Text == "")
            {
                teachernameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                teachernameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (teachernameText.Text != "")
            {
                teachernameText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                teachernameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void GtadeGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accountText.Text == null || accountText.Text == "")
            {
                accountText.Text = "";
            }
        }

        private void GradeLostFocus(object sender, System.Windows.RoutedEventArgs e)
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

        private void teacherType_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void teacherType_LostFocus(object sender, RoutedEventArgs e)
        {
            if (teacherType.Text == "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                teacherTypeInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (accountText.Text != "")
            {
                teacherType.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                teacherTypeInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void classNameList_1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (className_1.Text == "")
            {
                className_1.Text = "";
            }
        }

        private void classNameList_1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (className_1.Visibility == Visibility.Visible)
            {
                if (className_1.Text == "")
                {
                    className_1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                    classNameInfo_1.Visibility = System.Windows.Visibility.Visible;
                }
                if (className_1.Text != "")
                {
                    className_1.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                    classNameInfo_1.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void classNameList_GotFocus(object sender, RoutedEventArgs e)
        {
            if (className_2.Text == "")
            {
                className_2.Text = "";
            }
        }

        private void classNameList_LostFocus(object sender, RoutedEventArgs e)
        {
            if (className_2.Visibility == Visibility.Visible)
            {
                if (className_2.Text == "")
                {
                    className_2.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                    classNameInfo_2.Visibility = System.Windows.Visibility.Visible;
                }
                if (className_2.Text != "")
                {
                    className_2.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                    classNameInfo_2.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void hasClassName_GotFocus(object sender, RoutedEventArgs e)
        {

            if (hasClassName.Text == "")
            {
                hasClassName.Text = "";
            }
        }

        private void hasClassName_LostFocus(object sender, RoutedEventArgs e)
        {

            if (hasClassName.Visibility == Visibility.Visible)
            {
                if (hasClassName.Text == "")
                {
                    hasClassName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                    hasClassNameInfo.Visibility = System.Windows.Visibility.Visible;
                }
                if (hasClassName.Text != "")
                {
                    hasClassName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                    hasClassNameInfo.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TeacherNameGotFocus(sender, e);
            GradeLostFocus(sender, e);
            TeacherNameLostFocus(sender, e);
            teacherType_LostFocus(sender, e);
            classNameList_LostFocus(sender, e);
            hasClassName_LostFocus(sender, e);
        }

        
    }
}
