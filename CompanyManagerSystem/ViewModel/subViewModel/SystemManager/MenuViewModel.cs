using CompanyManagerSystem.View.subView.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http.SystemManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Menu = ManagerSystem.Entity.SystemManager.Menu;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class MenuViewModel : ViewModelBase
    {

        public MenuViewModel()
        {
            // 注册信息，往后一旦接受到“MenuCheckChanged”类型信息，就会触发MenuCheckChangedMethod命令
            Messenger.Default.Register<MenuBarModel>(this, "MenuCheckChanged", MenuCheckChangedMethod);

            MenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
        }

        #region 属性

        #region 菜单属性

        private ObservableCollection<MenuBarModel> _MenuList = new ObservableCollection<MenuBarModel>();
        /// <summary>
        /// 菜单列表
        /// </summary>
        public ObservableCollection<MenuBarModel> MenuList
        {
            get { return _MenuList; }
            set
            {
                _MenuList = value;
                RaisePropertyChanged();
            }
        }

        private MenuBarModel _SelectedMenu;
        /// <summary>
        /// 选择的菜单
        /// </summary>
        public MenuBarModel SelectedMenu
        {
            get { return _SelectedMenu; }
            set
            {
                _SelectedMenu = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 按钮属性

        private bool _FoldToggleButtonChecked;
        /// <summary>
        /// 展开与折叠
        /// </summary>
        public bool FoldToggleButtonChecked
        {
            get { return _FoldToggleButtonChecked; }
            set
            {
                _FoldToggleButtonChecked = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 弹窗属性

        /// <summary>
        /// 菜单信息弹窗(添加/删除)
        /// </summary>
        private Dialog menuInfoDialog;

        private string _DialogTitle;
        /// <summary>
        /// 窗体标题
        /// </summary>
        public string DialogTitle
        {
            get { return _DialogTitle; }
            set
            {
                _DialogTitle = value;
                RaisePropertyChanged();
            }
        }

        private MenuBarModel _DialogMenu = new MenuBarModel();
        /// <summary>
        /// 窗体中的菜单
        /// </summary>
        public MenuBarModel DialogMenu
        {
            get { return _DialogMenu; }
            set
            {
                _DialogMenu = value;
                RaisePropertyChanged();
            }
        }

        private MenuBarModel _DialogParentMenu = new MenuBarModel();
        /// <summary>
        /// 窗体中的父菜单
        /// </summary>
        public MenuBarModel DialogParentMenu
        {
            get { return _DialogParentMenu; }
            set
            {
                _DialogParentMenu = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<MenuBarModel> _DialogParentMenuList = new ObservableCollection<MenuBarModel>();
        /// <summary>
        /// 窗体中的父菜单列表
        /// </summary>
        public ObservableCollection<MenuBarModel> DialogParentMenuList
        {
            get { return _DialogParentMenuList; }
            set
            {
                _DialogParentMenuList = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 搜索属性

        private string _SearchTitle;
        /// <summary>
        /// 搜索的菜单的名称
        /// </summary>
        public string SearchTitle
        {
            get { return _SearchTitle; }
            set
            {
                _SearchTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStatus;
        /// <summary>
        /// 搜索的菜单的状态
        /// </summary>
        public string SearchStatus
        {
            get { return _SearchStatus; }
            set
            {
                _SearchStatus = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 其他属性

        private Visibility _SearchPanelVis = Visibility.Visible;
        /// <summary>
        /// 搜索框的可见性
        /// </summary>
        public Visibility SearchPanelVis
        {
            get { return _SearchPanelVis; }
            set { _SearchPanelVis = value; }
        }

        #endregion

        #endregion

        #region 命令

        #region 菜单命令 

        private ICommand _DeleteMenuInfoCommand;
        /// <summary>
        /// 删除菜单命令
        /// </summary>
        public ICommand DeleteMenuInfoCommand
        {
            get
            {
                return _DeleteMenuInfoCommand ??
                    (_DeleteMenuInfoCommand = new RelayCommand(() =>
                    {
                        var resultDialog = HandyControl.Controls.MessageBox.Show($"确定要删除菜单[{SelectedMenu.Menu.Title}]吗？", "提示",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultDialog == MessageBoxResult.Yes)
                        {
                            try
                            {
                                if (SelectedMenu.ChildMenuBarModel.Count > 0)
                                {
                                    HandyControl.Controls.Growl.Warning($"菜单[{SelectedMenu.Menu.Title}]有子菜单,删除失败！", "MenuWarningMsg");
                                    return;
                                }

                                var resultDelete = MenuHttpUtil.DeleteMenu(SelectedMenu.Menu.Id);
                                if (resultDelete)
                                {
                                    //删除数据库中的该用户的信息，并刷新页面.
                                    MenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetMenus(SearchTitle, SearchStatus).items);

                                    HandyControl.Controls.Growl.Success($"菜单删除成功！", "MenuSuccessMsg");

                                    FoldToggleButtonChecked = false;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning($"菜单[{SelectedMenu.Menu.Title}]删除失败！", "MenuWarningMsg");
                                    return;
                                }

                            }
                            catch (Exception ex)
                            {
                                HandyControl.Controls.Growl.Error($"发生异常错误，详情：{ex.Message}！", "MenuErrorMsg");
                                return;
                            }
                        }
                    }));
            }
        }


        #endregion

        #region 按钮命令

        private ICommand _FoldMenuInfoCommand;
        /// <summary>
        /// 展开菜单
        /// </summary>
        public ICommand FoldMenuInfoCommand
        {
            get
            {
                return _FoldMenuInfoCommand ??
                    (_FoldMenuInfoCommand = new RelayCommand(() =>
                    {

                        List<MenuBarModel> tempMenuBarModels = new List<MenuBarModel>();
                        foreach (var item in MenuList)
                        {
                            tempMenuBarModels.Add(item);
                            GetChildMenuBarModels(item, tempMenuBarModels); // 获取item的子节点并存入tempMenuBarModels中
                        }
                        foreach (var item in tempMenuBarModels)
                        {
                            item.IsChecked = true; // 菜单状态为勾选
                        }

                        MenuList.Clear(); // 清空菜单列表
                        foreach (var item in tempMenuBarModels)
                        {
                            MenuList.Add(item); // 将 勾选的菜单 添加到 菜单列表中
                        }
                    }));
            }
        }

        private ICommand _UnFoldMenuInfoCommand;
        /// <summary>
        /// 折叠菜单
        /// </summary>
        public ICommand UnFoldMenuInfoCommand
        {
            get
            {
                return _UnFoldMenuInfoCommand ??
                    (_UnFoldMenuInfoCommand = new RelayCommand(() =>
                    {
                        List<MenuBarModel> tempMenuBarModels = new List<MenuBarModel>();
                        foreach (var item in MenuList)
                        {
                            // 根节点 或者是 没有父节点的子节点
                            if (item.Menu.parent_Id == 0 || !MenuList.ToList().Exists(t => t.Menu.Id == item.Menu.parent_Id))
                            {
                                tempMenuBarModels.Add(item);
                            }
                        }
                        foreach (var item in tempMenuBarModels)
                        {
                            item.IsChecked = false; // 折叠
                        }

                        MenuList.Clear(); // 清空
                        foreach (var item in tempMenuBarModels)
                        {
                            MenuList.Add(item); // // 将 折叠的菜单 添加到 菜单列表中
                        }
                    }));
            }

        }


        #endregion

        #region 窗体命令

        private ICommand _MenuInfoDialogLoadedCommand;
        /// <summary>
        /// 窗体加载
        /// </summary>
        public ICommand MenuInfoDialogLoadedCommand
        {
            get
            {
                return _MenuInfoDialogLoadedCommand ??
                    (_MenuInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }

        }

        private ICommand _MenuInfoDialogUnloadedCommand;
        /// <summary>
        /// 窗体关闭
        /// </summary>
        public ICommand MenuInfoDialogUnloadedCommand
        {
            get
            {
                return _MenuInfoDialogUnloadedCommand ??
                    (_MenuInfoDialogUnloadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogMenu = new MenuBarModel(); // 重新赋值参数
                    }));
            }

        }

        private ICommand _AddMenuInfoCommand;
        /// <summary>
        /// 添加菜单
        /// </summary>
        public ICommand AddMenuInfoCommand
        {
            get
            {
                return _AddMenuInfoCommand ??
                    (_AddMenuInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加菜单"; // 标题
                        DialogMenu = new MenuBarModel(); // 实例化参数
                        DialogParentMenu = new MenuBarModel();
                        DialogParentMenuList.Clear(); // 清空父菜单列表。并重新获取
                        DialogParentMenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
                        menuInfoDialog = Dialog.Show<MenuInfoDialog>(); // 打开窗体
                    }));
            }
        }

        private ICommand _EditMenuInfoCommand;
        /// <summary>
        /// 修改菜单
        /// </summary>
        public ICommand EditMenuInfoCommand
        {
            get
            {
                return _EditMenuInfoCommand ??
                    (_EditMenuInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "修改菜单"; // 菜单标题
                        DialogMenu.Menu = (Menu)SelectedMenu.Menu.Clone(); // 窗体菜单参数 从 选择的菜单的克隆体
                        DialogParentMenu.Menu = MenuHttpUtil.GetMenu(SelectedMenu.Menu.parent_Id); // 获取父节点菜单
                        DialogParentMenuList.Clear();
                        DialogParentMenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
                        menuInfoDialog = Dialog.Show<MenuInfoDialog>();
                    }));
            }

        }


        private ICommand _SubmitMenuInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>  
        public ICommand SubmitMenuInfoCommand
        {
            get
            {
                return _SubmitMenuInfoCommand ??
                    (_SubmitMenuInfoCommand = new RelayCommand(() =>
                    {

                        try
                        {
                            DialogMenu.Menu.parent_Id = DialogParentMenu.Menu.Id;

                            // 添加菜单
                            if (DialogTitle == "添加菜单")
                            {
                                menuInfoDialog.Close();
                                HandyControl.Controls.Growl.Warning("暂不支持添加菜单", "MenuWarningMsg");
                                return;
                            }
                            // 修改菜单
                            else if (DialogTitle == "修改菜单")
                            {
                                // 菜单标题为空
                                if (string.IsNullOrWhiteSpace(DialogMenu.Menu.Title))
                                {
                                    HandyControl.Controls.Growl.Warning($"菜单标题不为空！", "MenuInfoWarningMsg");
                                    return;
                                }

                                var resultUpdate = MenuHttpUtil.UpdateMenu(DialogMenu.Menu);
                                if (resultUpdate)
                                {
                                    // 刷新列表
                                    MenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
                                    menuInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"菜单修改成功！", "MenuSuccessMsg");
                                    FoldToggleButtonChecked = false; // 收缩菜单
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常错误，请刷新列表。详情{ex.Message}", "MenuErrorMsg");
                            return;
                        }

                    }));
            }
        }


        #endregion

        #region 其他命令

        private ICommand _ConditionalSearchMenuCommand;
        /// <summary>
        /// 条件查询
        /// </summary>
        public ICommand ConditionalSearchMenuCommand
        {
            get
            {
                return _ConditionalSearchMenuCommand ??
                    (_ConditionalSearchMenuCommand = new RelayCommand(() =>
                    {
                        MenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetMenus(SearchTitle, SearchStatus).items);
                        FoldToggleButtonChecked = false;
                    }));
            }
        }

        private ICommand _ResetConditionalSearchMenuCommand;
        /// <summary>
        /// 重置查询条件
        /// </summary>
        public ICommand ResetConditionalSearchMenuCommand
        {
            get
            {
                return _ResetConditionalSearchMenuCommand ??
                    (_ResetConditionalSearchMenuCommand = new RelayCommand(() =>
                    {
                        // 清空查询参数
                        SearchTitle = null;
                        SearchStatus = null;
                        MenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
                        FoldToggleButtonChecked = false;

                    }));
            }
        }



        #endregion

        #region 其他命令

        private ICommand _ChangeSearchPanelVisCommand;
        /// <summary>
        /// 隐藏搜索框
        /// </summary>
        public ICommand ChangeSearchPanelVisCommand
        {
            get
            {
                return _ChangeSearchPanelVisCommand ??
                    (_ChangeSearchPanelVisCommand = new RelayCommand(() =>
                    {
                        SearchPanelVis = (SearchPanelVis == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
                    }));
            }
        }


        #endregion
        #endregion

        #region 方法 

        /// <summary>
        /// 展开/折叠单个菜单方法
        /// </summary>
        /// <param name="barModel"></param>
        private void MenuCheckChangedMethod(MenuBarModel barModel)
        {
            int index = MenuList.IndexOf(barModel) + 1;
            if (barModel.IsChecked)
            {
                if (barModel.ChildMenuBarModel == null)
                {
                    return;
                }
                foreach (var child in barModel.ChildMenuBarModel)
                {
                    if (MenuList.ToList().Exists(t => t.Menu.Title == child.Menu.Title))
                    {
                        continue; // 避免重复添加
                    }
                    child.MarginLeft = barModel.MarginLeft + 50; // 增加左边距
                    MenuList.Insert(index++, child); // 插入
                }
            }
            else
            {
                List<MenuBarModel> tempMenuBarModels = new List<MenuBarModel>();
                foreach (var item in MenuList)
                {
                    if (item.Menu.parent_Id == barModel.Menu.Id)
                    {
                        tempMenuBarModels.Add(item);
                    }
                }
                foreach (var item in tempMenuBarModels)
                {
                    MenuList.Remove(item);
                }
            }
        }

        /// <summary>
        /// 收集指定菜单的所有子菜单（用于 一键展开菜单列表）
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="tempList"></param>
        /// <returns></returns>
        private List<MenuBarModel> GetChildMenuBarModels(MenuBarModel menu, List<MenuBarModel> tempList)
        {
            if (menu.ChildMenuBarModel != null && menu.ChildMenuBarModel.Count > 0 && menu.IsChecked == false)
            {
                foreach (var child in menu.ChildMenuBarModel)
                {
                    tempList.Add(child);
                    GetChildMenuBarModels(child, tempList);
                }
            }
            return tempList;
        }

        #endregion
    }
}
