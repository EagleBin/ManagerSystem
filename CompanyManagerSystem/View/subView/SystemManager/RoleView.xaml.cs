using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// RoleView.xaml 的交互逻辑
    /// </summary>
    public partial class RoleView : UserControl
    {
        public RoleView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            // 发送 所选择的行参数 到 信息中心，在视图模型中接收
            Messenger.Default.Send(dataGrid.SelectedItems.Cast<RoleDto>().ToList(), "SelectedRoles");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
           ToggleButton toggleButton = (ToggleButton)sender;

            if (toggleButton.IsChecked == false) // 按下瞬间IsChecked为false，此时数据依旧为true，再通过判断改变数据库
            {
                var result = HandyControl.Controls.MessageBox.Show("确认要禁用该权限吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    toggleButton.IsChecked = false;
                    // 发送 参数和指令 到 信息中心，在视图模型中实现方法，将状态修改到数据中
                    Messenger.Default.Send(toggleButton.IsChecked.ToString(), "UnCheckedRoleStatus");
                }
                else
                {
                    toggleButton.IsChecked = true;
                }
            }
            else
            {
                var result = HandyControl.Controls.MessageBox.Show("确认要启用该权限吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    toggleButton.IsChecked = true;
                    Messenger.Default.Send(toggleButton.IsChecked.ToString(), "CheckedRoleStatus");
                }
                else
                {
                    toggleButton.IsChecked = false;
                }
            }

        }
    }
}
