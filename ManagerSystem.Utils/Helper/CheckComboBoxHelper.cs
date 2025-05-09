using HandyControl.Controls;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ManagerSystem.Utils.Helper
{
    public class CheckComboBoxHelper
    {
        //附加属性 SelectedItems

        public static IList GetSelectedItems(DependencyObject obj) // 获取指定 DependencyObject 上 SelectedItems 附加属性的值 
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }
        public static void SetSelectedItems(DependencyObject obj, IList value) // 设置属性值
        {
            obj.SetValue(SelectedItemsProperty, value);
        }
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IEnumerable), typeof(CheckComboBoxHelper), new PropertyMetadata(null, OnSelectedItemsChanged));

        /// <summary>
        /// 当CheckComboBox选项改变时
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CheckComboBox cbox)
            {
                if (e.OldValue != null)
                {
                    // 移除 SelectionChanged 事件的处理程序。
                    cbox.SelectionChanged -= OnSelectionChanged;
                }
                //若新值是 IList 类型，则清空 CheckComboBox 的选中项列表，然后将新值中的项添加到选中项列表中。
                if (e.NewValue is IList list)
                {
                    cbox.SelectedItems.Clear();
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            cbox.SelectedItems.Add(item);
                        }
                        cbox.OnApplyTemplate();
                        cbox.SelectionChanged += OnSelectionChanged;
                    }
                }
            }
        }

        public static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取附加属性的值，作为外部数据源
            var dataSource = GetSelectedItems(sender as DependencyObject); 
            // 添加 用户新选中的项 到外部数据源中
            foreach (var item in e.AddedItems)
            {
                dataSource.Add(item);
            }
            // 外部数据源中 删除 用户取消选中的项
            foreach (var item in e.RemovedItems)
            {
                dataSource.Remove(item);
            }
        }
    }
}
