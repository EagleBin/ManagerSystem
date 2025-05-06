using CompanyManagerSystem.View.subView.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http;
using ManagerSystem.Utils.Http.SystemManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class UserViewModel : ViewModelBase
    {

        public UserViewModel()
        {
            // 初始化用户状态
            Messenger.Default.Register<string>(this, "CheckedUserStatus", CheckedUserStatusMethod);
            Messenger.Default.Register<string>(this, "UncheckedUserStatus", UncheckedUserStatusMethod);

            // 获取选中的用户
            Messenger.Default.Register<List<UserDto>>(this, "SelectedUsers", (o => SelectedUsers = o));
            // 获取 用户角色权限 列表
            Messenger.Default.Register<string>(this, "GetUserRoleList", GetUserRoleListMethod);
            // 获取部门列表
            Messenger.Default.Register<string>(this, "RefreshDepList", (o => DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items)));

            // 初始化每页容量
            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 };
            UserRolePerPageCountList = new List<int>() { 20, 50, 100, 200, 500 };
            // 获取部门列表
            //DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);

            GenderList = new List<string>() { "男", "女" };

            var pageList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
            RefreshUserList(pageList.items, pageList.TotalCount);

            DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
        }



        #region 属性

        #region 用户属性

        private ObservableCollection<UserDto> _UserList = new ObservableCollection<UserDto>();
        /// <summary>
        /// 表格的用户列表
        /// </summary>
        public ObservableCollection<UserDto> UserList
        {
            get { return _UserList; }
            set
            {
                _UserList = value;
                RaisePropertyChanged();
            }
        }

        private UserDto _SelectedUser;
        /// <summary>
        /// 选择的用户
        /// </summary>
        public UserDto SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
                RaisePropertyChanged();
            }
        }

        private List<UserDto> _SelectedUsers;
        /// <summary>
        /// 选择的用户列表
        /// </summary>
        public List<UserDto> SelectedUsers
        {
            get { return _SelectedUsers; }
            set
            {
                _SelectedUsers = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 权限属性

        private ObservableCollection<RoleDto> _RoleList = new ObservableCollection<RoleDto>();
        /// <summary>
        /// 权限列表
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


        #endregion

        #region 部门属性

        private ObservableCollection<DepartmentDto> _DepartmentList;
        /// <summary>
        /// 表格中部门列表
        /// </summary>
        public ObservableCollection<DepartmentDto> DepartmentList
        {
            get { return _DepartmentList; }
            set
            {
                _DepartmentList = value;
                RaisePropertyChanged();
            }
        }

        private int _SearchDepId;
        /// <summary>
        /// 搜索框输入的 部门的Id
        /// </summary>
        public int SearchDepId
        {
            get { return _SearchDepId; }
            set
            {
                _SearchDepId = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 搜索属性

        private string _SearchAccount;
        /// <summary>
        /// 搜索框输入的用户名称
        /// </summary>
        public string SearchAccount
        {
            get { return _SearchAccount; }
            set
            {
                _SearchAccount = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchPhoneNum;
        /// <summary>
        /// 搜索框输入的电话号码
        /// </summary>
        public string SearchPhoneNum
        {
            get { return _SearchPhoneNum; }
            set
            {
                _SearchPhoneNum = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStatus;
        /// <summary>
        /// 搜索框输入的状态
        /// </summary>
        public string SearchStatus
        {
            get { return _SearchStatus; }
            set { _SearchStatus = value; }
        }

        private string _StartDate;
        /// <summary>
        /// 搜索框输入的起始时间
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
        /// 搜索框输入的终止时间
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

        #region 用户信息弹窗属性

        /// <summary>
        /// 用户信息弹窗(新增/修改用户信息)
        /// </summary>
        private Dialog userInfoDialog;

        private UserDto _DialogUser = new UserDto();
        /// <summary>
        /// 弹框中的 用户信息(用于添加/修改)
        /// </summary>
        public UserDto DialogUser
        {
            get { return _DialogUser; }
            set
            {
                _DialogUser = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogTitle;
        /// <summary>
        /// 弹窗的标题(添加/修改)
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

        private ObservableCollection<DepartmentDto> _DialogDepartmentList = new ObservableCollection<DepartmentDto>();
        /// <summary>
        /// 弹窗中的 部门列表
        /// </summary>
        public ObservableCollection<DepartmentDto> DialogDepartmentList
        {
            get { return _DialogDepartmentList; }
            set
            {
                _DialogDepartmentList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<RoleDto> _DialogRoleList = new ObservableCollection<RoleDto>();
        /// <summary>
        /// 弹窗中的权限列表（管理员/普通用户等）
        /// </summary>
        public ObservableCollection<RoleDto> DialogRoleList
        {
            get { return _DialogRoleList; }
            set
            {
                _DialogRoleList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<PostDto> _DialogPostList = new ObservableCollection<PostDto>();
        /// <summary>
        /// 弹窗中的岗位列表
        /// </summary>
        public ObservableCollection<PostDto> DialogPostList
        {
            get { return _DialogPostList; }
            set
            {
                _DialogPostList = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _GenderList;
        /// <summary>
        /// 弹窗中的性别列表
        /// </summary>
        public List<string> GenderList
        {
            get { return _GenderList; }
            set
            {
                _GenderList = value;
                RaisePropertyChanged();
            }
        }




        #endregion

        #region 修改密码弹窗属性


        /// <summary>
        /// 修改密码弹窗
        /// </summary>
        private Dialog resetPasswordDialog;

        private string _DialogPasswordTitle;
        /// <summary>
        /// 密码弹窗 的 标题
        /// </summary>
        public string DialogPasswordTitle
        {
            get { return _DialogPasswordTitle; }
            set
            {
                _DialogPasswordTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogPassword;
        /// <summary>
        /// 密码弹窗 的 密码
        /// </summary>
        public string DialogPassword
        {
            get { return _DialogPassword; }
            set
            {
                _DialogPassword = value;
                RaisePropertyChanged();
            }
        }

        private string _ConfirmPassword;
        /// <summary>
        /// 密码弹窗 的 确认密码
        /// </summary>
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _DialogAccountAndPasswordVisibility = Visibility.Visible;
        /// <summary>
        /// 密码弹窗 的用户账号和密码的可见性
        /// </summary>
        public Visibility DialogAccountAndPasswordVisibility
        {
            get { return _DialogAccountAndPasswordVisibility; }
            set
            {
                _DialogAccountAndPasswordVisibility = value;
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

        private int _UserRoleTotalCount;
        /// <summary>
        /// 用户权限总数
        /// </summary>
        public int UserRoleTotalCount
        {
            get { return _UserRoleTotalCount; }
            set
            {
                _UserRoleTotalCount = value;
                RaisePropertyChanged();
            }
        }

        private int _UserRoleTotalPageCount;
        /// <summary>
        /// 用户权限总页数
        /// </summary>
        public int UserRoleTotalPageCount
        {
            get { return _UserRoleTotalPageCount; }
            set
            {
                _UserRoleTotalPageCount = value;
                RaisePropertyChanged();
            }
        }

        private int _CurrentPage = 1;
        /// <summary>
        /// 当前页数
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

        private int _UserRoleCurrentPage = 1;
        /// <summary>
        /// 用户权限当前页数
        /// </summary>
        public int UserRoleCurrentPage
        {
            get { return _UserRoleCurrentPage; }
            set
            {
                _UserRoleCurrentPage = value;
                RaisePropertyChanged();
            }
        }

        private List<int> _PerPageCountList;
        /// <summary>
        /// 每页容量 列表
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

        private List<int> _UserRolePerPageCountList;
        /// <summary>
        /// 用户权限每页容量 列表
        /// </summary>
        public List<int> UserRolePerPageCountList
        {
            get { return _UserRolePerPageCountList; }
            set { _UserRolePerPageCountList = value; }
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

        private int _UserRolePerPageCount = 20;
        /// <summary>
        /// 用户权限每页容量
        /// </summary>
        public int UserRolePerPageCount
        {
            get { return _UserRolePerPageCount; }
            set
            {
                _UserRolePerPageCount = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 其他属性

        private Visibility _SearchPanelVis = Visibility.Visible;

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

        #region 用户命令

        private ICommand _DeleteUserInfoCommand;
        /// <summary>
        /// 删除用户
        /// </summary>
        public ICommand DeleteUserInfoCommand
        {
            get
            {
                return _DeleteUserInfoCommand ??
                    (_DeleteUserInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedUser == null || SelectedUser.User == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "UserWarningMsg");
                                return;
                            }

                            // 只删除一个用户对象
                            if (para == "DeleteOnlyOneUser")
                            {
                                var deleteUser = SelectedUser.User;
                                var Question = HandyControl.Controls.MessageBox.Show($"是否删除用户[{deleteUser.Account}]", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (Question == MessageBoxResult.Yes)
                                {
                                    var result_Delete = UserHttpUtil.DeleteUser(deleteUser.Id);
                                    // 是否删除成功
                                    if (result_Delete)
                                    {
                                        HandyControl.Controls.Growl.Success($"删除用户删除用户[{deleteUser.Account}]成功", "UserSuccessMsg");
                                        // 刷新用户列表
                                        var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                                        RefreshUserList(userList.items, userList.TotalCount);
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success($"删除用户删除用户[{deleteUser.Account}]失败", "UserWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个用户对象
                            else if (para == "DeleteNotOnlyOneUser")
                            {
                                var result_Question = HandyControl.Controls.MessageBox.Show(
                                    SelectedUsers.Count == 1 ? $"是否删除用户[{SelectedUser.User.Account}]" : $"是否删除选中的{SelectedUsers.Count}个用户",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result_Question == MessageBoxResult.Yes)
                                {
                                    int successCount = 0;
                                    int falseCount = 0;
                                    // 遍历删除
                                    foreach (var user in SelectedUsers)
                                    {
                                        var result_Delete = UserHttpUtil.DeleteUser(user.User.Id);
                                        if (!result_Delete)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除用户删除用户[{user.User.Account}]失败", "UserWarningMsg");
                                            falseCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个用户,删除失败{falseCount}个用户", "UserSuccessMsg");
                                    // 刷新用户列表
                                    var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                                    RefreshUserList(userList.items, userList.TotalCount);
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Success($"操作出现异常，请刷新。错误详情:{ex.Message}", "UserErrorMsg");
                            return;
                        }
                    }));
            }

        }

        private ICommand _SelectedItemChangedCommand;
        /// <summary>
        /// 根据部门获取用户列表
        /// </summary>
        public ICommand SelectedItemChangedCommand
        {
            get
            {
                return _SelectedItemChangedCommand ??
                    (_SelectedItemChangedCommand = new RelayCommand<DepartmentDto>((dep) =>
                    {
                        // 搜索框中的部门号为空，则默认部门号为0
                        SearchDepId = (dep == null) ? 0 : dep.Department.Id;
                        // 获取用户列表
                        var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                        // 刷新用户列表
                        RefreshUserList(userList.items, userList.TotalCount);
                    }));
            }

        }

        private ICommand _AssignUserRoleCommand;
        /// <summary>
        /// 分配角色命令
        /// </summary>
        public ICommand AssignUserRoleCommand
        {
            get
            {
                return _AssignUserRoleCommand ??
                    (_AssignUserRoleCommand = new RelayCommand(() =>
                    {
                        // 向信息中心发送 打开 UserRoleView 视图的导航信心
                        Messenger.Default.Send("SystemManager.UserRoleView", "NavigateView");
                    }));
            }

        }




        #endregion

        #region 权限命令

        private ICommand _SubmitUserRoleCommand;
        /// <summary>
        /// 修改用户权限命令
        /// </summary>
        public ICommand SubmitUserRoleCommand
        {
            get
            {
                return _SubmitUserRoleCommand ??
                    (_SubmitUserRoleCommand = new RelayCommand(() =>
                    {
                        bool isChanged = false;
                        List<Role> roleList = UserHttpUtil.GetUserRole(SelectedUser.User.Id).items;
                        foreach (var item in RoleList)
                        {
                            if (item.IsChecked)
                            {
                                if (!roleList.Exists(t => t.Id == item.Role.Id))
                                {
                                    UserHttpUtil.AddUserRole(new UserRole() { user_Id = SelectedUser.User.Id, role_Id = item.Role.Id });
                                    isChanged = true;
                                }
                            }
                            else
                            {
                                if (roleList.Exists(t => t.Id == item.Role.Id))
                                {
                                    UserHttpUtil.DeleteUserRole(SelectedUser.User.Id, item.Role.Id);
                                    isChanged = true;
                                }
                            }
                        }

                        if (isChanged)
                        {
                            HandyControl.Controls.Growl.Success("角色分配成功！", "AssignUserRoleSuccessMsg");
                        }
                        else
                        {
                            HandyControl.Controls.Growl.Warning("用户角色未发生变化！", "AssignUserRoleWarningMsg");
                        }

                    }));
            }

        }


        #endregion

        #region 搜索命令 

        private ICommand _ConditionalSearchUserCommand;
        /// <summary>
        /// 根据搜索条件查询指定User
        /// </summary>
        public ICommand ConditionalSearchUserCommand
        {
            get
            {
                return _ConditionalSearchUserCommand ??
                    (_ConditionalSearchUserCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1;
                        var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                        RefreshUserList(userList.items, userList.TotalCount);

                    }));
            }

        }

        private ICommand _ResetConditionalSearchUserCommand;

        public ICommand ResetConditionalSearchUserCommand
        {
            get
            {
                return _ResetConditionalSearchUserCommand ??
                    (_ResetConditionalSearchUserCommand = new RelayCommand(() =>
                    {
                        // 清空所有查询条件
                        CurrentPage = 1;
                        SearchAccount = null;
                        SearchPhoneNum = null;
                        SearchStatus = null;
                        StartDate = null;
                        EndDate = null;
                        SearchDepId = 0;
                        DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
                        // 刷新用户列表
                        var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                        RefreshUserList(userList.items, userList.TotalCount);

                    }));
            }

        }



        #endregion

        #region 弹窗命令

        private ICommand _UserInfoDialogLoadedCommand;

        public ICommand UserInfoDialogLoadedCommand
        {
            get
            {
                return _UserInfoDialogLoadedCommand ??
                    (_UserInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }

        }

        private ICommand _UserInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭
        /// </summary>
        public ICommand UserInfoDialogUnloadedCommand
        {
            get
            {
                return _UserInfoDialogUnloadedCommand ??
                    (_UserInfoDialogUnloadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogUser = new UserDto(); // 清空用户
                        DialogAccountAndPasswordVisibility = Visibility.Visible; // 账号密码可见
                    }));
            }

        }

        private ICommand _AddUserInfoCommand;
        /// <summary>
        /// 添加用户
        /// </summary>
        public ICommand AddUserInfoCommand
        {
            get
            {
                return _AddUserInfoCommand ??
                    (_AddUserInfoCommand = new RelayCommand(() =>
                    {
                        // 清空部门列表,重新获取部门列表
                        DialogDepartmentList.Clear();
                        DialogDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
                        // 清空权限列表，重新获取权限列表
                        DialogRoleList.Clear();
                        List<Role> roleList = RoleHttpUtil.GetAllRole().items;
                        foreach (var item in roleList)
                        {
                            DialogRoleList.Add(new RoleDto() { Role = item });
                        }
                        // 清空岗位列表，重新获取岗位列表
                        DialogPostList.Clear();
                        List<Post> postList = PostHttpUtil.GetAllPost().items;
                        foreach (var post in postList)
                        {
                            DialogPostList.Add(new PostDto() { Post = post });
                        }
                        // 设置窗体标题
                        DialogTitle = "添加用户";
                        DialogUser = new UserDto(); // 实例化窗体用户类
                        userInfoDialog = Dialog.Show<UserInfoDialog>(); // 打开窗体

                    }));
            }

        }

        private ICommand _EditUserInfoCommand;
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        public ICommand EditUserInfoCommand
        {
            get
            {
                return _EditUserInfoCommand ??
                    (_EditUserInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedUser == null || SelectedUser.User == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择修改的用户！", "UserWarningMsg");
                            return;
                        }
                        // 隐藏账号和密码
                        DialogAccountAndPasswordVisibility = Visibility.Collapsed;
                        // 清空部门列表，获取部门列表
                        DialogDepartmentList.Clear();
                        DialogDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);

                        // 清空权限列表,获取所编辑的用户的权限列表
                        DialogRoleList.Clear();
                        foreach (var item in SelectedUser.Role)
                        {
                            DialogUser.Role.Add(new RoleDto() { Role = (Role)item.Role.Clone() });
                        }
                        // 遍历所有的权限，所编辑的用户的权限是否存在
                        foreach (var item in RoleHttpUtil.GetAllRole().items)
                        {
                            if (DialogUser.Role.Exists(r => item.Id == r.Role.Id))
                            {
                                // 存在则IsChecked= true
                                DialogRoleList.Add(new RoleDto() { Role = (Role)item.Clone(), IsChecked = true });
                            }
                            else
                            {
                                // 不存在则IsChecked= false
                                DialogRoleList.Add(new RoleDto() { Role = (Role)item.Clone(), IsChecked = false });
                            }
                        }

                        // 清空岗位列表， 获取所编辑的用户的岗位
                        DialogPostList.Clear();
                        SelectedUser.Post.ForEach(postDto => DialogUser.Post.Add(new PostDto() { Post = (Post)postDto.Post.Clone() }));
                        // 遍历所有的岗位，所编辑的用户的岗位是否存在
                        PostHttpUtil.GetAllPost().items.ForEach(post =>
                        {
                            if (DialogUser.Post.Exists(p => p.Post.Id == post.Id))
                            {
                                // 存在则IsChecked= true
                                DialogPostList.Add(new PostDto() { Post = (Post)post.Clone(), IsChecked = true });
                            }
                            else
                            {
                                // 不存在则IsChecked= false
                                DialogPostList.Add(new PostDto() { Post = (Post)post.Clone(), IsChecked = false });
                            }
                        });

                        DialogTitle = "修改用户";
                        DialogUser.User = (User)SelectedUser.User.Clone(); // 获取选择的用户
                        DialogUser.Department.Department = DepHttpUtil.GetDepartment(SelectedUser.User.Id); // 获取选择的用户的部门
                        userInfoDialog = Dialog.Show<UserInfoDialog>();
                    }));
            }

        }

        private ICommand _SubmitUserInfoCommand;
        /// <summary>
        /// 添加/修改确认
        /// </summary>
        public ICommand SubmitUserInfoCommand
        {
            get
            {
                return _SubmitUserInfoCommand ??
                    (_SubmitUserInfoCommand = new RelayCommand(() =>
                    {
                        // 信息校验

                        // 获取部门ID
                        DialogUser.User.dep_id = DialogUser.Department.Department.Id;

                        // 添加用户
                        if (DialogTitle == "添加用户")
                        {
                            if (string.IsNullOrEmpty(DialogUser.User.Account))
                            {
                                HandyControl.Controls.Growl.Warning("用户账号不能为空！", "UserInfoWarningMsg");
                                return;
                            }
                            if (string.IsNullOrEmpty(DialogUser.User.Password))
                            {
                                HandyControl.Controls.Growl.Warning("用户密码不能为空！", "UserInfoWarningMsg");
                                return;
                            }
                            if (string.IsNullOrEmpty(DialogUser.User.UserName))
                            {
                                HandyControl.Controls.Growl.Warning("用户名称不能为空！", "UserInfoWarningMsg");
                                return;
                            }
                            // 用户账号是否已经存在
                            if (UserHttpUtil.ExistAccount(DialogUser.User.Account))
                            {
                                HandyControl.Controls.Growl.Warning("用户账号已存在！", "UserInfoWarningMsg");
                                return;
                            }
                            DialogUser.User.insertTime = DateTime.Now; // 获取添加时间
                            try
                            {
                                int id = UserHttpUtil.AddUser(DialogUser.User);
                                if (id > 0)
                                {
                                    // 向中间表添加相关数据
                                    DialogUser.Role.ForEach(r =>
                                    {
                                        UserHttpUtil.AddUserRole(new UserRole() { Id = id, role_Id = r.Role.Id });
                                    });
                                    DialogUser.Post.ForEach(p =>
                                    {
                                        UserHttpUtil.AddUserPost(new UserPost() { Id = id, post_Id = p.Post.Id });
                                    });

                                    // 刷新数据
                                    var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                                    RefreshUserList(userList.items, userList.TotalCount);
                                    userInfoDialog.Close(); // 关闭窗体
                                    HandyControl.Controls.Growl.Success($"用户添加成功！", "UserSuccessMsg");
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning($"添加失败,请稍后重试", "UserWarningMsg");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                HandyControl.Controls.Growl.Error($"添加失败,出现异常错误，详情：{ex.Message}！", "UserErrorMsg");
                                return;
                            }
                        }
                        else if (DialogTitle == "修改用户")
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(DialogUser.User.UserName))
                                {
                                    HandyControl.Controls.Growl.Warning("用户名称不能为空！", "UserInfoWarningMsg");
                                    return;
                                }

                                var result = UserHttpUtil.UpdateUser(DialogUser.User); // 修改
                                if (result) // 修改成功
                                {
                                    // 获取用户 角色权限 信息
                                    List<Role> roles = UserHttpUtil.GetUserRole(DialogUser.User.Id).items;
                                    foreach (var item in DialogRoleList)
                                    {
                                        // 是否勾选
                                        if (item.IsChecked)
                                        {
                                            // 勾选了不存在的，则添加到中间表中
                                            if (!roles.Exists(r => r.Id == item.Role.Id))
                                            {
                                                UserHttpUtil.AddUserRole(new UserRole() { Id = SelectedUser.User.Id, role_Id = item.Role.Id });
                                            }
                                        }
                                        else
                                        {
                                            // //删除的角色，需要在中间表中删除
                                            if (roles.Exists(r => r.Id == item.Role.Id))
                                            {
                                                UserHttpUtil.DeleteUserRole(SelectedUser.User.Id, item.Role.Id);
                                            }
                                        }
                                    }
                                    // 刷新
                                    var userList = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                                    RefreshUserList(userList.items, userList.TotalCount);
                                    userInfoDialog.Close(); // 关闭窗体
                                    HandyControl.Controls.Growl.Success($"用户修改成功！", "UserSuccessMsg");
                                }
                                else // 修改失败
                                {
                                    HandyControl.Controls.Growl.Warning($"修改失败,请稍后重试", "UserWarningMsg");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                HandyControl.Controls.Growl.Error($"修改失败,出现异常错误，详情：{ex.Message}！", "UserErrorMsg");
                                return;
                            }
                        }

                    }));
            }
        }

        private ICommand _ResetUserPasswordCommand;
        /// <summary>
        /// 重置密码 窗体
        /// </summary>
        public ICommand ResetUserPasswordCommand
        {
            get
            {
                return _ResetUserPasswordCommand ??
                    (_ResetUserPasswordCommand = new RelayCommand(() =>
                    {
                        DialogPasswordTitle = $"请输入【{SelectedUser.User.Account}】的新密码";
                        resetPasswordDialog = Dialog.Show<ResetPasswordDialog>();
                    }));
            }
        }

        private ICommand _SubmitPasswordCommand;
        /// <summary>
        /// 重置密码弹窗确认按钮命令
        /// </summary>
        public ICommand SubmitPasswordCommand
        {
            get
            {
                return _SubmitPasswordCommand ??
                    (_SubmitPasswordCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (ConfirmPassword != DialogPassword)
                            {
                                return;
                            }
                            
                            SelectedUser.User.Password = DialogPassword;
                            var result = UserHttpUtil.UpdateUser(SelectedUser.User);
                            if (result)
                            {
                                resetPasswordDialog.Close(); // 关闭窗口
                                DialogPassword = "";
                                ConfirmPassword = "";
                                HandyControl.Controls.Growl.Success($"用户密码重置成功！", "UserSuccessMsg");
                            }
                            else // 修改失败
                            {
                                HandyControl.Controls.Growl.Warning($"修改失败,请稍后重试", "UserWarningMsg");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"修改失败,出现异常错误，详情：{ex.Message}！", "UserErrorMsg");
                            return; ;
                        }

                    }));
            }
        }


        #endregion

        #region 分页命令

        private ICommand _PerPageCountChangedCommand;
        /// <summary>
        /// 每页容量改变
        /// </summary>
        public ICommand PerPageCountChangedCommand
        {
            get
            {
                return _PerPageCountChangedCommand ??
                    (_PerPageCountChangedCommand = new RelayCommand(() =>
                    {
                        // 刷新列表
                        CurrentPage = 1;
                        var users = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                        RefreshUserList(users.items, users.TotalCount);
                    }));
            }

        }


        private ICommand _UserRolePerPageCountChangedCommand;
        /// <summary>
        /// 用户角色权限 每页容量改变
        /// </summary>
        public ICommand UserRolePerPageCountChangedCommand
        {
            get
            {
                return _UserRolePerPageCountChangedCommand ??
                    (_UserRolePerPageCountChangedCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1;
                        GetUserRoleListMethod(null);
                    }));
            }

        }

        private ICommand _PageUpdatedCommand;
        /// <summary>
        /// 分页跳转命令
        /// </summary>
        public ICommand PageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        // CurrentPage 已经与前端绑定
                        var users = UserHttpUtil.GetUsers(SearchAccount, SearchPhoneNum, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount, SearchDepId);
                        RefreshUserList(users.items, users.TotalCount);
                    }));
            }
        }

        private ICommand _UserRolePageUpdatedCommand;
        /// <summary>
        /// 用户角色权限 分页跳转命令
        /// </summary>
        public ICommand UserRolePageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        GetUserRoleListMethod(null);
                    }));
            }
        }


        #endregion

        #region 其他命令

        /// <summary>
        /// 隐藏搜索栏命令
        /// </summary>
        private ICommand _ChangeSearchPanelVisCommand;

        public ICommand ChangeSearchPanelVisCommand
        {
            get
            {
                return _ChangeSearchPanelVisCommand
                    ?? (_ChangeSearchPanelVisCommand = new RelayCommand(
                    () =>
                    {
                        SearchPanelVis = (SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
                    }));
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新用户列表同时修改分页数据
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void RefreshUserList(List<User> allUserList, int totalCount)
        {
            TotalCount = totalCount; // 获取总数
            if (TotalCount % PerPageCount == 0)
            {
                TotalPageCount = TotalCount / PerPageCount; // 获取总页数
            }
            else
            {
                TotalPageCount = (TotalCount / PerPageCount) + 1;
            }
            if (CurrentPage > TotalPageCount)
            {
                CurrentPage = TotalPageCount;
            }

            // 清空数据列表
            UserList.Clear();
            // 循环用户列表
            allUserList.ForEach(u =>
            {
                // 添加到中间表中
                List<RoleDto> roles = new List<RoleDto>();
                UserHttpUtil.GetUserRole(u.Id).items.ForEach(r => roles.Add(new RoleDto() { Role = r }));

                List<PostDto> posts = new List<PostDto>();
                UserHttpUtil.GetUserPost(u.Id).items.ForEach(p => posts.Add(new PostDto() { Post = p }));

                // 获取用户列表
                UserList.Add(new UserDto()
                {
                    User = u,
                    Post = posts,
                    Role = roles,
                    Department = new DepartmentDto() { Department = DepHttpUtil.GetDepartment(u.dep_id) }
                });
            });

        }

        /// <summary>
        /// 修改用户状态为启用
        /// </summary>
        /// <param name="status"></param>
        private void CheckedUserStatusMethod(string status)
        {
            try
            {
                SelectedUser.User.Status = bool.Parse(status);
                var result = UserHttpUtil.UpdateUser(SelectedUser.User);
                if (result)
                {
                    HandyControl.Controls.Growl.Success($"{SelectedUser.User.Account}用户状态修改成功！", "UserSuccessMsg");
                }
                else
                {
                    HandyControl.Controls.Growl.Warning("修改失败！", "UserWarningMsg");
                }
            }
            catch (Exception ex)
            {
                HandyControl.Controls.Growl.Error($"修改失败,出现异常错误，详情：{ex.Message}！", "UserErrorMsg");
                return; ;
            }

        }

        /// <summary>
        /// 修改用户状态为禁用
        /// </summary>
        /// <param name="status"></param>
        private void UncheckedUserStatusMethod(string status)
        {
            try
            {
                SelectedUser.User.Status = bool.Parse(status);
                var result = UserHttpUtil.UpdateUser(SelectedUser.User);
                if (result)
                {
                    HandyControl.Controls.Growl.Success($"{SelectedUser.User.Account}用户状态修改成功！", "UserSuccessMsg");
                }
                else
                {
                    HandyControl.Controls.Growl.Warning("修改失败！", "UserWarningMsg");
                }
            }
            catch (Exception ex)
            {
                HandyControl.Controls.Growl.Error($"修改失败,出现异常错误，详情：{ex.Message}！", "UserErrorMsg");
                return; ;
            }
        }

        /// <summary>
        /// 获取 用户角色权限 列表
        /// </summary>
        /// <param name="obj"></param>
        private void GetUserRoleListMethod(object obj)
        {
            // 获取 当前用户 的 角色权限列表
            List<Role> roles = UserHttpUtil.GetUserRole(SelectedUser.User.Id).items;

            RoleList.Clear(); // 清空 用户角色权限列表
            var allRole = RoleHttpUtil.GetAllRole(); //获取 所有 用户角色权限列表
            // 获取页码
            if (UserRoleTotalCount % UserRolePerPageCount == 0)
            {
                UserRoleTotalPageCount = UserRoleTotalPageCount / UserRolePerPageCount;
            }
            else
            {
                UserRoleTotalPageCount = (UserRoleTotalPageCount / UserRolePerPageCount) + 1;
            }
            if (UserRoleCurrentPage > UserRoleTotalPageCount)
            {
                UserRoleCurrentPage = UserRoleTotalPageCount;
            }
            allRole.items.Skip((UserRoleCurrentPage - 1) * UserRolePerPageCount).
                Take(UserRolePerPageCount).ToList().
                ForEach(t => RoleList.Add(new RoleDto() { Role = (Role)t.Clone(), IsChecked = roles.Exists(r => r.Id == t.Id) }));
        }

        /// <summary>
        /// 获取子部门节点列表
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="tempList"></param>
        /// <returns></returns>
        private List<int> GetChildDepartmentIdsList(DepartmentDto dep, List<int> tempList)
        {
            foreach (var item in dep.ChildDepartmentList)
            {
                tempList.Add(item.Department.Id);
                GetChildDepartmentIdsList(item, tempList);
            }
            return tempList;
        }

        #endregion

    }
}
