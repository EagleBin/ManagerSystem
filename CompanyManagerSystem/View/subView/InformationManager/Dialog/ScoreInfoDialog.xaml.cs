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
    /// ScoreInfoDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreInfoDialog : UserControl
    {
        public ScoreInfoDialog()
        {
            InitializeComponent();
        }

        private void StudentName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(StudentName.Text))
            {
                StudentName.Text = "";
                
            }
        }

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

        private void Course_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Course.Text))
            {
                Course.Text = "";

            }
        }

        private void Course_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Course.Text))
            {
                Course.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                CourseInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Course.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                CourseInfo.Visibility = Visibility.Hidden;
            }
        }

        private void ScoreNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ScoreNumber.Text))
            {
                ScoreNumber.Text = "";

            }
        }
        


        private void ScoreNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ScoreNumber.Text))
            {
                ScoreNumber.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                ScoreNumberInfo.Visibility = Visibility.Visible;
            }
            else
            {
                ScoreNumber.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                ScoreNumberInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Grade_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Grade.Text))
            {
                Grade.Text = "";

            }
        }

        private void Grade_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Grade.Text))
            {
                Grade.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                GradeInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Grade.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                GradeInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Classes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Classes.Text))
            {
                Classes.Text = "";
            }
        }

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



        private void Examination_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Examination.Text))
            {
                Examination.Text = "";

            }
        }

        private void Examination_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Classes.Text))
            {
                Examination.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f56c6c"));
                ExaminationInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Examination.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
                ExaminationInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StudentName_LostFocus(sender, e);
            Course_LostFocus(sender, e);
            Grade_LostFocus(sender, e);
            ScoreNumber_LostFocus(sender, e);
            Classes_LostFocus(sender, e);
            Examination_LostFocus(sender, e);
        }
    }
}
