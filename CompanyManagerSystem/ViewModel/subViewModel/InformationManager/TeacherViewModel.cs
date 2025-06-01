using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Http.InformationManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using HandyControl.Controls;
using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using ManagerSystem.Entity.InformationManager.Link;
using System.Data;
using ManagerSystem.Utils.Helper;
namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public enum OperationType
    {
        Add,
        Edit,
        None
    }
    public class TeacherViewModel : ViewModelBase
    {
        public TeacherViewModel()
        {
            Messenger.Default.Register<List<TeacherDto>>(this, "SeletedTeacherList", cl => SeletedTeacherList = cl);
            Messenger.Default.Register<List<Courses>>(this, "CourseChanged", gc => CourseChanged(gc)); // 课程更新
            Messenger.Default.Register<List<Classes>>(this, "ClassChanged", cc => ClassChanged(cc)); // 课程更新

            SearchTeacherTypeList = new List<string>() { "全部", "班主任", "普通教师" }; // 初始化教师类型
            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 }; // 初始化每页容量

            // 初始化 教师类型（窗体）
            DialogTeacherTypeList = new List<string>() { "普通教师", "班主任" };
            // 初始化 课程列表（窗体）
            foreach (var item in CourseHttpUtil.GetAllCourse().items)
            {
                DialogSubjectList.Add(item.Name);
            }
            // 初始化 班级列表（窗体）
            foreach (var item in ClassHttpUtil.GetAllClass().items)
            {
                DialogClassNameAddList.Add(item.Name);
            }
            // 初始化 教师列表（表格）
            var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
            RefreshTeacherList(teacherList.items, teacherList.TotalCount);
        }



        #region 属性

        #region 教师属性

        private ObservableCollection<TeacherDto> _TeacherList = new ObservableCollection<TeacherDto>();
        /// <summary>
        /// 教师列表
        /// </summary>
        public ObservableCollection<TeacherDto> TeacherList
        {
            get { return _TeacherList; }
            set
            {
                _TeacherList = value;
                RaisePropertyChanged();
            }
        }

        private TeacherDto _SelectedTeacher;
        /// <summary>
        /// 选择的教师
        /// </summary>
        public TeacherDto SelectedTeacher
        {
            get { return _SelectedTeacher; }
            set
            {
                _SelectedTeacher = value;
                RaisePropertyChanged();
            }
        }

        private List<TeacherDto> _SeletedTeacherList = new List<TeacherDto>();
        /// <summary>
        /// 选择的教师教师
        /// </summary>
        public List<TeacherDto> SeletedTeacherList
        {
            get { return _SeletedTeacherList; }
            set
            {
                _SeletedTeacherList = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        // 完成
        #region 搜索属性

        private string _SearchTeacherName;
        /// <summary>
        /// 搜索的教师的名称
        /// </summary>
        public string SearchTeacherName
        {
            get { return _SearchTeacherName; }
            set
            {
                _SearchTeacherName = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchTeacherAge;
        /// <summary>
        /// 搜索的教师年龄
        /// </summary>
        public string SearchTeacherAge
        {
            get { return _SearchTeacherAge; }
            set
            {
                _SearchTeacherAge = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchTeacherSubject;
        /// <summary>
        /// 搜索的科目
        /// </summary>
        public string SearchTeacherSubject
        {
            get { return _SearchTeacherSubject; }
            set
            {
                _SearchTeacherSubject = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchTeacherPhone;
        /// <summary>
        /// 搜索的教师电话
        /// </summary>
        public string SearchTeacherPhone
        {
            get { return _SearchTeacherPhone; }
            set
            {
                _SearchTeacherPhone = value;
                RaisePropertyChanged();
            }
        }

        private int _SearchTeacherType = 2;
        /// <summary>
        /// 搜索的教师的类别
        /// </summary>
        public int SearchTeacherType
        {
            get { return _SearchTeacherType; }
            set
            {
                _SearchTeacherType = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchTeacherTypeList = new List<string>();
        /// <summary>
        /// 教师类型列表
        /// </summary>
        public List<string> SearchTeacherTypeList
        {
            get { return _SearchTeacherTypeList; }
            set
            {
                _SearchTeacherTypeList = value;
                RaisePropertyChanged();
            }
        }




        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改教师）
        /// </summary>
        private Dialog teacherInfoDialog;

        private TeacherDto _DialogTeacher = new TeacherDto();
        /// <summary>
        /// 弹窗中的 教师
        /// </summary>
        public TeacherDto DialogTeacher
        {
            get { return _DialogTeacher; }
            set
            {
                _DialogTeacher = value;
                RaisePropertyChanged();
            }
        }

        private TeacherDto _DialogOldTeacher;
        /// <summary>
        /// 弹窗 教师(用来存储 未更改的教师数据)
        /// </summary>
        public TeacherDto DialogOldTeacher
        {
            get { return _DialogOldTeacher; }
            set
            {
                _DialogOldTeacher = value;
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

        private List<string> _DialogTeacherTypeList = new List<string>();
        /// <summary>
        /// 窗体 教师类型列表
        /// </summary>
        public List<string> DialogTeacherTypeList
        {
            get { return _DialogTeacherTypeList; }
            set
            {
                _DialogTeacherTypeList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogSubjectList = new ObservableCollection<string>();
        /// <summary>
        /// 窗体 课程列表
        /// </summary>
        public ObservableCollection<string> DialogSubjectList
        {
            get { return _DialogSubjectList; }
            set
            {
                _DialogSubjectList = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogHoldClassName;
        /// <summary>
        /// 已经指导的班级的名称
        /// </summary>
        public string DialogHoldClassName
        {
            get { return _DialogHoldClassName; }
            set
            {
                _DialogHoldClassName = value;
                RaisePropertyChanged();

            }
        }

        private ObservableCollection<string> _DialogHoldClassNameList = new ObservableCollection<string>();
        /// <summary>
        /// 已经指导的班级列表
        /// </summary>
        public ObservableCollection<string> DialogHoldClassNameList
        {
            get { return _DialogHoldClassNameList; }
            set
            {
                _DialogHoldClassNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogClassNameAdd;
        /// <summary>
        /// 窗体 指导班级名称(用于添加)
        /// </summary>
        public string DialogClassNameAdd
        {
            get { return _DialogClassNameAdd; }
            set
            {
                _DialogClassNameAdd = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogClassNameAddList = new ObservableCollection<string>();
        /// <summary>
        /// 窗体 指导班级名称列表(用于添加)
        /// </summary>
        public ObservableCollection<string> DialogClassNameAddList
        {
            get { return _DialogClassNameAddList; }
            set
            {
                _DialogClassNameAddList = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogClassNameEdit;
        /// <summary>
        /// 窗体 指导班级名称(用于修改)
        /// </summary>
        public string DialogClassNameEdit
        {
            get { return _DialogClassNameEdit; }
            set
            {
                _DialogClassNameEdit = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogClassNameEditList = new ObservableCollection<string>();
        /// <summary>
        /// 窗体 指导班级名称列表(用于修改)
        /// </summary>
        public ObservableCollection<string> DialogClassNameEditList
        {
            get { return _DialogClassNameEditList; }
            set
            {
                _DialogClassNameEditList = value;
                RaisePropertyChanged();
            }
        }


        private Visibility _DialogClassVisibility = Visibility.Collapsed;
        /// <summary>
        /// 窗体 指导班级显示
        /// </summary>
        public Visibility DialogClassVisibility
        {
            get { return _DialogClassVisibility; }
            set
            {
                _DialogClassVisibility = value;
                RaisePropertyChanged();
            }
        }

        private OperationType _CurrentOperation;
        /// <summary>
        /// 添加 或 编辑 班级
        /// </summary>
        public OperationType CurrentOperation
        {
            get { return _CurrentOperation; }
            set
            {
                if (_CurrentOperation != value)
                {
                    _CurrentOperation = value;
                    RaisePropertyChanged();
                    UpdateClassVisibility(); // 改变时 更改AddClassVisibility 或者 EditClassVisibility属性
                }

            }
        }

        private Visibility _AddClassVisibility;
        /// <summary>
        /// 显示 添加指导班级列表
        /// </summary>
        public Visibility AddClassVisibility
        {
            get { return _AddClassVisibility; }
            set
            {
                if (_AddClassVisibility != value)
                {
                    _AddClassVisibility = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Visibility _EditClassVisibility;
        /// <summary>
        /// 显示 修改指导班级列表
        /// </summary>
        public Visibility EditClassVisibility
        {
            get { return _EditClassVisibility; }
            set
            {
                if (_EditClassVisibility != value)
                {
                    _EditClassVisibility = value;
                    RaisePropertyChanged();
                }

            }
        }

        private bool _IsAddEnable;
        /// <summary>
        /// 是否可以添加
        /// </summary>
        public bool IsAddEnable
        {
            get { return _IsAddEnable; }
            set
            {
                _IsAddEnable = value;
                RaisePropertyChanged();
            }
        }

        private bool _IsEditEnable;
        /// <summary>
        /// 是否可以启用编辑
        /// </summary>
        public bool IsEditEnable
        {
            get { return _IsEditEnable; }
            set
            {
                _IsEditEnable = value;
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

        private Visibility _SearchPanelVisibility = Visibility.Visible;
        /// <summary>
        /// 搜索框的可见性(默认可见)
        /// </summary>
        public Visibility SearchPanelVisibility
        {
            get { return _SearchPanelVisibility; }
            set
            {
                _SearchPanelVisibility = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #endregion

        #region 命令

        #region 教师命令

        private ICommand _DeleteTeacherInfoCommand;
        /// <summary>
        /// 删除教师
        /// </summary>
        public ICommand DeleteTeacherInfoCommand
        {
            get
            {
                return _DeleteTeacherInfoCommand ??
                    (_DeleteTeacherInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedTeacher == null || SelectedTeacher.Teacher == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "TeacherWarningMsg");
                                return;
                            }
                            // 删除单个教师
                            if (para == "DeleteOnlyOneTeacher")
                            {
                                var deleteTeacher = SelectedTeacher;
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{deleteTeacher.Teacher.Name}]的教师,同时相应的指导班级的班主任将会改为[NULL]班主任?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = TeacherHttpUtil.DeleteTeacher(deleteTeacher.Teacher.Id);
                                    if (resultDelete)
                                    {

                                        // 删除 课程_教师中间表
                                        var course = CourseHttpUtil.GetCourseByName(deleteTeacher.Teacher.Subject); // 根据 教师科目 获取 课程
                                        TeacherHttpUtil.DeleteCourses_Teachers(course.Id, deleteTeacher.Teacher.Id); // 删除

                                        // 如果为班主任 则删除有关的则 Teachers_Classes中间表
                                        if (deleteTeacher.Teacher.IsHeadTeacher == 0)
                                        {
                                            // 遍历删除 指导的班级中间表
                                            var classList = ClassHttpUtil.GetClassByHeadTeacher(deleteTeacher.Teacher.Id).items; // 获取班主任管理的班级
                                            foreach (var item in classList)
                                            {
                                                ClassHttpUtil.DeleteTeachers_Classes(deleteTeacher.Teacher.Id, item.Id); // 删除中间表
                                                // 更新班级
                                                item.HeadTeacher_Id = 56;// 把所管理的班级的班主任设置为NULL,Id为56
                                                ClassHttpUtil.UpdateClass(item);
                                                ClassHttpUtil.AddTeachers_Classes(new Teachers_Classes() { ClassId = item.Id , TeacherId = item.HeadTeacher_Id, insertTime = DateTime.Now});

                                            }
                                            // 发送班级更改后的信息到信息中心
                                            Messenger.Default.Send(ClassHttpUtil.GetClasses(null, null, 2, 1, 20).items, "ClassChanged");
                                        }
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{deleteTeacher.Teacher.Name}]的教师！", "TeacherSuccessMsg");
                                        // 刷新列表
                                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                        Messenger.Default.Send(teacherList.items, "TeacherChanged"); // 发送消息
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "TeacherWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个教师
                            else if (para == "DeleteNotOnlyOneTeacher")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SeletedTeacherList.Count == 1 ? $"是否删除名为[{SelectedTeacher.Teacher.Name}]的教师?" : $"是否删除{SeletedTeacherList.Count}个教师",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var teacherDto in SeletedTeacherList)
                                    {
                                        var resultDelete = ClassHttpUtil.DeleteClass(teacherDto.Teacher.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除{teacherDto.Teacher.Name}失败，请刷新列表后重试！", "TeacherWarningMsg");
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                            // 如果为班主任,则删除有关的 Teachers_Classes中间表
                                            if (teacherDto.Teacher.IsHeadTeacher == 1)
                                            {
                                                // 遍历删除指导的班级中间表
                                                var classList = ClassHttpUtil.GetClassByHeadTeacher(teacherDto.Teacher.Id).items; // 获取班主任管理的班级
                                                foreach (var item in classList)
                                                {
                                                    // 删除中间表
                                                    ClassHttpUtil.DeleteTeachers_Classes(teacherDto.Teacher.Id, item.Id);
                                                    // 把所管理的班级的班主任Id设置为-1
                                                    item.HeadTeacher_Id = 56;
                                                    ClassHttpUtil.UpdateClass(item); // 更新班级列表
                                                    ClassHttpUtil.AddTeachers_Classes(new Teachers_Classes() { ClassId = item.Id, TeacherId = item.HeadTeacher_Id, insertTime = DateTime.Now });
                                                }
                                            }

                                            // 修改 课程表中的教师(删除 课程_教师 中间表)
                                            var course = CourseHttpUtil.GetCourseByName(teacherDto.Teacher.Subject);
                                            TeacherHttpUtil.DeleteCourses_Teachers(course.Id, teacherDto.Teacher.Id);
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个教师,失败删除{errorCount}个教师");
                                    // 刷新列表
                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                    // 发送班级更改后的信息到信息中心
                                    Messenger.Default.Send(ClassHttpUtil.GetClasses(null, null, 2, 1, 20).items, "ClassChanged");
                                    // 发送教师更改后的信息到信息中心
                                    Messenger.Default.Send(teacherList.items, "TeacherChanged");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "TeacherErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion

        // 完成
        #region 搜索命令

        private ICommand _SearchTeacherCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand SearchTeacherCommand
        {
            get
            {
                return _SearchTeacherCommand ??
                    (_SearchTeacherCommand = new RelayCommand(() =>
                    {
                        if (!string.IsNullOrEmpty(SearchTeacherAge))
                        {
                            // 年龄的数字校验
                            if (NumberValidator.IsValidInteger(SearchTeacherAge)) // 是否为有效数字
                            {
                                if (!NumberValidator.IsInRange(int.Parse(SearchTeacherAge), 18, 65)) // 是否在18~65之间
                                {
                                    HandyControl.Controls.Growl.Warning($"输入的年龄范围在18~65之间", "TeacherErrorMsg");
                                    return;
                                }

                            }
                            else
                            {
                                HandyControl.Controls.Growl.Warning($"字符无效,年龄请输入数字", "TeacherErrorMsg");
                                return;
                            }
                        }



                        CurrentPage = 1; // 设置当前页面为第一页
                        // 根据 搜索条件 搜索，刷新列表
                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _ResetSearchCommand;
        /// <summary>
        /// 重置搜索条件，并刷新数据
        /// </summary>
        public ICommand ResetSearchCommand
        {
            get
            {
                return _ResetSearchCommand ??
                    (_ResetSearchCommand = new RelayCommand(() =>
                    {
                        // 清空查询条件
                        SearchTeacherName = null;
                        SearchTeacherAge = null;
                        SearchTeacherSubject = null;
                        SearchTeacherPhone = null;
                        SearchTeacherType = 2;

                        CurrentPage = 1;
                        // 刷新列表
                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                        return;
                    }));
            }
        }

        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _TeacherInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand TeacherInfoDialogLoadedCommand
        {
            get
            {
                return _TeacherInfoDialogLoadedCommand ??
                    (_TeacherInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _TeacherInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand TeacherInfoDialogUnloadedCommand
        {
            get
            {
                return _TeacherInfoDialogUnloadedCommand ??
                    (_TeacherInfoDialogLoadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogTeacher = new TeacherDto(); // 重新 赋值 教师实例
                    }));
            }
        }

        private ICommand _AddTeacherInfoCommand;
        /// <summary>
        /// 打开 添加教师 窗体
        /// </summary>
        public ICommand AddTeacherInfoCommand
        {
            get
            {
                return _AddTeacherInfoCommand ??
                    (_AddTeacherInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加教师"; // 窗体标题
                        DialogTeacher = new TeacherDto(); // 窗体教师
                        DialogClassNameAdd = ""; // 清除选择的班级
                        DialogTeacher.Teacher.IsHeadTeacher = 1; // 默认为 普通教师
                        AddClassVisibility = Visibility.Collapsed; // 隐藏 添加
                        EditClassVisibility = Visibility.Collapsed; // 隐藏搜索
                        //CurrentOperation = OperationType.None;
                        // 初始化添加列表
                        foreach (var item in ClassHttpUtil.GetAllClass().items)
                        {
                            DialogClassNameAddList.Add(item.Name);
                        }
                        // 打开窗体
                        teacherInfoDialog = HandyControl.Controls.Dialog.Show<TeacherInfoDialog>();
                    }));
            }
        }

        private ICommand _EditTeacherInfoCommand;
        /// <summary>
        /// 打开 编辑教师 窗体
        /// </summary>
        public ICommand EditTeacherInfoCommand
        {
            get
            {
                return _EditTeacherInfoCommand ??
                    (_EditTeacherInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedTeacher == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择要修改的教师！", "TeacherWarningMsg");
                            return;
                        }
                        if (SeletedTeacherList.Count > 1)
                        {
                            HandyControl.Controls.Growl.Warning("请选择一个要修改的教师！", "TeacherWarningMsg");
                            return;
                        }
                        DialogTitle = "修改教师";
                        IsEditEnable = false;
                        IsAddEnable = false;
                        AddClassVisibility = Visibility.Collapsed;
                        EditClassVisibility = Visibility.Collapsed;
                        // 清空班级列表
                        DialogClassNameAddList.Clear(); // 用于添加新班级的
                        DialogHoldClassNameList.Clear(); // 旧班级列表 (存放该教师指导的班级)
                        DialogClassNameEditList.Clear(); // 新班级列表 (存放该教师未指导的班级)
                        
                        // 使用直接赋值，会指向同一个对象实例
                        // 使用使用Clone()创建副本，形成两个独立的对象，修改对话框中的数据不会影响原始数据。
                        DialogTeacher = new TeacherDto() { Teacher = (Teachers)SelectedTeacher.Teacher.Clone() }; // 用于编辑的数据
                        DialogOldTeacher = new TeacherDto() { Teacher = (Teachers)SelectedTeacher.Teacher.Clone() }; // 用于保存未编辑的数据

                        // 获取 班主任指导班级列表
                        if (DialogTeacher.Teacher.IsHeadTeacher == 0) // 判断是否为班主任
                        {
                            IsAddEnable = true; // 启用添加
                            CurrentOperation = OperationType.Add;
                            AddClassVisibility = Visibility.Visible;
                            DialogClassNameAdd = ""; // 清空
                            // 获取 班主任指导班级列表 
                            var ClassList = ClassHttpUtil.GetClassByHeadTeacher(DialogTeacher.Teacher.Id).items; // 可能为多个
                            // 并且 筛选出 未指导的班级列表
                            if (ClassList.Count > 0)
                            {
                                IsEditEnable = true; // 启用编辑( 存在 正在指导的班级 才能将其修改)
                                foreach (var item in ClassList)
                                {
                                    DialogHoldClassNameList.Add(item.Name);
                                }
                                DialogHoldClassName = DialogHoldClassNameList[0]; // 默认选择第一个
                                // 获取该班主任没有指导的班级
                                foreach (var item in ClassHttpUtil.GetAllClass().items)
                                {
                                    if (!DialogHoldClassNameList.Contains(item.Name))
                                    {
                                        DialogClassNameEditList.Add(item.Name);
                                        DialogClassNameAddList.Add(item.Name);
                                    }
                                }
                            }
                            else
                            {
                                IsEditEnable = false; // 禁用编辑
                                EditClassVisibility = Visibility.Collapsed; // 屏蔽编辑
                            }
                        }
                        // 获取全部班级 (普通教师)
                        if (DialogClassNameAddList.Count == 0 || DialogTeacher.Teacher.IsHeadTeacher == 1) 
                        {
                            foreach (var item in ClassHttpUtil.GetAllClass().items)
                            {
                                DialogClassNameAddList.Add(item.Name);
                            }
                        }

                        // 打开窗体
                        teacherInfoDialog = HandyControl.Controls.Dialog.Show<TeacherInfoDialog>();
                    }));
            }
        }

        private ICommand _DialogClassVisibilityCommand;
        /// <summary>
        /// 选择班主任，显示指导班级
        /// </summary>
        public ICommand DialogClassVisibilityCommand
        {
            get
            {
                return _DialogClassVisibilityCommand ??
                    (_DialogClassVisibilityCommand = new RelayCommand(() =>
                    {
                        if (DialogTitle == "添加教师")
                        {
                            // 新添加的班主任 只能添加指导班级
                            if (DialogTeacher.Teacher.IsHeadTeacher == 0 && AddClassVisibility == Visibility.Collapsed && EditClassVisibility == Visibility.Collapsed)
                            {
                                AddClassVisibility = Visibility.Visible;
                                CurrentOperation = OperationType.Add; // 默认选择添加
                                IsAddEnable = true; // 只可以添加
                                IsEditEnable = false; // 不可以修改

                            }
                            // 普通教师不能 添加和修改 指导班级
                            else if (DialogTeacher.Teacher.IsHeadTeacher == 1 && AddClassVisibility == Visibility.Visible && EditClassVisibility == Visibility.Collapsed)
                            {
                                AddClassVisibility = Visibility.Collapsed;
                                IsAddEnable = false; // 不可以添加
                                IsEditEnable = false; // 不可以修改
                            }
                        }

                        if (DialogTitle == "修改教师")
                        {
                            if (DialogTeacher.Teacher.IsHeadTeacher == 0)
                            {
                                CurrentOperation = OperationType.Add; // 设置为添加
                                AddClassVisibility = Visibility.Visible; // 显示添加的
                                EditClassVisibility = Visibility.Collapsed; // 隐藏修改的

                                IsAddEnable = true; // 可以添加
                                if (DialogHoldClassNameList.Count > 0) // ( 存在 正在指导的班级 才能将其修改)
                                {
                                    IsEditEnable = true; // 可以修改
                                }

                            }
                            // 普通教师不能 添加和修改 指导班级
                            else if (DialogTeacher.Teacher.IsHeadTeacher == 1)
                            {
                                CurrentOperation = OperationType.None;
                                EditClassVisibility = Visibility.Collapsed; // 显示修改的
                                AddClassVisibility = Visibility.Collapsed; // 隐藏添加的
                                IsAddEnable = false; // 不可以添加
                                IsEditEnable = false; // 不可以修改
                            }
                        }


                    }));
            }
        }

        private ICommand _SubmitTeacherInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitTeacherInfoCommand
        {
            get
            {
                return _SubmitTeacherInfoCommand ??
                    (_SubmitTeacherInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (DialogTeacher == null || DialogTeacher.Teacher == null)
                            {
                                return;
                            }
                            #region 信息校验

                            // 教师名称是否为空
                            if (string.IsNullOrEmpty(DialogTeacher.Teacher.Name))
                            {
                                HandyControl.Controls.Growl.Warning("教师名称不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 教师类型不能为空
                            else if (string.IsNullOrEmpty(DialogTeacher.Teacher.IsHeadTeacher.ToString()))
                            {
                                HandyControl.Controls.Growl.Warning("教师类型不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 年龄不能为空
                            else if (string.IsNullOrEmpty(DialogTeacher.Teacher.Age.ToString()))
                            {
                                HandyControl.Controls.Growl.Warning("年龄不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 指导班级不能为空 (添加)
                            else if (AddClassVisibility == Visibility.Visible && string.IsNullOrEmpty(DialogClassNameAdd))
                            {
                                HandyControl.Controls.Growl.Warning("指导班级不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 旧的的指导班级不能为空 (修改)
                            else if (EditClassVisibility == Visibility.Visible && string.IsNullOrEmpty(DialogHoldClassName))
                            {
                                HandyControl.Controls.Growl.Warning("旧的的指导班级不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 新的的指导班级不能为空 (修改)
                            else if (EditClassVisibility == Visibility.Visible && string.IsNullOrEmpty(DialogClassNameEdit))
                            {
                                HandyControl.Controls.Growl.Warning("新的的指导班级不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }

                            #endregion

                            // 添加教师
                            if (DialogTitle == "添加教师")
                            {
                                if (TeacherHttpUtil.GetTeacherByName(DialogTeacher.Teacher.Name) != null) // 查看教师是否存在
                                {
                                    HandyControl.Controls.Growl.Warning("教师名称已经存在！", "TeacherInfoWarningMsg");
                                    return;
                                }
                                // 是否为班主任
                                var selectedClass = new Classes(); // 选中的班级
                                var oldTeacher = new Teachers(); // 旧班主任
                                if (DialogTeacher.Teacher.IsHeadTeacher == 0)
                                {
                                    // 判断 选中的班级 是否有已经有班主任
                                    selectedClass = ClassHttpUtil.GetClassByName(DialogClassNameAdd); // 获取选中的班级
                                    if (selectedClass.HeadTeacher_Id != 0) // 查询是班级否存在班主任
                                    {
                                        oldTeacher = TeacherHttpUtil.GetTeacher(selectedClass.HeadTeacher_Id); // 获取班主任
                                        var result = HandyControl.Controls.MessageBox.Show($"[{selectedClass.Name}]已经存在班主任[{oldTeacher.Name}],如继续则强制,更改班主任为当前教师[{DialogTeacher.Teacher.Name}].",
                                            "信息提示",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);
                                        // 取消则返回
                                        if (result == MessageBoxResult.No)
                                        {
                                            return;
                                        }
                                    }
                                }

                                DialogTeacher.Teacher.insertTime = DateTime.Now; // 获取时间
                                var teacherId = TeacherHttpUtil.AddTeacher(DialogTeacher.Teacher); // 添加教师
                                // 是否添加成功
                                if (teacherId > 0)
                                {
                                    // 添加课程_教师表
                                    var course = CourseHttpUtil.GetCourseByName(DialogTeacher.Teacher.Subject); // 获取科目
                                    var course_Teacher = new Courses_Teachers() { CourseId = course.Id, TeacherId = teacherId, insertTime = DateTime.Now }; // 创建中间表实例
                                    TeacherHttpUtil.AddCourses_Teachers(course_Teacher); // 添加中间表到数据库中

                                    // 添加的教师为班主任
                                    if (DialogTeacher.Teacher.IsHeadTeacher == 0)
                                    {
                                        // 修改班级表(班级的班主任信息发生了变换)
                                        selectedClass.HeadTeacher_Id = teacherId;
                                        ClassHttpUtil.UpdateClass(selectedClass);

                                        // 删除 旧班主任_班级表,添加 新班主任_班级表
                                        ClassHttpUtil.DeleteTeachers_Classes(oldTeacher.Id, selectedClass.Id); // 删除 旧班主任_班级表

                                        Teachers_Classes teacher_class = new Teachers_Classes() { ClassId = selectedClass.Id, TeacherId = teacherId, insertTime = DateTime.Now };
                                        ClassHttpUtil.AddTeachers_Classes(teacher_class); // 添加
                                    }

                                    // 刷新 关闭窗体
                                    teacherInfoDialog.Close();
                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"教师添加成功！", "TeacherSuccessMsg");
                                    // 发送教师更改后的信息到信息中心
                                    Messenger.Default.Send(teacherList.items, "TeacherChanged");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("教师添加失败！", "TeacherInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改教师
                            else if (DialogTitle == "修改教师")
                            {

                                // 是否为班主任
                                var selectedClass = new Classes(); // 选中的新班级
                                var oldTeacher = new Teachers(); // 旧班主任

                                // 信息提示(修改为班主任)
                                if (DialogTeacher.Teacher.IsHeadTeacher == 0)
                                {
                                    // 判断 选中的班级 是否有已经有班主任
                                    selectedClass = ClassHttpUtil.GetClassByName(DialogClassNameAdd); // 获取选中的班级
                                    if (selectedClass.HeadTeacher_Id != 0) // 查询是班级否存在班主任
                                    {
                                        oldTeacher = TeacherHttpUtil.GetTeacher(selectedClass.HeadTeacher_Id); // 获取班主任
                                        var result = HandyControl.Controls.MessageBox.Show($"[{selectedClass.Name}]已经存在班主任[{oldTeacher.Name}],将更改班主任为当前教师[{DialogTeacher.Teacher.Name}].",
                                            "信息提示",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);
                                        // 取消则返回
                                        if (result == MessageBoxResult.No)
                                        {
                                            return;
                                        }
                                    }
                                }

                                // 信息提示 (修改为普通教师)
                                if (DialogOldTeacher.Teacher.IsHeadTeacher == 0 && DialogTeacher.Teacher.IsHeadTeacher == 1)
                                {
                                    var result = HandyControl.Controls.MessageBox.Show($"将[{DialogTeacher.Teacher.Name}]班主任修改为普通教师,其指导的班级的班主任将修改为[NULL]班主任.是否继续?",
                                            "信息提示",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);
                                    // 取消则返回
                                    if (result == MessageBoxResult.No)
                                    {
                                        return;
                                    }
                                }

                                // 修改 教师信息
                                var resultEdit = TeacherHttpUtil.UpdateTeacher(DialogTeacher.Teacher);

                                // 修改成功后 (对 中间表 进行 修改和删除 )
                                if (resultEdit)
                                {
                                    // 更改前是班主任,更改后是普通教师
                                    if ( DialogOldTeacher.Teacher.IsHeadTeacher == 0 && DialogTeacher.Teacher.IsHeadTeacher == 1)
                                    {
                                        // 删除中间表 (遍历删除该教师之前作为班主任的班级)
                                        foreach (var item in ClassHttpUtil.GetAllClass().items)
                                        {
                                            if (DialogHoldClassNameList.Contains(item.Name))
                                            {
                                                ClassHttpUtil.DeleteTeachers_Classes(DialogOldTeacher.Teacher.Id, item.Id);
                                                item.HeadTeacher_Id = 56; // 修改 班主任为空 (需要自己插入一个名为NULL的教师数据库中,代表当前班级班主任为空,我的序号为56,根据实际情况修改)
                                                ClassHttpUtil.UpdateClass(item); // 跟新班级
                                                ClassHttpUtil.AddTeachers_Classes(new Teachers_Classes() { ClassId = item.Id, TeacherId = item.HeadTeacher_Id, insertTime = DateTime.Now }); // 添加空的中间表
                                            }
                                        }
                                    }
                                    // 情况2和3: 更改后是班主任
                                    if (DialogTeacher.Teacher.IsHeadTeacher == 0) // 判断是否为班主任
                                    {
                                        // 添加教师指导班级 (更改前是普通教师或者班主任,更改后还是班主任)
                                        if (AddClassVisibility == Visibility.Visible)
                                        {
                                            // 如果先前是班主任,则删除中间表
                                            if (DialogOldTeacher.Teacher.IsHeadTeacher == 0)
                                            {
                                                // 删除 中间表(删除 原来班级与旧教师的中间表)
                                                ClassHttpUtil.DeleteTeachers_Classes(selectedClass.HeadTeacher_Id, selectedClass.Id); // 删除 所选班级 和 旧教师 的中间表
                                            }
                                            // 更改 选中需要指导的班级 的HeadTeacherId                                                                                     
                                            selectedClass.HeadTeacher_Id = DialogTeacher.Teacher.Id; // 修改班级的班主任Id
                                            var a = ClassHttpUtil.UpdateClass(selectedClass); // 修改班级
                                            // 添加中间表                                                                   
                                            Teachers_Classes teachers_Classes = new Teachers_Classes() { ClassId = selectedClass.Id, TeacherId = DialogTeacher.Teacher.Id, insertTime = DateTime.Now }; // 根据 所选班级 和 所修改的教师 构成中间表
                                            ClassHttpUtil.AddTeachers_Classes(teachers_Classes); // 添加中间表
                                        }
                                        // 用 新指导班级 替换 旧指导班级 ( 更改前是班主任,更改后还是班主任 )
                                        if (EditClassVisibility == Visibility.Visible)
                                        {
                                            // 获取 选中要修改的指导班级
                                            var oldClass = ClassHttpUtil.GetClassByName(DialogHoldClassName); // 获取 选中要修改的 指导旧班级
                                            var newClass = ClassHttpUtil.GetClassByName(DialogClassNameEdit); // 获取 选中要修改的 指导新班级
                                            if (oldClass != null && newClass != null)
                                            {
                                                oldClass.HeadTeacher_Id = 56; //将 旧班级的班主任Id赋值为56,默认是无指导班级
                                                newClass.HeadTeacher_Id = DialogTeacher.Teacher.Id; // 修改班主任ID
                                                ClassHttpUtil.UpdateClass(oldClass); // 更新旧班级
                                                ClassHttpUtil.UpdateClass(newClass); // 更新新班级
                                                // 修改 中间表数据
                                                ClassHttpUtil.DeleteTeachers_Classes(DialogTeacher.Teacher.Id, oldClass.Id); // 删除旧的中间表
                                                var newTeacher_Class = new Teachers_Classes() { ClassId = newClass.Id, TeacherId = DialogTeacher.Teacher.Id, insertTime = DateTime.Now }; // 实例化Teachers_Classes表
                                                var Oldteacher_Class = new Teachers_Classes() { ClassId = oldClass.Id, TeacherId = oldClass.HeadTeacher_Id, insertTime = DateTime.Now }; // 替换旧班级中间表
                                                ClassHttpUtil.AddTeachers_Classes(newTeacher_Class); // 添加新的中间表
                                                ClassHttpUtil.AddTeachers_Classes(Oldteacher_Class); // 添加NULL班主任到旧中间表
                                            }

                                        }
                                    }
                                    
                                    // 关闭窗体
                                    teacherInfoDialog.Close();
                                    // 刷新列表
                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"修改成功！", "TeacherSuccessMsg");
                                    var classList = ClassHttpUtil.GetClasses(null, null, 2, 1, 20); // 分页查询班级(用于发送到信息中心)
                                    // 发送 教师和班级 更改后的信息到信息中心
                                    Messenger.Default.Send(teacherList.items, "TeacherChanged");
                                    Messenger.Default.Send(classList.items, "ClassChanged");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("教师修改失败！", "TeacherInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "TeacherErrorMsg");
                            return;
                        }
                    }));
            }
        }
        #endregion

        // 完成
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
                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                        return;
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
                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                        return;
                    }));
            }
        }



        #endregion

        // 完成
        #region 其他命令

        private ICommand _SearchPanelVisCommand;
        /// <summary>
        /// 隐藏搜索框
        /// </summary>
        public ICommand SearchPanelVisCommand
        {
            get
            {
                return _SearchPanelVisCommand ??
                    (_SearchPanelVisCommand = new RelayCommand(() =>
                    {
                        SearchPanelVisibility = (SearchPanelVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
                    }));
            }
        }



        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="allTeacherList"></param>
        /// <param name="totalCount"></param>
        private void RefreshTeacherList(List<Teachers> allTeacherList, int totalCount)
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

            TeacherList.Clear();
            allTeacherList.ForEach(g =>
            {
                TeacherList.Add(new TeacherDto() { Teacher = g });
            });
        }

        /// <summary>
        /// 课程更新
        /// </summary>
        /// <param name="gc"></param>
        private void CourseChanged(List<Courses> gc)
        {
            foreach (var item in gc)
            {
                DialogSubjectList.Add(item.Name);
            }
        }

        /// <summary>
        /// 班级数据发生改变时,更新班级数据
        /// </summary>
        /// <param name="cc"></param>
        private void ClassChanged(List<Classes> cc)
        {
            foreach (var item in cc)
            {
                DialogClassNameAddList.Clear();
                DialogClassNameAddList.Add(item.Name);
            }
        }

        /// <summary>
        /// 根据当前操作选择显示 添加或者修改
        /// </summary>
        private void UpdateClassVisibility()
        {
            AddClassVisibility = _CurrentOperation == OperationType.Add ? Visibility.Visible : Visibility.Collapsed;
            EditClassVisibility = _CurrentOperation == OperationType.Edit ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
    }
}
