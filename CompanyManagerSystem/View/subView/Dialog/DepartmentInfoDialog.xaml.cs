using ManagerSystem.Entity.Dto;
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
    /// DepartmentInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentInfoDialog : UserControl
    {
        public DepartmentInfoDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParentDepartmentLostFocus(sender, e);
            DepNameLostFocus(sender, e);
        }

        private void ParentDepartmentGotFocus(object sender, RoutedEventArgs e)
        {
            //if (((DepartmentDto)parentDepartmentText.SelectedItem).Department.id == 0)
            //{
            //    parentDepartmentText.SelectedItem = null;
            //}
        }

        private void ParentDepartmentLostFocus(object sender, RoutedEventArgs e)
        {
            if (((DepartmentDto)parentDepartmentText.SelectedItem).Department != null &&
                ((DepartmentDto)parentDepartmentText.SelectedItem).Department.Id == 0)
            {
                parentDepartmentText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                parentDepartmentInfo.Visibility = Visibility.Visible;
            }
            if (((DepartmentDto)parentDepartmentText.SelectedItem).Department == null
                || ((DepartmentDto)parentDepartmentText.SelectedItem).Department.Id != 0)
            {
                parentDepartmentText.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                parentDepartmentInfo.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void DepNameGotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(depNameText.Text))
            {
                depNameText.Text = "";
            }
        }

        private void DepNameLostFocus(object sender, RoutedEventArgs e)
        {
            if (depNameText.Text == "")
            {
                depNameText.BorderBrush = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#f56c6c"));
                depNameInfo.Visibility = System.Windows.Visibility.Visible;
            }
            if (depNameText.Text != "")
            {
                depNameText.BorderBrush = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#E0E0E0"));
                depNameInfo.Visibility = System.Windows.Visibility.Hidden;
            }
}

    }
}
