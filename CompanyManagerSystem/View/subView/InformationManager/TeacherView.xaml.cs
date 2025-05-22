using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
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

namespace CompanyManagerSystem.View.subView.InformationManager
{
    /// <summary>
    /// TeacherViewm.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherView : UserControl
    {
        public TeacherView()
        {
            InitializeComponent();

            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            Messenger.Default.Send<List<TeacherDto>>(dataGrid.SelectedItems.Cast<TeacherDto>().ToList(), "SeletedTeacherList");
        }
    }
}
