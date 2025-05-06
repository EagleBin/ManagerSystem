using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.SystemManager;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ManagerSystem.Entity.Dto
{
    public class MenuBarModel : ViewModelBase
    {


        private Menu _Menu = new Menu();

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

        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { _IsExpanded = value;
                RaisePropertyChanged();
            }
        }


        private bool _IsChecked =false;

        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value;
                RaisePropertyChanged();
            }
        }

        private float _MarginLeft = 0;

        public float MarginLeft
        {
            get { return _MarginLeft; }
            set { _MarginLeft = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _IsVisibility = Visibility.Collapsed;

        public Visibility IsVisibility
        {
            get { return _IsVisibility; }
            set { _IsVisibility = value;
                RaisePropertyChanged();
            }
        }


        private List<MenuBarModel> _ChildMenuBarModel;

        public List<MenuBarModel> ChildMenuBarModel
        {
            get { return _ChildMenuBarModel; }
            set { _ChildMenuBarModel = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _NavigateCommand;

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


        /// <summary>
        /// 单个节点选择改变的命令
        /// </summary>
        private ICommand _MenuCheckChangedCommand;

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
        /// <summary>
        /// 选中节点的命令
        /// </summary>
        private ICommand _SelectNodeCommand;

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
        /// <summary>
        /// 不选中节点的命令
        /// </summary>
        private ICommand _UnSelectNodeCommand;

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
