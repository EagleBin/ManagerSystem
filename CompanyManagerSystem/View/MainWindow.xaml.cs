using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CompanyManagerSystem.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 事件添加
            // 窗体移动
            this.top.MouseLeftButtonDown += (sender, e) =>
            {
                DragMove();
            };
            // 最小化
            this.MinBtn.Click += (o, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            // 最大化及标准化
            this.MaxBtn.Click += (o, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };
            // 关闭
            this.CloseBtn.Click += (o, e) =>
            {
                var result = HandyControl.Controls.MessageBox.Show("是否退出系统", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            };

            // 鼠标接触关闭按钮
            this.CloseBtn.MouseEnter += (o, e) =>
            {
                this.closePath.Fill = new SolidColorBrush((Colors.White));
            };
            this.CloseBtn.MouseLeave += (o, e) =>
            {
                this.closePath.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#494949"));
            };
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            photoComboBox.IsDropDownOpen = false;
        }

        private bool _isMaximized = false; // 默认标准化

        private void top_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (_isMaximized) // 如果是最大化
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1420;
                    this.Height = 700;
                    _isMaximized = false;
                }
                else // 如果是标准化
                {
                    this.WindowState = WindowState.Maximized;
                    this._isMaximized = true;
                }
            }
        }
    }
}
