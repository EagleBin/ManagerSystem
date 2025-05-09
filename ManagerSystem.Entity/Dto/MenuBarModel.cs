using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.SystemManager;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ManagerSystem.Entity.Dto
{
    /// <summary>
    /// 菜单数据传输类
    /// </summary>
    public class MenuBarModel : ViewModelBase
    {


        private Menu _Menu = new Menu();
        /// <summary>
        /// 菜单类
        /// </summary>
        public Menu Menu
        {
            get { return _Menu; }
            set
            {
                _Menu = value;
                RaisePropertyChanged();
            }
        }


        private bool _IsExpanded =false;
        /// <summary>
        /// 菜单是否被展开
        /// </summary>
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { _IsExpanded = value;
                RaisePropertyChanged();
            }
        }


        private bool _IsChecked =false;
        /// <summary>
        /// 菜单被是否被选择
        /// </summary>
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value;
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
            set { _MarginLeft = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _IsVisibility = Visibility.Collapsed;
        /// <summary>
        /// 菜单是否可用
        /// </summary>
        public Visibility IsVisibility
        {
            get { return _IsVisibility; }
            set { _IsVisibility = value;
                RaisePropertyChanged();
            }
        }


        private List<MenuBarModel> _ChildMenuBarModel;
        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<MenuBarModel> ChildMenuBarModel
        {
            get { return _ChildMenuBarModel; }
            set { _ChildMenuBarModel = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _NavigateCommand;
        /// <summary>
        /// 导航命令（导航到指定菜单页面）
        /// </summary>
        public ICommand NavigateCommand
        {
            get
            {

                return _NavigateCommand ?? (_NavigateCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<string>(Menu.NameSpace, "NavigateView");
                    }));
            }

        }

        private ICommand _MenuExpanderExpandedCommand;
        /// <summary>
        /// 菜单展开命令
        /// </summary>
        public ICommand MenuExpanderExpandedCommand
        {
            get
            {
                return _MenuExpanderExpandedCommand ?? (_MenuExpanderExpandedCommand = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<string>(Menu.Title, "MenuExpander");
                    }));
            }

        }


        
        private ICommand _MenuCheckChangedCommand;
        /// <summary>
        /// 单个节点选择改变的命令
        /// </summary>
        public ICommand MenuCheckChangedCommand
        {
            get
            {
                return _MenuCheckChangedCommand
                    ?? (_MenuCheckChangedCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<MenuBarModel>(this, "MenuCheckChanged");
                    }));
            }
        }
        
        private ICommand _SelectNodeCommand;
        /// <summary>
        /// 选中节点的命令，将 选择中的子节点 作为 参数 发送到信息中心
        /// </summary>
        public ICommand SelectNodeCommand
        {
            get
            {
                return _SelectNodeCommand
                    ?? (_SelectNodeCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<List<MenuBarModel>>(ChildMenuBarModel, "SelectNode");
                    }));
            }
        }

        private ICommand _UnSelectNodeCommand;
        /// <summary>
        /// 不选中节点的命令，将不选中的子节点 作为 参数 发送到信息中心
        /// </summary>
        public ICommand UnSelectNodeCommand
        {
            get
            {
                return _UnSelectNodeCommand
                    ?? (_UnSelectNodeCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<List<MenuBarModel>>(ChildMenuBarModel, "UnSelectNode");
                    }));
            }
        }



    }
}
