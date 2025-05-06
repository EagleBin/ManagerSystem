using HandyControl.Controls;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
namespace ManagerSystem.Utils.Helper
{
    public class CheckComboBoxHelper
    {
        //附加属性 SelectedItems

        public static IList GetSelectedItems(DependencyObject obj)
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }
        public static void SetSelectedItems(DependencyObject obj, IList value)
        {
            obj.SetValue(SelectedItemsProperty, value);
        }
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IEnumerable), typeof(CheckComboBoxHelper), new PropertyMetadata(null, OnSelectedItemsChanged));

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
            var dataSource = GetSelectedItems(sender as DependencyObject);
            // 添加用户选中的项
            foreach (var item in e.AddedItems)
            {
                dataSource.Add(item);
            }
            // 删除用户取消选中的项
            foreach (var item in e.RemovedItems)
            {
                dataSource.Remove(item);
            }
        }




        //// 附加属性 SelectedItems
        //public static IList GetSelectedItems(DependencyObject obj)
        //{
        //    return (IList)obj.GetValue(SelectedItemsProperty);
        //}

        //public static void SetSelectedItems(DependencyObject obj, IList value)
        //{
        //    obj.SetValue(SelectedItemsProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedItemsProperty =
        //    DependencyProperty.RegisterAttached("SelectedItems", typeof(IEnumerable), typeof(CheckComboBoxHelper), new PropertyMetadata(null, OnSelectedItemsChanged));

        //private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CheckComboBox cbox)
        //    {
        //        if (e.OldValue != null)
        //        {
        //            // 移除 SelectionChanged 事件处理程序
        //            cbox.SelectionChanged -= OnSelectionChanged;
        //        }
        //        //若新值是 IList 类型，则清空 CheckComboBox 的选中项列表，然后将新值中的项添加到选中项列表中。
        //        if (e.NewValue is IList list)
        //        {
        //            cbox.SelectedItems.Clear();

        //            if (list != null)
        //            {
        //                foreach (object item in list)
        //                {
        //                    cbox.SelectedItems.Add(item);
        //                }
        //                cbox.OnApplyTemplate();
        //                cbox.SelectionChanged += OnSelectionChanged;
        //            }
        //        }
        //    }
        //}

        //private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var dataSource = GetSelectedItems(sender as DependencyObject);
        //    // 添加用户选中的项
        //    foreach (var item in e.AddedItems)
        //    {
        //        dataSource.Add(item);
        //    }
        //    // 删除用户选中的项
        //    foreach (var item in e.RemovedItems)
        //    {
        //        dataSource.Remove(item);
        //    }
        //}
    }
}
