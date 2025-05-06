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
    /// UserView.xaml 的交互逻辑
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 树状图中，选中某元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepTreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            Messenger.Default.Send(treeView.SelectedItem, "SelectedDepartment");
        }

        /// <summary>
        /// 表格中，选中某行数据时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            // Messenger 信息中心，可用来发送(send)和接收(Register)信息
            // send(信息内容, 信息标识)
            // 信息内容：dataGrid.SelectedItems.Cast<UserDto>().ToList()获取当前选中的行并转换成UserDto列表
            // 信息标识："SelectedUsers" 用于区分不同类型的消息
            Messenger.Default.Send(dataGrid.SelectedItems.Cast<UserDto>().ToList(), "SelectedUsers");

        }

        /// <summary>
        /// 修改用户状态（启用/禁用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender; // 获取当前按钮实例

            if (toggleButton.IsChecked == true) // 禁用
            {
                var result = HandyControl.Controls.MessageBox.Show("是否禁用当前用户", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    toggleButton.IsChecked = false;
                    // 同时修改数据库数据
                    Messenger.Default.Send(toggleButton.IsChecked.ToString(), "UncheckedUserStatus");
                }
                else
                {
                    toggleButton.IsChecked = true;
                }
            }
            else // 启用
            {
                var result = HandyControl.Controls.MessageBox.Show("是否启用当前用户", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    toggleButton.IsChecked = true;
                    // 同时修改数据库数据
                    Messenger.Default.Send(toggleButton.IsChecked.ToString(), "CheckedUserStatus");
                }
                else
                {
                    toggleButton.IsChecked = false;
                }
            }

        }
    }
}
