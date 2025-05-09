using CompanyManagerSystem.View.subView.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http.SystemManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class DepartmentViewModel : ViewModelBase
    {

        public DepartmentViewModel()
        {
            // this: 接收者
            // DepartmentCheckChanged：信息标识
            // DepartmentCheckChangedMethod ： 接收后执行的方法
            Messenger.Default.Register<DepartmentDto>(this, "DepartmentCheckChanged", DepartmentCheckChangedMethod);
            // 获取所有部门列表
            DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
        }
        #region 属性
        #region 部门属性
        private ObservableCollection<DepartmentDto> _DepartmentList = new ObservableCollection<DepartmentDto>();
        /// <summary>
        /// 部门列表
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
        private DepartmentDto _SelectedDepartment;
        /// <summary>
        /// 选择的部门
        /// </summary>
        public DepartmentDto SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set
            {
                _SelectedDepartment = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region 按钮属性
        private bool _FoldToggleButtonChecked;
        /// <summary>
        /// 展开
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
        #region 搜索属性
        private string _SearchDepName;
        /// <summary>
        /// 搜索的部门的名称
        /// </summary>
        public string SearchDepName
        {
            get { return _SearchDepName; }
            set
            {
                _SearchDepName = value;
                RaisePropertyChanged();
            }
        }
        private string _SearchStatus;
        /// <summary>
        /// 搜索的部门的状态
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
        #region 弹框属性

        /// <summary>
        /// 部门弹窗（添加/修改）
        /// </summary>
        private Dialog departmentInfoDialog;

        private string _DialogTitle;
        /// <summary>
        /// 弹窗标题-弹窗的参数 
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

        private DepartmentDto _DialodDepartment = new DepartmentDto();
        /// <summary>
        /// 部门-弹窗的参数
        /// </summary>
        public DepartmentDto DialogDepartment
        {
            get { return _DialodDepartment; }
            set
            {
                _DialodDepartment = value;
                RaisePropertyChanged();
            }
        }

        private DepartmentDto _DialodParentDepartment = new DepartmentDto();
        /// <summary>
        /// 父部门-弹窗的参数
        /// </summary>
        public DepartmentDto DialogParentDepartment
        {
            get { return _DialodParentDepartment; }
            set
            {
                _DialodParentDepartment = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<DepartmentDto> _DialodParentDepartmentList = new ObservableCollection<DepartmentDto>();
        /// <summary>
        /// 父部门列表-弹窗的参数
        /// </summary>
        public ObservableCollection<DepartmentDto> DialogParentDepartmentList
        {
            get { return _DialodParentDepartmentList; }
            set
            {
                _DialodParentDepartmentList = value;
                RaisePropertyChanged();
            }
        }
        private Visibility _DialogParentDepartmentVisibility = Visibility.Visible;
        /// <summary>
        /// 父部门隐藏-弹窗的参数
        /// </summary>
        public Visibility DialogParentDepartmentVisibility
        {
            get { return _DialogParentDepartmentVisibility; }
            set
            {
                _DialogParentDepartmentVisibility = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region 其他属性
        private Visibility _SearchPanelVis = Visibility.Visible;
        /// <summary>
        /// 搜索框可用性
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
        #region 部门命令

        private ICommand _DeleteDepartmentInfoCommand;
        /// <summary>
        /// 删除部门命令
        /// </summary>
        public ICommand DeleteDepartmentInfoCommand
        {
            get
            {
                return _DeleteDepartmentInfoCommand ??
                    (_DeleteDepartmentInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (HandyControl.Controls.MessageBox.Show($"确定要删除部门[{SelectedDepartment.Department.DepName}]吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (SelectedDepartment.ChildDepartmentList.Count > 0)
                                {
                                    HandyControl.Controls.Growl.Warning($"部门[{SelectedDepartment.Department.DepName}]有子部门,删除失败！", "DepartmentWarningMsg");
                                    return;
                                }
                                var result = DepHttpUtil.DeleteDepartment(SelectedDepartment.Department.Id);
                                // 是否删除成功
                                if (result)
                                {
                                    //删除数据库中的该用户的信息，并刷新页面
                                    DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);

                                    HandyControl.Controls.Growl.Success($"部门删除成功！", "DepartmentSuccessMsg");
                                    FoldToggleButtonChecked = false; // 折叠部门列表
                                    // 向信息中心发送刷新部门列表消息，通知其他视图模型及时刷新数据
                                    Messenger.Default.Send<string>(null, "RefreshDepList");
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning($"部门删除失败！", "DepartmentWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"部门删除发生异常，详情：{ex.Message}！", "DepartmentErrorMsg");
                            return;
                        }
                    }));
            }
        }
        #endregion
        #region 按钮命令

        private ICommand _FoldDepartmentInfoCommand;
        /// <summary>
        /// 展开部门命令
        /// </summary>
        public ICommand FoldDepartmentInfoCommand
        {
            get
            {
                return _FoldDepartmentInfoCommand ??
                    (_FoldDepartmentInfoCommand = new RelayCommand(() =>
                    {
                        // 临时中转表
                        // 而不是直接对DepartmentList赋值，否则触发 CollectionChanged 事件（ObservableCollection自带的通知事件），导致通知绑定的 UI 进行更新，增加内存消耗
                        // 同时也避免forea抛出异常的情况
                        List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            tempMenuList.Add(item);
                            List<DepartmentDto> childMenuList = GetChildDepartmentDtos(item, tempMenuList);
                        }
                        foreach (DepartmentDto item in tempMenuList)
                        {
                            item.IsChecked = true; // 设置展开状态
                        }
                        DepartmentList.Clear(); // 清空原部门列表
                        foreach (DepartmentDto item in tempMenuList)
                        {
                            DepartmentList.Add(item);
                        }
                    }));
            }
        }

        private ICommand _UnFoldDepartmentInfoCommand;
        /// <summary>
        /// 折叠部门命令
        /// </summary>
        public ICommand UnFoldDepartmentInfoCommand
        {
            get
            {
                return _UnFoldDepartmentInfoCommand ??
                    (_UnFoldDepartmentInfoCommand = new RelayCommand(() =>
                    {
                        // 1.使用中转表存储当前部门列表，并将其改为折叠状态
                        List<DepartmentDto> currentDepList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            currentDepList.Add(item);
                        }
                        DepartmentList.Clear();
                        foreach (DepartmentDto item in currentDepList)
                        {
                            item.IsChecked = false;
                            DepartmentList.Add(item);
                        }

                        // 2. 获取所有顶层部门，
                        List<DepartmentDto> topDepList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            //遍历 DepartmentList，对于每个部门，如果它的 parent_id 为 0（表示它是顶层部门），
                            //或者在 DepartmentList 中不存在其父部门（有点独立的意思），则将其添加到 tempDepList 中。
                            if (item.Department.parent_id == 0 || !DepartmentList.ToList().Exists(t => t.Department.Id == item.Department.parent_id))
                            {
                                topDepList.Add(item);
                            }
                        }
                        DepartmentList.Clear(); //将列表清空
                        // 将 顶层部门 添加到 列表中，至此实现了全部部门折叠的状态
                        foreach (DepartmentDto item in topDepList)
                        {
                            DepartmentList.Add(item);
                        }
                    }));
            }
        }
        #endregion
        #region 搜索命令

        private ICommand _ConditionalSearchDepartmentCommand;
        /// <summary>
        /// 条件搜索部门命令
        /// </summary>
        public ICommand ConditionalSearchDepartmentCommand
        {
            get
            {
                return _ConditionalSearchDepartmentCommand
                    ?? (_ConditionalSearchDepartmentCommand = new RelayCommand(
                    () =>
                    {
                        DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
                        FoldToggleButtonChecked = false;
                    }));
            }
        }

        private ICommand _ResetConditionalSearchDepartmentCommand;
        /// <summary>
        /// 重置条件搜索部门命令
        /// </summary>
        public ICommand ResetConditionalSearchDepartmentCommand
        {
            get
            {
                return _ResetConditionalSearchDepartmentCommand
                    ?? (_ResetConditionalSearchDepartmentCommand = new RelayCommand(
                    () =>
                    {
                        SearchDepName = null;
                        SearchStatus = null;
                        DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
                        FoldToggleButtonChecked = false;
                    }));
            }
        }
        #endregion
        #region 弹框命令

        private ICommand _DepartmentInfoDialogLoadedCommand;
        /// <summary>
        /// 弹框加载命令
        /// </summary>
        public ICommand DepartmentInfoDialogLoadedCommand
        {
            get
            {
                return _DepartmentInfoDialogLoadedCommand
                    ?? (_DepartmentInfoDialogLoadedCommand = new RelayCommand(
                    () =>
                    {

                    }));
            }
        }

        private ICommand _DepartmentInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹框关闭命令
        /// </summary>
        public ICommand DepartmentInfoDialogUnloadedCommand
        {
            get
            {
                return _DepartmentInfoDialogUnloadedCommand
                    ?? (_DepartmentInfoDialogUnloadedCommand = new RelayCommand(
                    () =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogParentDepartmentVisibility = Visibility.Visible;
                        DialogDepartment = new DepartmentDto();
                    }));
            }
        }

        private ICommand _AddDepartmentInfoCommand;
        /// <summary>
        /// 新增部门弹框命令
        /// </summary>
        public ICommand AddDepartmentInfoCommand
        {
            get
            {
                return _AddDepartmentInfoCommand
                    ?? (_AddDepartmentInfoCommand = new RelayCommand<string>(
                    (str) =>
                    {
                        if (str == "HasParentDepartment")
                        {
                            DialogParentDepartment = SelectedDepartment; // 设置 窗体父部门参数 为 当前选择的部门
                        }
                        else if (str == "NoParentDepartment")
                        {
                            DialogParentDepartment = new DepartmentDto();
                            DialogParentDepartmentVisibility = Visibility.Hidden; // 没有父部门则将父部门隐藏
                        }
                        DialogTitle = "添加部门"; // 窗体标题
                        DialogDepartment = new DepartmentDto();
                        // 清空 窗体父部门列表 并 重新获取
                        DialogParentDepartmentList.Clear();
                        DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
                        departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>(); // 打开窗体
                    }));
            }
        }

        private ICommand _EditDepartmentInfoCommand;
        /// <summary>   
        /// 修改部门弹框命令
        /// </summary>
        public ICommand EditDepartmentInfoCommand
        {
            get
            {
                return _EditDepartmentInfoCommand ??
                    (_EditDepartmentInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            DialogTitle = "修改部门";
                            // 清空 窗体父部门列表 并 重新获取
                            DialogParentDepartmentList.Clear();
                            DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);

                            DialogDepartment.Department = (Department)SelectedDepartment.Department.Clone();
                            // 如果是根部门，则将窗体根部门选择列表隐藏
                            DialogParentDepartmentVisibility = (SelectedDepartment.Department.parent_id == 0 ? Visibility.Collapsed : Visibility.Visible);
                            DialogParentDepartment.Department = DepHttpUtil.GetDepartment(SelectedDepartment.Department.parent_id);
                            departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>();
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常错误，详情：{ex.Message}", "DepartmentErrorMsg");
                            return;
                        }

                    }));
            }
        }

        private ICommand _SubmitDepartmentInfoCommand;
        /// <summary>
        /// 确认修改命令
        /// </summary>
        public ICommand SubmitDepartmentInfoCommand
        {
            get
            {
                return _SubmitDepartmentInfoCommand ?? 
                    (_SubmitDepartmentInfoCommand = new RelayCommand(() =>
                    {
                        if (DialogParentDepartment.Department != null && DialogParentDepartment.Department.Id == 0)
                        {
                            HandyControl.Controls.Growl.Warning("上级部门不能为空！", "DepartmentInfoWarningMsg");
                            return;
                        }
                        else if (DialogParentDepartment.Department != null)
                        {
                            DialogDepartment.Department.parent_id = DialogParentDepartment.Department.Id;
                        }
                        else
                        {
                            DialogDepartment.Department.parent_id = 0;
                        }
                        if (string.IsNullOrEmpty(DialogDepartment.Department.DepName))
                        {
                            HandyControl.Controls.Growl.Warning("部门名称不能为空！", "DepartmentInfoWarningMsg");
                            return;
                        }


                        try
                        {
                            // 添加部门
                            if (DialogTitle == "添加部门")
                            {
                                if (DepHttpUtil.AddDepartment(DialogDepartment.Department))
                                {
                                    DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
                                    departmentInfoDialog.Close();
                                    FoldToggleButtonChecked = false; // 折叠状态
                                    HandyControl.Controls.Growl.Success($"部门添加成功！", "DepartmentSuccessMsg");

                                    Messenger.Default.Send<string>(null, "RefreshDepList"); // 发送更新部门列表信息
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("添加失败！", "DepartmentInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改部门
                            else if (DialogTitle == "修改部门")
                            {
                                if (DepHttpUtil.UpdateDepartment(DialogDepartment.Department))
                                {
                                    DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
                                    departmentInfoDialog.Close();
                                    FoldToggleButtonChecked = false;
                                    HandyControl.Controls.Growl.Success($"部门修改成功！", "DepartmentSuccessMsg");

                                    Messenger.Default.Send<string>(null, "RefreshDepList");
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("修改失败！", "DepartmentInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常错误，详情{ex.Message }", "DepartmentInfoErrorMsg");
                            return;
                        }
                    }));
            }
        }
        #endregion
        #region 其他命令

        private ICommand _ChangeSearchPanelVisCommand;
        /// <summary>
        /// 隐藏搜索栏命令
        /// </summary>
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
        /// 展开/折叠单个菜单方法
        /// </summary>
        /// <param name="barModel"></param>
        public void DepartmentCheckChangedMethod(DepartmentDto department)
        {
            int index = DepartmentList.IndexOf(department) + 1;
            if (department.IsChecked)
            {
                if (department.ChildDepartmentList == null)
                {
                    return;
                }
                foreach (DepartmentDto item in department.ChildDepartmentList)
                {
                    item.MarginLeft = department.MarginLeft + 50;
                    DepartmentList.Insert(index++, item);
                }
            }
            else
            {
                List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
                foreach (DepartmentDto item in DepartmentList)
                {
                    if (item.Department.parent_id == department.Department.Id)
                    {
                        tempMenuList.Add(item);
                    }
                }
                foreach (DepartmentDto item in tempMenuList)
                {
                    DepartmentList.Remove(item);
                }
            }
        }
        /// <summary>
        /// 收集指定部门的所有子部门（用于 一键展开部门列表）
        /// </summary>
        /// <param name="department"></param>
        /// <param name="tempList"></param>
        /// <returns></returns>
        private List<DepartmentDto> GetChildDepartmentDtos(DepartmentDto department, List<DepartmentDto> tempList)
        {
            // 列表不为空同时总数大于0，还要是未展开状态
            if (department.ChildDepartmentList != null && department.ChildDepartmentList.Count > 0 && department.IsChecked == false)
            {
                foreach (DepartmentDto child in department.ChildDepartmentList)
                {
                    tempList.Add(child);
                    GetChildDepartmentDtos(child, tempList);
                }
            }
            return tempList;
        }
        #endregion
    }


}
