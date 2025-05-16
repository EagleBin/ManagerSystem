using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
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

namespace CompanyManagerSystem.View.subView.SystemManager
{
    /// <summary>
    /// NoticeView.xaml 的交互逻辑
    /// </summary>
    public partial class NoticeView : UserControl
    {
        public NoticeView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            // 将选到的多个行，发送到信息中心
            Messenger.Default.Send<List<NoticeDto>>(dataGrid.SelectedItems.Cast<NoticeDto>().ToList(), "SeletedNotices");
        }
    }
}
