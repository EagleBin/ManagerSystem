using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.SystemManager;
using System.Collections.Generic;
using System.Windows;



namespace ManagerSystem.Entity.Dto
{
    /// <summary>
    /// 部门数据传输类
    /// </summary>
    public class DepartmentDto : ViewModelBase
    {
        private Department _Department = new Department();
        /// <summary>
        /// 部门类
        /// </summary>
        public Department Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
                RaisePropertyChanged(); // 用于通知视图层属性值已经更改，视图层及时刷新数据
            }


        }

        private bool _IsChecked =false;
        /// <summary>
        /// 部门是否展开或折叠
        /// </summary>
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                // Default： 默认单例模式的信息中心
                // Send<信息的类型>：发送消息
                // this：作为参数发送过去
                // "DepartmentCheckChanged"：信息的标识，用来区分不同的信息
                Messenger.Default.Send<DepartmentDto>(this, "DepartmentCheckChanged"); //用于在不同的视图模型之间进行通信
                RaisePropertyChanged();
            }
        }

        private float _MarginLeft = 0;
        /// <summary>
        /// 左边距
        /// </summary>
        public float MarginLeft
        {
            get { return _MarginLeft; }
            set { _MarginLeft = value; }
        }

        private Visibility _IsVisibility = Visibility.Collapsed;
        /// <summary>
        /// 部门展开与折叠按钮显示
        /// </summary>
        public Visibility IsVisibility
        {
            get { return _IsVisibility; }
            set
            {
                _IsVisibility = value;
                RaisePropertyChanged();
            }
        }

        private List<DepartmentDto> _ChildDepartmentList;
        /// <summary>
        /// 子部门列表
        /// </summary>
        public List<DepartmentDto> ChildDepartmentList
        {
            get { return _ChildDepartmentList; }
            set
            {
                _ChildDepartmentList = value;
                RaisePropertyChanged();
            }
        }




    }
}
