using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using ManagerSystem.Entity.Dto;
using System.Collections.Generic;
using HandyControl.Controls;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using ManagerSystem.Utils.Http.SystemManager;
using ManagerSystem.Entity.SystemManager;
using System.Threading;
using System.Linq;
using ManagerSystem.Utils.Helper;
using CompanyManagerSystem.View.subView.Dialog;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class RoleViewModel : ViewModelBase
    {

        public RoleViewModel()
        {
            //Register(应用对象， 信息名称，回调方法)
            // 从信息中心获取指令和参数，应用的对象类是this（RoleViewModel），根据信息名称（CheckedRoleStatus），调用this里面的方法
            Messenger.Default.Register<string>(this, "CheckedRoleStatus", CheckedRoleStatusMethod);
            Messenger.Default.Register<string>(this, "UnCheckedRoleStatus", UnCheckedRoleStatusMethod);

            // 获取选择的权限列表
            Messenger.Default.Register<List<RoleDto>>(this, "SelectedRoles", (item) => { SelectedRoles = item; });


            Messenger.Default.Register<List<MenuBarModel>>(this, "SelectNode", SelectNodeMethod);
            Messenger.Default.Register<List<MenuBarModel>>(this, "UnSelectNode", UnSelectNodeMethod);

            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 }; // 初始化每页容量

            // 获取权限列表
            var roles = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
            RefreshRoleList(roles.items, roles.TotalCount);

        }


        #region 属性

        #region 权限属性

        private ObservableCollection<RoleDto> _RoleList = new ObservableCollection<RoleDto>();
        /// <summary>
        /// 用户权限列表
        /// </summary>
        public ObservableCollection<RoleDto> RoleList
        {
            get { return _RoleList; }
            set
            {
                _RoleList = value;
                RaisePropertyChanged();
            }
        }


        private RoleDto _SelectedRole;
        /// <summary>
        /// 选择的权限
        /// </summary>
        public RoleDto SelectedRole
        {
            get { return _SelectedRole; }
            set
            {
                _SelectedRole = value;
                RaisePropertyChanged();
            }
        }

        private List<RoleDto> _SelectedRoles;
        /// <summary>
        /// 选择的权限列表
        /// </summary>
        public List<RoleDto> SelectedRoles
        {
            get { return _SelectedRoles; }
            set
            {
                _SelectedRoles = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 菜单属性?

        private bool _Interaction = true;
        /// <summary>
        /// 是否父子联动(选择父节点子节点全部选择)
        /// </summary>
        public bool Interaction
        {
            get { return _Interaction; }
            set
            {
                _Interaction = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 搜索属性

        private string _SearchRoleName;
        /// <summary>
        /// 搜索的 权限的名称
        /// </summary>
        public string SearchRoleName
        {
            get { return _SearchRoleName; }
            set
            {
                _SearchRoleName = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStatus;
        /// <summary>
        /// 搜索框中 权限的状态
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

        private string _StartDate;
        /// <summary>
        /// 搜索框中 权限的创建时间的 起始时间
        /// </summary>
        public string StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                RaisePropertyChanged();
            }
        }

        private string _EndDate;
        /// <summary>
        /// 搜索框中 权限的创建时间的 终止时间
        /// </summary>
        public string EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改权限）
        /// </summary>
        private Dialog roleInfoDialog;

        private RoleDto _DialogRole = new RoleDto();
        /// <summary>
        /// 弹窗中的 权限
        /// </summary>
        public RoleDto DialogRole
        {
            get { return _DialogRole; }
            set
            {
                _DialogRole = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogTitle;
        /// <summary>
        /// 弹窗标题
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

        private ObservableCollection<MenuBarModel> _DialogMenuList = new ObservableCollection<MenuBarModel>();
        /// <summary>
        /// 弹窗中的菜单列表(不同权限的用户 所拥有的菜单 不一致)
        /// </summary>
        public ObservableCollection<MenuBarModel> DialogMenuList
        {
            get { return _DialogMenuList; }
            set
            {
                _DialogMenuList = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 分页属性

        private int _TotalCount;
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount
        {
            get { return _TotalCount; }
            set
            {
                _TotalCount = value;
                RaisePropertyChanged();
            }
        }

        private int _TotalPageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount
        {
            get { return _TotalPageCount; }
            set
            {
                _TotalPageCount = value;
                RaisePropertyChanged();
            }
        }

        private int _CurrentPage = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                RaisePropertyChanged();
            }
        }

        private int _PerPageCount = 20;
        /// <summary>
        /// 每页容量
        /// </summary>
        public int PerPageCount
        {
            get { return _PerPageCount; }
            set
            {
                _PerPageCount = value;
                RaisePropertyChanged();
            }
        }

        private List<int> _PerPageCountList;
        /// <summary>
        /// 每页容量列表(20,50,100...)
        /// </summary>
        public List<int> PerPageCountList
        {
            get { return _PerPageCountList; }
            set
            {
                _PerPageCountList = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 其他属性

        private Visibility _SearchPanelVis = Visibility.Visible;
        /// <summary>
        /// 搜索框的可见性(默认可见)
        /// </summary>
        public Visibility SearchPanelVis
        {
            get { return _SearchPanelVis; }
            set
            {
                _SearchPanelVis = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #endregion

        #region 命令

        #region 权限命令

        private ICommand _DeleteRoleInfoCommand;
        /// <summary>
        /// 删除权限
        /// </summary>
        public ICommand DeleteRoleInfoCommand
        {
            get
            {
                return _DeleteRoleInfoCommand ??
                    (_DeleteRoleInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedRole == null || SelectedRole.Role == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "RoleWarningMsg");
                                return;
                            }
                            // 删除单个权限
                            if (para == "DeleteOnlyOneRole")
                            {
                                var deleteRole = SelectedRole;
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{deleteRole.Role.RoleName}]的权限?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = RoleHttpUtil.DeleteRole(deleteRole.Role.Id);
                                    if (resultDelete)
                                    {
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{deleteRole.Role.RoleName}]的权限！", "RoleSuccessMsg");
                                        // 刷新列表
                                        var roleList = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                        RefreshRoleList(roleList.items, roleList.TotalCount);
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "RoleWarningMsg");
                                    }
                                }
                            }
                            // 删除多个权限
                            else if (para == "DeleteNotOnlyOneRole")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SelectedRoles.Count == 1 ? $"是否删除名为[{SelectedRole.Role.RoleName}]的权限?" : $"是否删除{SelectedRoles.Count}个权限",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var roleDto in SelectedRoles)
                                    {
                                        var resultDelete = RoleHttpUtil.DeleteRole(roleDto.Role.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除{roleDto.Role.RoleName}失败，请刷新列表后重试！", "RoleWarningMsg");
                                            Thread.Sleep(1000);
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个权限,失败删除{errorCount}个权限");
                                    // 刷新数据
                                    var roleList = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshRoleList(roleList.items, roleList.TotalCount);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "RoleErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion

        #region 菜单命令

        private ICommand _ExpandAllNodeCommand;
        /// <summary>
        /// 展开所有菜单节点
        /// </summary>
        public ICommand ExpandAllNodeCommand
        {
            get
            {
                return _ExpandAllNodeCommand ??
                    (_ExpandAllNodeCommand = new RelayCommand(() =>
                    {
                        RecursionMenuList(DialogMenuList.ToList(), "IsExpanded", true);
                    }));
            }
        }

        private ICommand _FoldAllNodeCommand;
        /// <summary>
        /// 折叠所有菜单节点
        /// </summary>
        public ICommand FoldAllNodeCommand
        {
            get
            {
                return _FoldAllNodeCommand ??
                    (_FoldAllNodeCommand = new RelayCommand(() =>
                    {
                        RecursionMenuList(DialogMenuList.ToList(), "IsExpanded", false);
                    }));
            }
        }

        private ICommand _SelectAllNodeCommand;
        /// <summary>
        /// 选择所有菜单节点
        /// </summary>
        public ICommand SelectAllNodeCommand
        {
            get
            {
                return _SelectAllNodeCommand ??
                    (_SelectAllNodeCommand = new RelayCommand(() =>
                    {
                        RecursionMenuList(DialogMenuList.ToList(), "IsChecked", true);
                    }));
            }
        }

        private ICommand _UnSelectAllNodeCommand;
        /// <summary>
        /// 不选中所有菜单节点
        /// </summary>
        public ICommand UnSelectAllNodeCommand
        {
            get
            {
                return _UnSelectAllNodeCommand ??
                    (_UnSelectAllNodeCommand = new RelayCommand(() =>
                    {
                        RecursionMenuList(DialogMenuList.ToList(), "IsChecked", false);
                    }));
            }
        }

        #endregion

        #region 搜索命令

        private ICommand _ConditionalSearchRoleCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand ConditionalSearchRoleCommand
        {
            get
            {
                return _ConditionalSearchRoleCommand ??
                    (_ConditionalSearchRoleCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1; // 设置当前页面为第一页
                        // 根据 搜索条件 搜索，刷新列表
                        var roleList = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshRoleList(roleList.items, roleList.TotalCount);
                    }));
            }
        }

        private ICommand _ResetConditionalSearchRoleCommand;
        /// <summary>
        /// 重置搜索条件，并刷新数据
        /// </summary>
        public ICommand ResetConditionalSearchRoleCommand
        {
            get
            {
                return _ResetConditionalSearchRoleCommand ??
                    (_ResetConditionalSearchRoleCommand = new RelayCommand(() =>
                    {
                        SearchRoleName = null;
                        SearchStatus = null;
                        StartDate = null;
                        EndDate = null;
                        CurrentPage = 1;
                        // 刷新列表
                        var roleList = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshRoleList(roleList.items, roleList.TotalCount);
                    }));
            }
        }


        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _RoleInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand RoleInfoDialogLoadedCommand
        {
            get
            {
                return _RoleInfoDialogLoadedCommand ??
                    (_RoleInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _RoleInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand RoleInfoDialogUnloadedCommand
        {
            get
            {
                return _RoleInfoDialogUnloadedCommand ??
                    (_RoleInfoDialogLoadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogRole = new RoleDto(); // 重新 赋值 权限实例
                    }));
            }
        }

        private ICommand _AddRoleInfoCommand;
        /// <summary>
        /// 打开 添加权限 窗体
        /// </summary>
        public ICommand AddRoleInfoCommand
        {
            get
            {
                return _AddRoleInfoCommand ??
                    (_AddRoleInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加权限";
                        DialogRole = new RoleDto();
                        DialogMenuList.Clear(); // 清空菜单列表
                        DialogMenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items); // 获取菜单列表
                        // 打开窗体
                        roleInfoDialog = HandyControl.Controls.Dialog.Show<RoleInfoDialog>();
                    }));
            }
        }

        private ICommand _EditRoleInfoCommand;
        /// <summary>
        /// 打开 编辑权限 窗体
        /// </summary>
        public ICommand EditRoleInfoCommand
        {
            get
            {
                return _EditRoleInfoCommand ??
                    (_EditRoleInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "修改权限";
                        DialogRole.Role = (Role)SelectedRole.Role.Clone();
                        // 遍历获取 选择的权限 所拥有的菜单
                        //foreach (var menuBarModel in SelectedRole.Menu)
                        //{
                        //    DialogRole.Menu.Add(new MenuBarModel() { Menu = (Menu)menuBarModel.Menu.Clone() });
                        //}
                        SelectedRole.Menu.ForEach(t => DialogRole.Menu.Add(new MenuBarModel() { Menu = (Menu)t.Menu.Clone() }));

                        DialogMenuList.Clear();
                        // 获取所有的权限
                        DialogMenuList = TreeListHelper.RefreshMenulist(MenuHttpUtil.GetAllMenu().items);
                        RecursionMenuList(DialogMenuList.ToList(), "IsChecked");

                        // 打开窗体
                        roleInfoDialog = HandyControl.Controls.Dialog.Show<RoleInfoDialog>();
                    }));
            }
        }

        private ICommand _SubmitRoleInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitRoleInfoCommand
        {
            get
            {
                return _SubmitRoleInfoCommand ??
                    (_SubmitRoleInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (SelectedRole == null || SelectedRole.Role == null)
                            {
                                return;
                            }
                            // 权限名称是否为空
                            if (string.IsNullOrEmpty(DialogRole.Role.RoleName))
                            {
                                HandyControl.Controls.Growl.Warning("权限名称不能为空！", "RoleInfoWarningMsg");
                                return;
                            }
                            // 添加权限
                            if (DialogTitle == "添加权限")
                            {
                                if (RoleHttpUtil.ExistRoleName(DialogRole.Role.RoleName))
                                {
                                    HandyControl.Controls.Growl.Warning("权限名称已经存在！", "RoleInfoWarningMsg");
                                    return;
                                }

                                DialogRole.Role.insertTime = DateTime.Now; // 获取时间
                                var id = RoleHttpUtil.AddRole(DialogRole.Role); // 添加权限
                                // 是否添加成功
                                if (id > 0)
                                {
                                    DialogRole.Menu.Clear(); // 清空 窗体的权限拥有的菜单
                                    RecursionMenuList(DialogMenuList.ToList(), "Add"); // 将所勾选的菜单 添加到 权限所拥有的菜单中
                                    // 向中间表添加参数
                                    DialogRole.Menu.ForEach(m =>
                                    {
                                        RoleHttpUtil.AddRoleMenu(new RoleMenu() { memu_Id = m.Menu.Id, role_Id = id });
                                    });

                                    // 关闭窗体
                                    roleInfoDialog.Close();
                                    // 刷新
                                    var roleList = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshRoleList(roleList.items, roleList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"权限添加成功！", "RoleSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("权限添加失败！", "RoleInfoWarningMsg");
                                    return;
                                }
                            }
                            else if (DialogTitle == "修改权限")
                            {
                                var resultEdit = RoleHttpUtil.UpdateRole(DialogRole.Role);

                                if (resultEdit)
                                {
                                    // 修改中间表中 角色和岗位 对应关系
                                    List<Menu> menus = RoleHttpUtil.GetRoleMenu(DialogRole.Role.Id).items;
                                    AddOrDeleteRoleMenu(DialogMenuList.ToList(), menus);

                                    var roles = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshRoleList(roles.items, roles.TotalCount);
                                    roleInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"角色修改成功！", "RoleSuccessMsg");
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("权限修改失败！", "RoleInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "RoleErrorMsg");
                            return;
                        }
                    }));
            }
        }



        #endregion

        #region 分页命令

        private ICommand _PerPageCountChangedCommand;
        /// <summary>
        /// 每页容量变换时，重新刷新列表
        /// </summary>
        public ICommand PerPageCountChangedCommand
        {
            get
            {
                return _PerPageCountChangedCommand ??
                    (_PerPageCountChangedCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1;
                        var roles = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshRoleList(roles.items, roles.TotalCount);
                    }));
            }
        }

        private ICommand _PageUpdatedCommand;
        /// <summary>
        /// 指定页跳转
        /// </summary>
        public ICommand PageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        var roles = RoleHttpUtil.GetRoles(SearchRoleName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshRoleList(roles.items, roles.TotalCount);
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
                        SearchPanelVis = (SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
                    }));
            }
        }


        #endregion
        #endregion

        #region 方法
        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="allRoleList"></param>
        /// <param name="totalCount"></param>
        private void RefreshRoleList(List<Role> allRoleList, int totalCount)
        {
            TotalCount = totalCount;
            if (TotalCount % PerPageCount == 0)
            {
                TotalPageCount = TotalCount / PerPageCount;
            }
            else
            {
                TotalPageCount = TotalCount / PerPageCount + 1;
            }
            if (CurrentPage > TotalPageCount)
            {
                CurrentPage = TotalPageCount;
            }

            RoleList.Clear();


            allRoleList.ForEach(r =>
            {
                List<MenuBarModel> menus = new List<MenuBarModel>();
                RoleHttpUtil.GetRoleMenu(r.Id).items.ForEach(m => menus.Add(new MenuBarModel() { Menu = m }));
                RoleList.Add(new RoleDto() { Menu = menus, Role = r });
            });
        }

        /// <summary>
        /// 修改权限状态为启用
        /// </summary>
        /// <param name="status"></param>
        private void CheckedRoleStatusMethod(string status)
        {
            SelectedRole.Role.Status = bool.Parse(status);
            var result = RoleHttpUtil.UpdateRole(SelectedRole.Role);
            if (result)
            {
                HandyControl.Controls.Growl.Success($"{SelectedRole.Role.RoleName}权限状态修改成功！", "RoleSuccessMsg");
            }
            else
            {
                HandyControl.Controls.Growl.Warning("修改失败！", "RoleWarningMsg");
            }
        }

        /// <summary>
        /// 修改权限状态为禁用
        /// </summary>
        /// <param name="status"></param>
        private void UnCheckedRoleStatusMethod(string status)
        {
            SelectedRole.Role.Status = bool.Parse(status);
            var result = RoleHttpUtil.UpdateRole(SelectedRole.Role);
            if (result)
            {
                HandyControl.Controls.Growl.Success($"{SelectedRole.Role.RoleName}权限状态修改成功！", "RoleSuccessMsg");
            }
            else
            {
                HandyControl.Controls.Growl.Warning("修改失败！", "RoleWarningMsg");
            }
        }

        /// <summary>
        /// 选择单个菜单节点
        /// </summary>
        /// <param name="menuBarModels"></param>
        private void SelectNodeMethod(List<MenuBarModel> menuBarModels)
        {
            if (Interaction)
            {
                foreach (var item in menuBarModels)
                {
                    item.IsChecked = true;
                }
            }
        }

        /// <summary>
        /// 不选择单个节点
        /// </summary>
        /// <param name="menuBarModels"></param>
        private void UnSelectNodeMethod(List<MenuBarModel> menuBarModels)
        {
            if (Interaction)
            {
                foreach (var item in menuBarModels)
                {
                    item.IsChecked = false;
                }
            }
        }

        /// <summary>
        /// 递归MenuList
        /// </summary>
        /// <param name="dialogMenuList"></param>
        /// <param name="v1">用于判断执行何种操作(IsExpanded,IsChecked)</param>
        /// <param name="v2">设置的目标状态值(true 或 false )</param>
        private void RecursionMenuList(List<MenuBarModel> dialogMenuList, string v1, bool v2)
        {
            switch (v1)
            {
                case "IsExpanded":
                    {
                        foreach (var item in dialogMenuList)
                        {
                            item.IsExpanded = v2;
                            //RecursionMenuList(item.ChildMenuBarModel, v1, v2);
                        }
                    }
                    break;
                case "IsChecked":
                    {
                        foreach (var item in dialogMenuList)
                        {
                            item.IsChecked = v2;
                            RecursionMenuList(item.ChildMenuBarModel, v1, v2);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 递归MenuList
        /// </summary>
        /// <param name="dialogMenuList"></param>
        /// <param name="v1"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void RecursionMenuList(List<MenuBarModel> dialogMenuList, string v1)
        {
            switch (v1)
            {
                case "Add":
                    {
                        foreach (var item in dialogMenuList)
                        {
                            if (item.IsChecked) // 如果该菜单勾选了则添加该菜单到权限中
                            {
                                DialogRole.Menu.Add(item);
                            }
                            // 再继续往下一个级别
                            RecursionMenuList(item.ChildMenuBarModel, v1);
                        }
                    }
                    break;
                case "IsChecked":
                    {
                        foreach (var item in dialogMenuList)
                        {
                            item.IsChecked = DialogRole.Menu.Exists(r => r.Menu.Id == item.Menu.Id);
                            RecursionMenuList(item.ChildMenuBarModel, v1);

                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 添加或删除权限菜单
        /// </summary>
        /// <param name="dialogMenuList"></param>
        /// <param name="menus">权限中已经包含的菜单</param>
        private void AddOrDeleteRoleMenu(List<MenuBarModel> dialogMenuList, List<Menu> menus)
        {
            foreach (var item in dialogMenuList)
            {
                if (item.IsChecked)
                {
                    // 勾选了 但是没有在 权限中没包含的菜单
                    if (!menus.Exists(t => t.Id == item.Menu.Id))
                    {
                        // 新增加的角色，需要在中间表中新增
                        RoleHttpUtil.AddRoleMenu(new RoleMenu() { role_Id = SelectedRole.Role.Id, memu_Id = item.Menu.Id });
                    }
                }
                else
                {
                    // 没勾选 但是在 权限中已经包含的菜单
                    if (menus.Exists(t => t.Id == item.Menu.Id))
                    {
                        // 删除的角色，需要在中间表中删除
                        RoleHttpUtil.DeleteRoleMenu(SelectedRole.Role.Id, item.Menu.Id);
                    }
                }
                AddOrDeleteRoleMenu(item.ChildMenuBarModel, menus);
            }
        }

        #endregion
    }
}
