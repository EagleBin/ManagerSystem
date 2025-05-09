using GalaSoft.MvvmLight.Messaging;
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

namespace CompanyManagerSystem.View.subView.SystemManager
{
    /// <summary>
    /// PostView.xaml 的交互逻辑
    /// </summary>
    public partial class PostView : UserControl
    {
        public PostView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 列表选项发生改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as DataGrid;
            // 发送选中的项列表
            Messenger.Default.Send<List<PostDto>>(a.SelectedItems.Cast<PostDto>().ToList(), "SelectedPosts");
        }
    }
}
