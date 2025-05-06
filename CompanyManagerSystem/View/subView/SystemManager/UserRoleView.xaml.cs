using GalaSoft.MvvmLight.Messaging;
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
    /// UserRoleView.xaml 的交互逻辑
    /// </summary>
    public partial class UserRoleView : UserControl
    {
        public UserRoleView()
        {
            InitializeComponent();
            Loaded += InitializeDataGrid;
        }

        private void InitializeDataGrid(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<string>(null, "GetUserRoleList");
        }
    }
}
