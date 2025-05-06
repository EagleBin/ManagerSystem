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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class DepartmentViewModel : ViewModelBase
    {

        public DepartmentViewModel()
        {
            Messenger.Default.Register<DepartmentDto>(this, "DepartmentCheckChanged", DepartmentCheckChangedMethod);

            DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
        }
        #region 属性
        #region 部门属性
        private ObservableCollection<DepartmentDto> _DepartmentList = new ObservableCollection<DepartmentDto>();

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
        private Dialog departmentInfoDialog;
        private string _DialogTitle;

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
        /// <summary>
        /// 删除部门命令
        /// </summary>
        private ICommand _DeleteDepartmentInfoCommand;

        public ICommand DeleteDepartmentInfoCommand
        {
            get
            {
                return _DeleteDepartmentInfoCommand
                    ?? (_DeleteDepartmentInfoCommand = new RelayCommand(
                    () =>
                    {
                        if (HandyControl.Controls.MessageBox.Show($"确定要删除部门[{SelectedDepartment.Department.DepName}]吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            if (SelectedDepartment.ChildDepartmentList.Count > 0)
                            {
                                HandyControl.Controls.Growl.Warning($"部门[{SelectedDepartment.Department.DepName}]有子部门,删除失败！", "DepartmentWarningMsg");
                                return;
                            }
                            DepHttpUtil.DeleteDepartment(SelectedDepartment.Department.Id);
                            //删除数据库中的该用户的信息，并刷新页面
                            DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);

                            HandyControl.Controls.Growl.Success($"部门删除成功！", "DepartmentSuccessMsg");
                            FoldToggleButtonChecked = false;

                            Messenger.Default.Send<string>(null, "RefreshDepList");
                        }
                    }));
            }
        }
        #endregion
        #region 按钮命令
        /// <summary>
        /// 展开部门命令
        /// </summary>
        private ICommand _FoldDepartmentInfoCommand;

        public ICommand FoldDepartmentInfoCommand
        {
            get
            {
                return _FoldDepartmentInfoCommand
                    ?? (_FoldDepartmentInfoCommand = new RelayCommand(
                    () =>
                    {
                        List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            tempMenuList.Add(item);
                            List<DepartmentDto> childMenuList = GetChildDepartmentDtos(item, tempMenuList);
                        }
                        foreach (DepartmentDto item in tempMenuList)
                        {
                            item.IsChecked = true;
                        }
                        DepartmentList.Clear();
                        foreach (DepartmentDto item in tempMenuList)
                        {
                            DepartmentList.Add(item);
                        }
                    }));
            }
        }
        /// <summary>
		/// 折叠部门命令
		/// </summary>
		private ICommand _UnFoldDepartmentInfoCommand;

        public ICommand UnFoldDepartmentInfoCommand
        {
            get
            {
                return _UnFoldDepartmentInfoCommand
                    ?? (_UnFoldDepartmentInfoCommand = new RelayCommand(
                    () =>
                    {
                        List<DepartmentDto> tempList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            tempList.Add(item);
                        }
                        DepartmentList.Clear();
                        foreach (DepartmentDto item in tempList)
                        {
                            item.IsChecked = false;
                            DepartmentList.Add(item);
                        }

                        List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
                        foreach (DepartmentDto item in DepartmentList)
                        {
                            if (item.Department.parent_id == 0 || !DepartmentList.ToList().Exists(t => t.Department.Id == item.Department.parent_id))
                            {
                                tempMenuList.Add(item);
                            }
                        }
                        DepartmentList.Clear();
                        foreach (DepartmentDto item in tempMenuList)
                        {
                            DepartmentList.Add(item);
                        }
                    }));
            }
        }
        #endregion
        #region 搜索命令
        /// <summary>
        /// 条件搜索部门命令
        /// </summary>
        private ICommand _ConditionalSearchDepartmentCommand;

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
        /// <summary>
        /// 重置条件搜索部门命令
        /// </summary>
        private ICommand _ResetConditionalSearchDepartmentCommand;

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
        /// <summary>
		/// 弹框加载命令
		/// </summary>
		private ICommand _DepartmentInfoDialogLoadedCommand;

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
        /// <summary>
        /// 弹框关闭命令
        /// </summary>
        private ICommand _DepartmentInfoDialogUnloadedCommand;

        public ICommand DepartmentInfoDialogUnloadedCommand
        {
            get
            {
                return _DepartmentInfoDialogUnloadedCommand
                    ?? (_DepartmentInfoDialogUnloadedCommand = new RelayCommand(
                    () =>
                    {
                        DialogTitle = "";
                        DialogParentDepartmentVisibility = Visibility.Visible;
                        DialogDepartment = new DepartmentDto();
                    }));
            }
        }
        /// <summary>
        /// 新增部门弹框命令
        /// </summary>
        private ICommand _AddDepartmentInfoCommand;

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
                            DialogParentDepartment = SelectedDepartment;
                        }
                        else if (str == "NoParentDepartment")
                        {
                            DialogParentDepartment = new DepartmentDto();
                        }
                        DialogTitle = "添加部门";
                        DialogDepartment = new DepartmentDto();
                        DialogParentDepartmentList.Clear();
                        DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
                        departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>();
                    }));
            }
        }
        /// <summary>   
        /// 修改部门弹框命令
        /// </summary>
        private ICommand _EditDepartmentInfoCommand;

        public ICommand EditDepartmentInfoCommand
        {
            get
            {
                return _EditDepartmentInfoCommand
                    ?? (_EditDepartmentInfoCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            DialogTitle = "修改部门";
                            DialogParentDepartmentList.Clear();
                            DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
                            DialogDepartment.Department = (Department)SelectedDepartment.Department.Clone();
                            DialogParentDepartmentVisibility = (SelectedDepartment.Department.parent_id == 0 ? Visibility.Collapsed : Visibility.Visible);
                            DialogParentDepartment.Department = DepHttpUtil.GetDepartment(SelectedDepartment.Department.parent_id);
                            departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>();
                        }
                        catch (Exception ex)
                        {

                            System.Windows.MessageBox.Show("服务器繁忙请稍后...");
                        }
                        
                    }));
            }
        }
        /// <summary>
        /// 确认修改命令
        /// </summary>
        private ICommand _SubmitDepartmentInfoCommand;

        public ICommand SubmitDepartmentInfoCommand
        {
            get
            {
                return _SubmitDepartmentInfoCommand
                    ?? (_SubmitDepartmentInfoCommand = new RelayCommand(
                    () =>
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


                        if (DialogTitle == "添加部门")
                        {
                            if (DepHttpUtil.AddDepartment(DialogDepartment.Department))
                            {
                                DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
                                departmentInfoDialog.Close();
                                FoldToggleButtonChecked = false;
                                HandyControl.Controls.Growl.Success($"部门添加成功！", "DepartmentSuccessMsg");

                                Messenger.Default.Send<string>(null, "RefreshDepList");
                            }
                        }
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
                        }
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
        private List<DepartmentDto> GetChildDepartmentDtos(DepartmentDto department, List<DepartmentDto> tempList)
        {
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



        //public DepartmentViewModel()
        //{

        //}

        //#region 属性

        //#region 部门属性

        //private ObservableCollection<DepartmentDto> _DepartmentList;
        ///// <summary>
        ///// 部门列表
        ///// </summary>
        //public ObservableCollection<DepartmentDto> DepartmentList
        //{
        //    get { return _DepartmentList; }
        //    set
        //    {
        //        _DepartmentList = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //private DepartmentDto _SelectedDepartment;
        ///// <summary>
        ///// 选择的部门
        ///// </summary>
        //public DepartmentDto SelectedDepartment
        //{
        //    get { return _SelectedDepartment; }
        //    set
        //    {
        //        _SelectedDepartment = value;
        //        RaisePropertyChanged();
        //    }
        //}




        //#endregion

        //#region 按钮属性

        //private bool _FoldToggleButtonChecked;
        ///// <summary>
        ///// 是否展开按钮
        ///// </summary>
        //public bool FoldToggleButtonChecked
        //{
        //    get { return _FoldToggleButtonChecked; }
        //    set
        //    {
        //        _FoldToggleButtonChecked = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //#endregion

        //#region 搜索属性

        //private string _SearchDepName;
        ///// <summary>
        ///// 搜索的部门名称
        ///// </summary>
        //public string SearchDepName
        //{
        //    get { return _SearchDepName; }
        //    set
        //    {
        //        _SearchDepName = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //private string _SearchStatus;
        ///// <summary>
        ///// 搜索的状态
        ///// </summary>
        //public string SearchStatus
        //{
        //    get { return _SearchStatus; }
        //    set
        //    {
        //        _SearchStatus = value;
        //        RaisePropertyChanged();
        //    }
        //}



        //#endregion

        //#region 弹框属性
        ///// <summary>
        ///// 部门信息弹框
        ///// </summary>
        //private Dialog departmentInfoDialog;

        //private string _DialogTitle;
        ///// <summary>
        ///// 弹框标题
        ///// </summary>
        //public string DialogTitle
        //{
        //    get { return _DialogTitle; }
        //    set
        //    {
        //        _DialogTitle = value;
        //        RaisePropertyChanged();
        //    }
        //}


        //private DepartmentDto _DialogDepartment = new DepartmentDto();
        ///// <summary>
        ///// 弹框的部门
        ///// </summary>
        //public DepartmentDto DialogDepartment
        //{
        //    get { return _DialogDepartment; }
        //    set
        //    {
        //        _DialogDepartment = value;
        //        RaisePropertyChanged();
        //    }
        //}


        //private DepartmentDto _DialogParentDepartment = new DepartmentDto();
        ///// <summary>
        ///// 上级部门
        ///// </summary>
        //public DepartmentDto DialogParentDepartment
        //{
        //    get { return _DialogParentDepartment; }
        //    set
        //    {
        //        _DialogParentDepartment = value;
        //        RaisePropertyChanged();
        //    }
        //}


        //private ObservableCollection<DepartmentDto> _DialogParentDepartmentList = new ObservableCollection<DepartmentDto>();
        ///// <summary>
        ///// 上级部门列表
        ///// </summary>
        //public ObservableCollection<DepartmentDto> DialogParentDepartmentList
        //{
        //    get { return _DialogParentDepartmentList; }
        //    set
        //    {
        //        _DialogParentDepartmentList = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //private Visibility _DialogParentDepartmentVisibility = Visibility.Visible;

        //public Visibility DialogParentDepartmentVisibility
        //{
        //    get { return _DialogParentDepartmentVisibility; }
        //    set
        //    {
        //        _DialogParentDepartmentVisibility = value;
        //        RaisePropertyChanged();
        //    }
        //}



        //#endregion

        //#region 其他属性

        //private Visibility _SearchPanelVis = Visibility.Visible;
        ///// <summary>
        ///// 隐藏的搜索框的可见性
        ///// </summary>
        //public Visibility SearchPanelVis
        //{
        //    get { return _SearchPanelVis; }
        //    set { _SearchPanelVis = value; }
        //}


        //#endregion

        //#endregion

        //#region 命令

        //#region 部门命令


        //private ICommand _DeleteDepartmentInfoCommand;

        //public ICommand DeleteDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _DeleteDepartmentInfoCommand ?? (_DeleteDepartmentInfoCommand = new RelayCommand(() =>
        //        {
        //            var result = HandyControl.Controls.MessageBox.Show($"是否删除部门[{SelectedDepartment.Department.DepName}]?", "提示",
        //                MessageBoxButton.YesNo, MessageBoxImage.Question);
        //            if (result == MessageBoxResult.Yes)
        //            {
        //                // 存在子部门删除失败
        //                if (SelectedDepartment.ChildDepartmentList.Count > 0)
        //                {
        //                    HandyControl.Controls.Growl.Warning($"部门[{SelectedDepartment.Department.DepName}]存在子部门，删除失败", "DepartmentWarningMsg");
        //                    return;
        //                }
        //                DepHttpUtil.DeleteDepartment(SelectedDepartment.Department.Id);
        //                // 刷新列表
        //                DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
        //                // 信息提示
        //                HandyControl.Controls.Growl.Success("部门删除成功！", "DepartmentSuccessMsg");
        //                FoldToggleButtonChecked = false;

        //                Messenger.Default.Send<string>(null, "RefreshDepList");
        //            }
        //        }));
        //    }

        //}

        //#endregion

        //#region 按钮命令

        //private ICommand _FoldDepartmentInfoCommand;
        ///// <summary>
        ///// 展开部门命令
        ///// </summary>
        //public ICommand FoldDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _FoldDepartmentInfoCommand ?? (_FoldDepartmentInfoCommand = new RelayCommand(() =>
        //        {
        //            if (DepartmentList == null)
        //            {
        //                return;
        //            }
        //            List<DepartmentDto> tempDepList = new List<DepartmentDto>();
        //            foreach (var item in DepartmentList)
        //            {
        //                tempDepList.Add(item);
        //                GetChildDepartmentDtos(item, tempDepList);
        //            }
        //            foreach (var item in tempDepList)
        //            {
        //                item.IsChecked = true;
        //            }
        //            DepartmentList.Clear();
        //            foreach (var item in tempDepList)
        //            {
        //                DepartmentList.Add(item);
        //            }
        //        }));
        //    }
        //}

        //private ICommand _UnFoldDepartmentInfoCommand;
        ///// <summary>
        ///// 折叠部门命令
        ///// </summary>
        //public ICommand UnFoldDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _UnFoldDepartmentInfoCommand ?? (_UnFoldDepartmentInfoCommand = new RelayCommand(() =>
        //        {
        //            List<DepartmentDto> tempDepList = new List<DepartmentDto>();
        //            foreach (var item in DepartmentList)
        //            {
        //                tempDepList.Add(item);
        //            }
        //            DepartmentList.Clear();
        //            foreach (var item in tempDepList)
        //            {
        //                item.IsChecked = false;
        //                DepartmentList.Add(item);
        //            }

        //            List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
        //            foreach (DepartmentDto item in DepartmentList)
        //            {
        //                if (item.Department.parent_id == 0 || !DepartmentList.ToList().Exists(t => t.Department.Id == item.Department.parent_id))
        //                {
        //                    tempMenuList.Add(item);
        //                }
        //            }
        //            DepartmentList.Clear();
        //            foreach (DepartmentDto item in tempMenuList)
        //            {
        //                DepartmentList.Add(item);
        //            }
        //        }));
        //    }

        //}

        //#endregion

        //#region 搜索命令

        //private ICommand _ConditionalSearchDepartmentCommand;
        ///// <summary>
        ///// 条件搜索部门命令
        ///// </summary>
        //public ICommand ConditionalSearchDepartmentCommand
        //{
        //    get
        //    {
        //        return _ConditionalSearchDepartmentCommand ?? (_ConditionalSearchDepartmentCommand = new RelayCommand(() =>
        //        {
        //            var searchResult = DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items;
        //            DepartmentList = TreeListHelper.RefreshDeplist(searchResult);
        //            FoldToggleButtonChecked = false;
        //        }));
        //    }

        //}


        //private ICommand _ResetConditionalSearchDepartmentCommand;
        ///// <summary>
        ///// 重置条件搜索部门命令
        ///// </summary>
        //public ICommand ResetConditionalSearchDepartmentCommand
        //{
        //    get
        //    {
        //        return _ResetConditionalSearchDepartmentCommand ?? (_ResetConditionalSearchDepartmentCommand = new RelayCommand(() =>
        //        {
        //            SearchDepName = null;
        //            SearchStatus = null;
        //            var searchResult = DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items;
        //            DepartmentList = TreeListHelper.RefreshDeplist(searchResult);
        //            FoldToggleButtonChecked = false;
        //        }));
        //    }

        //}



        //#endregion

        //#region 弹框命令

        //private ICommand _DepartmentInfoDialogUnloadedCommand;
        ///// <summary>
        ///// 弹框加载命令
        ///// </summary>
        //public ICommand DepartmentInfoDialogLoadedCommand
        //{
        //    get
        //    {
        //        return _DepartmentInfoDialogLoadedCommand ?? (_DepartmentInfoDialogLoadedCommand = new RelayCommand(() =>
        //        {

        //        }));
        //    }

        //}


        //private ICommand _DepartmentInfoDialogLoadedCommand;
        ///// <summary>
        ///// 弹框关闭命令
        ///// </summary>
        //public ICommand DepartmentInfoDialogUnloadedCommand
        //{
        //    get
        //    {
        //        return _DepartmentInfoDialogLoadedCommand ?? (_DepartmentInfoDialogUnloadedCommand = new RelayCommand(() =>
        //        {
        //            DialogTitle = "";
        //            DialogParentDepartmentVisibility = Visibility.Visible;
        //            DialogDepartment = new DepartmentDto();
        //        }));
        //    }

        //}


        //private ICommand _AddDepartmentInfoCommand;
        ///// <summary>
        ///// 添加部门
        ///// </summary>
        //public ICommand AddDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _AddDepartmentInfoCommand ?? (_AddDepartmentInfoCommand = new RelayCommand<string>((str) =>
        //        {
        //            if (str == "HasParentDepartment")
        //            {
        //                DialogParentDepartment = SelectedDepartment;
        //            }
        //            else if (str == "NoParentDepartment")
        //            {
        //                DialogParentDepartment = new DepartmentDto();
        //            }
        //            DialogTitle = "添加部门";
        //            DialogDepartment = new DepartmentDto();
        //            DialogParentDepartmentList.Clear();
        //            DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
        //            departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>();
        //        }));
        //    }

        //}


        //private ICommand _EditDepartmentInfoCommand;
        ///// <summary>
        ///// 修改部门
        ///// </summary>
        //public ICommand EditDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _EditDepartmentInfoCommand ?? (_EditDepartmentInfoCommand = new RelayCommand(() =>
        //        {
        //            DialogTitle = "修改部门";
        //            DialogParentDepartmentList.Clear();
        //            DialogParentDepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetAllDepartment().items);
        //            DialogDepartment.Department = (Department)SelectedDepartment.Department.Clone();
        //            DialogParentDepartmentVisibility = (SelectedDepartment.Department.parent_id == 0 ? Visibility.Collapsed : Visibility.Visible);
        //            DialogParentDepartment.Department = DepHttpUtil.GetDepartment(SelectedDepartment.Department.parent_id);
        //            departmentInfoDialog = Dialog.Show<DepartmentInfoDialog>();

        //        }));
        //    }

        //}


        //private ICommand _SubmitDepartmentInfoCommand;

        //public ICommand SubmitDepartmentInfoCommand
        //{
        //    get
        //    {
        //        return _SubmitDepartmentInfoCommand ?? (_SubmitDepartmentInfoCommand = new RelayCommand(() =>
        //        {
        //            if (DialogParentDepartment.Department != null && DialogParentDepartment.Department.Id == 0)
        //            {
        //                HandyControl.Controls.Growl.Warning("上级部门不能为空", "DepartmentInfoWarningMsg");
        //                return;
        //            }
        //            else if (DialogParentDepartment.Department != null)
        //            {
        //                // 设置当前部门的上级部门
        //                DialogDepartment.Department.parent_id = DialogParentDepartment.Department.Id;
        //            }
        //            else
        //            {
        //                DialogDepartment.Department.parent_id = 0;
        //            }

        //            if (string.IsNullOrEmpty(DialogDepartment.Department.DepName))
        //            {
        //                HandyControl.Controls.Growl.Warning("部门名称不能为空", "DepartmentInfoWarningMsg");
        //                return;
        //            }

        //            if (DialogTitle == "添加部门")
        //            {
        //                if (DepHttpUtil.AddDepartment(DialogDepartment.Department))
        //                {
        //                    DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
        //                }
        //                departmentInfoDialog.Close();
        //                FoldToggleButtonChecked = false;
        //                HandyControl.Controls.Growl.Success("部门添加成功", "DepartmentSuccessMsg");

        //                Messenger.Default.Send<string>(null, "RefreshDepList");
        //            }
        //            else if (DialogTitle == "修改部门")
        //            {
        //                if (DepHttpUtil.UpdateDepartment(DialogDepartment.Department))
        //                {
        //                    DepartmentList = TreeListHelper.RefreshDeplist(DepHttpUtil.GetDepartments(SearchDepName, SearchStatus).items);
        //                    departmentInfoDialog.Close();
        //                    FoldToggleButtonChecked = false;
        //                    HandyControl.Controls.Growl.Success("部门修改成功", "DepartmentSuccessMsg");
        //                    Messenger.Default.Send<string>(null, "RefreshDepList");
        //                }
        //            }

        //        }));
        //    }
        //}


        //#endregion


        //#region 其他命令

        //private ICommand _ChangeSearchPanelVisCommand;
        ///// <summary>
        ///// 隐藏搜索栏命令
        ///// </summary>
        //public ICommand ChangeSearchPanelVisCommand
        //{
        //    get
        //    {
        //        return _ChangeSearchPanelVisCommand ?? (_ChangeSearchPanelVisCommand = new RelayCommand(() =>
        //        {
        //            SearchPanelVis = (SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
        //        }));
        //    }

        //}


        //#endregion


        //#endregion

        //#region 方法

        ///// <summary>
        ///// 展开/折叠单个菜单方法
        ///// </summary>
        ///// <param name="barModel"></param>
        //public void DepartmentCheckChangedMethod(DepartmentDto department)
        //{
        //    int index = DepartmentList.IndexOf(department) + 1;
        //    if (department.IsChecked)
        //    {
        //        if (department.ChildDepartmentList == null)
        //        {
        //            return;
        //        }
        //        foreach (DepartmentDto item in department.ChildDepartmentList)
        //        {
        //            item.MarginLeft = department.MarginLeft + 50;
        //            DepartmentList.Insert(index++, item);
        //        }
        //    }
        //    else
        //    {
        //        List<DepartmentDto> tempMenuList = new List<DepartmentDto>();
        //        foreach (DepartmentDto item in DepartmentList)
        //        {
        //            if (item.Department.parent_id == department.Department.Id)
        //            {
        //                tempMenuList.Add(item);
        //            }
        //        }
        //        foreach (DepartmentDto item in tempMenuList)
        //        {
        //            DepartmentList.Remove(item);
        //        }
        //    }
        //}

        //private List<DepartmentDto> GetChildDepartmentDtos(DepartmentDto department, List<DepartmentDto> tempList)
        //{
        //    if (department.ChildDepartmentList != null && department.ChildDepartmentList.Count > 0 && department.IsChecked == false)
        //    {
        //        foreach (DepartmentDto child in department.ChildDepartmentList)
        //        {
        //            tempList.Add(child);
        //            GetChildDepartmentDtos(child, tempList);
        //        }
        //    }
        //    return tempList;
        //}

//#endregion
    }


}
