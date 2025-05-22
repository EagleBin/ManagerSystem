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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TeacherNameGotFocus(sender, e);
            GradeLostFocus(sender, e);
            TeacherNameLostFocus(sender, e);
            classType_LostFocus(sender, e);
        }

        private void classType_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void classType_LostFocus(object sender, RoutedEventArgs e)
        {
            if (classType.Text == "")
            {
                accountText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                classTypeInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (accountText.Text != "")
            {
                classType.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                classTypeInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
