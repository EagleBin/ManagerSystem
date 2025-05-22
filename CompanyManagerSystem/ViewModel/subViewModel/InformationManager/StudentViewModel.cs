using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Entity.InformationManager.Link;
using ManagerSystem.Utils.Http.InformationManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public class StudentViewModel : ViewModelBase
    {

        public StudentViewModel()
        {
            Messenger.Default.Register<List<StudentDto>>("SelectedStudentList", s => SelectedStudentList = s);

            // 初始化班级列表（搜索）
            foreach (var item in ClassHttpUtil.GetAllClass().items)
            {
                SearchClassNameList.Add(item.Name);
            }
            // 初始化性别列表（搜索）
            SearchStudentGenderList = new List<string>() { "全部", "男", "女" };

            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 };

            // 初始化学生列表（表格）
            foreach (var item in StudentHttpUtil.GetAllStudent().items)
            {
                StudentList.Add(new StudentDto() { Student = item });
            }

            // 初始化班级列表（窗体）
            foreach (var item in ClassHttpUtil.GetAllClass().items)
            {
                DialogClassList.Add(item.Name);
            }
            // 初始化性别列表（窗体）
            DialogGenderList = new List<string>() { "男", "女" };


        }

        #region 属性

        #region 学生属性

        private ObservableCollection<StudentDto> _StudentList = new ObservableCollection<StudentDto>();
        /// <summary>
        /// 学生列表
        /// </summary>
        public ObservableCollection<StudentDto> StudentList
        {
            get { return _StudentList; }
            set
            {
                _StudentList = value;
                RaisePropertyChanged();
            }
        }

        private StudentDto _SelectedStudent;
        /// <summary>
        /// 选择的学生
        /// </summary>
        public StudentDto SelectedStudent
        {
            get { return _SelectedStudent; }
            set
            {
                _SelectedStudent = value;
                RaisePropertyChanged();
            }
        }

        private List<StudentDto> _SelectedStudentList = new List<StudentDto>();
        /// <summary>
        /// 选择的学生列表
        /// </summary>
        public List<StudentDto> SelectedStudentList
        {
            get { return _SelectedStudentList; }
            set
            {
                _SelectedStudentList = value;
                RaisePropertyChanged();
            }
        }

        private CourseDto _StudentCourse;
        /// <summary>
        /// 学生课程
        /// </summary>
        public CourseDto StudentCourse
        {
            get { return _StudentCourse; }
            set
            {
                _StudentCourse = value;
                RaisePropertyChanged();
            }
        }




        #endregion

        #region 弹窗属性

        /// <summary>
        /// 学生操作弹窗
        /// </summary>
        private Dialog studentInfoDiaolg;

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

        private StudentDto _DialogStudent;
        /// <summary>
        /// 弹窗的学生
        /// </summary>
        public StudentDto DialogStudent
        {
            get { return _DialogStudent; }
            set
            {
                _DialogStudent = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _DialogClassList = new List<string>();
        /// <summary>
        /// 窗体的班级列表
        /// </summary>
        public List<string> DialogClassList
        {
            get { return _DialogClassList; }
            set
            {
                _DialogClassList = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _DialogGenderList = new List<string>();
        /// <summary>
        /// 弹窗的性别列表
        /// </summary>
        public List<string> DialogGenderList
        {
            get { return _DialogGenderList; }
            set
            {
                _DialogGenderList = value;
                RaisePropertyChanged();
            }
        }


        private string _DialogCourseType;
        /// <summary>
        /// 窗口学科类型
        /// </summary>
        public string DialogCourseType
        {
            get { return _DialogCourseType; }
            set
            {
                _DialogCourseType = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 搜索属性

        private string _SearchStudentName;
        /// <summary>
        /// 搜索的姓名
        /// </summary>
        public string SearchStudentName
        {
            get { return _SearchStudentName; }
            set
            {
                _SearchStudentName = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchClassName;
        /// <summary>
        /// 班级名称
        /// </summary>
        public string SearchClassName
        {
            get { return _SearchClassName; }
            set
            {
                _SearchClassName = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchClassNameList = new List<string>();
        /// <summary>
        /// 搜索的班级名称列表
        /// </summary>
        public List<string> SearchClassNameList
        {
            get { return _SearchClassNameList; }
            set
            {
                _SearchClassNameList = value;
                RaisePropertyChanged();
            }
        }


        private int _SearchStudentGender;
        /// <summary>
        /// 搜索的性别
        /// </summary>
        public int SearchStudentGender
        {
            get { return _SearchStudentGender; }
            set
            {
                _SearchStudentGender = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchStudentGenderList = new List<string>();
        /// <summary>
        /// 搜索 性别列表
        /// </summary>
        public List<string> SearchStudentGenderList
        {
            get { return _SearchStudentGenderList; }
            set
            {
                _SearchStudentGenderList = value;
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

        private List<int> _PerPageCountList = new List<int>();
        /// <summary>
        /// 每页容量列表
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
        /// 隐藏搜索栏
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

        #region 学生命令

        private ICommand _DeleteStudentCommand;
        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteStudentCommand
        {
            get
            {
                return _DeleteStudentCommand ??
                    (_DeleteStudentCommand = new RelayCommand<string>((para) =>
                    {
                        if (SelectedStudent == null || SelectedStudentList.Count == 0)
                        {
                            return;
                        }

                        try
                        {
                            // 删除单个
                            if (para == "DeleteOnlyOneStudent")
                            {
                                var dialogResult = HandyControl.Controls.MessageBox.Show($"是否删除【{SelectedStudent.Student.Name}】学生?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (dialogResult == MessageBoxResult.Yes)
                                {
                                    var resultDelete = StudentHttpUtil.DeleteStudent(SelectedStudent.Student.Id);
                                    if (resultDelete)
                                    {
                                        // 刷新列表
                                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                                        RefreshStudentList(list.items, list.TotalCount);

                                        HandyControl.Controls.Growl.Success("删除成功", "StudentSuccessMsg");
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Warning("删除失败，刷新列表后重试", "StudentWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个
                            else if (para == "DeleteNotOnlyOneStudent")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SelectedStudentList.Count == 1 ? $"是否删除【{SelectedStudent.Student.Name}】学生?" : $"是否删除【{SelectedStudentList.Count}】个学生?",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int successCount = 0;
                                    int errorCount = 0;
                                    foreach (var item in SelectedStudentList)
                                    {
                                        var resultDelete = StudentHttpUtil.DeleteStudent(item.Student.Id);
                                        if (resultDelete)
                                        {
                                            successCount++;
                                        }
                                        else
                                        {
                                            errorCount++;
                                        }
                                    }
                                    // 刷新列表
                                    // 刷新列表
                                    int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                                    var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                                    RefreshStudentList(list.items, list.TotalCount);

                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个, 失败{errorCount}个", "StudentSuccessMsg");
                                    return;
                                }

                            }
                            else
                            {
                                HandyControl.Controls.Growl.Warning("请刷新列表后，重试", "StudentWarningMsg");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常，详情：{ex.Message}", "StudentErrorMsg");
                            return;
                        }
                    }));
            }
        }

        private ICommand _EditStudentCommand;
        /// <summary>
        /// 编辑
        /// </summary>
        public ICommand EditStudentCommand
        {
            get
            {
                return _EditStudentCommand ??
                    (_EditStudentCommand = new RelayCommand(() =>
                    {
                        if (SelectedStudent == null || SelectedStudent.Student == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择需要修改的学生", "StudentWarningMsg");
                            return;
                        }
                        else if(SelectedStudentList == null || SelectedStudentList.Count >= 2)
                        {
                            HandyControl.Controls.Growl.Warning("请选择单个需要修改的学生", "StudentWarningMsg");
                            return;
                        }

                        DialogTitle = "修改学生";
                        // 将选中的参数赋值到窗体
                        DialogStudent = new StudentDto() { Student = (Students)SelectedStudent.Student.Clone() }; // 获取选中的学生
                        studentInfoDiaolg = Dialog.Show<StudentInfoDialog>();
                    }));
            }
        }

        private ICommand _AddStudentCommand;
        /// <summary>
        /// 添加
        /// </summary>
        public ICommand AddStudentCommand
        {
            get
            {
                return _AddStudentCommand ??
                    (_AddStudentCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加学生";
                        DialogStudent = new StudentDto();
                        studentInfoDiaolg = Dialog.Show<StudentInfoDialog>(); // 打开添加窗体
                    }));
            }
        }

        private ICommand _SubmitStudentInfoCommand;
        /// <summary>
        /// 确认添加/修改
        /// </summary>
        public ICommand SubmitStudentInfoCommand
        {
            get
            {
                return _SubmitStudentInfoCommand ??
                    (_SubmitStudentInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            // 信息校验
                            if (DialogStudent == null || DialogStudent.Student == null)
                            {
                                return;
                            }
                            else if (string.IsNullOrEmpty(DialogStudent.Student.Name))
                            {
                                HandyControl.Controls.Growl.Warning("请输入学生姓名", "StudentInfoWarningMsg");
                                return;
                            }
                            else if (DialogStudent.Student.ClassId == 0)
                            {
                                HandyControl.Controls.Growl.Warning("请选择学生班级", "StudentInfoWarningMsg");
                                return;
                            }

                            // 添加
                            if (DialogTitle == "添加学生")
                            {
                                // 同班同名验证
                                var result_1 = StudentHttpUtil.GetStudentByName(DialogStudent.Student.Name) != null;
                                var result_2 = ClassHttpUtil.GetClass(DialogStudent.Student.ClassId) != null;
                                if (result_1 && result_2)
                                {
                                    var result = HandyControl.Controls.MessageBox.Show($"当前班级已经存在名为【{DialogStudent.Student.Name}】的学生，是否继续添加？", "提示",
                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    // 不添加则退出
                                    if (result == MessageBoxResult.No)
                                    {
                                        return;
                                    }
                                }
                                DialogStudent.Student.insertTime = DateTime.Now;
                                var resultAdd = StudentHttpUtil.AddStudent((Students)DialogStudent.Student.Clone());
                                // 是否插入成功
                                if (resultAdd > 0)
                                {

                                    // 刷新列表
                                    int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                                    var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                                    RefreshStudentList(list.items, list.TotalCount);
                                    HandyControl.Controls.Growl.Success("添加成功", "StudentInfoSuccessMsg");
                                    return;
                                }



                            }
                            // 修改
                            else if (DialogTitle == "修改学生")
                            {
                                // 同班同名校验
                                if (StudentHttpUtil.GetStudentByName(DialogStudent.Student.Name) != null &&
                                ClassHttpUtil.GetClass(DialogStudent.Student.ClassId) != null)
                                {
                                    var result = HandyControl.Controls.MessageBox.Show($"当前班级已经存在名为【{DialogStudent.Student.Name}】的学生，是否继续添加？", "提示",
                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    // 不添加则退出
                                    if (result == MessageBoxResult.No)
                                    {
                                        return;
                                    }
                                }
                                var resultDialog = StudentHttpUtil.UpdateStudent(DialogStudent.Student);
                                // 是否修改成功
                                if (resultDialog)
                                {
                                    // 刷新列表
                                    int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                                    var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                                    RefreshStudentList(list.items, list.TotalCount);
                                    HandyControl.Controls.Growl.Success("修改成功", "StudentInfoSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("修改失败", "StudentInfoWarningMsg");
                                    return;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常，详情：{ex.Message}", "StudentErrorMsg");
                            return;
                        }
                    }));
            }
        }



        #endregion

        #region 搜索命令

        private ICommand _SearchStudentCommand;
        /// <summary>
        /// 搜索
        /// </summary>
        public ICommand SearchStudentCommand
        {
            get
            {
                return _SearchStudentCommand ??
                    (_SearchStudentCommand = new RelayCommand(() =>
                    {
                        // 刷新列表
                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                        RefreshStudentList(list.items, list.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _ResetSearchCommand;
        /// <summary>
        /// 重置搜索
        /// </summary>
        public ICommand ResetSearchCommand
        {
            get
            {
                return _ResetSearchCommand ??
                    (_ResetSearchCommand = new RelayCommand(() =>
                    {
                        SearchStudentName = null; // 学生名称
                        SearchClassName = null; // 班级名称
                        SearchStudentGender = 3; // 性别
                        CurrentPage = 1;
                        // 刷新列表
                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                        RefreshStudentList(list.items, list.TotalCount);
                        return;
                    }));
            }
        }

        #endregion

        #region 分页命令

        private ICommand _PageUpdatedCommand;
        /// <summary>
        /// 页容量改变
        /// </summary>
        public ICommand PageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1;
                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                        RefreshStudentList(list.items, list.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _PerPageCountChangedCommand;
        /// <summary>
        /// 当前页码改变
        /// </summary>
        public ICommand PerPageCountChangedCommand
        {
            get
            {
                return _PerPageCountChangedCommand ??
                    (_PerPageCountChangedCommand = new RelayCommand(() =>
                    {
                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                        RefreshStudentList(list.items, list.TotalCount);
                        return;
                    }));
            }
        }



        #endregion

        #region 其他命令

        private ICommand _ChangeSearchPanelVisCommand;
        /// <summary>
        /// 隐藏搜索栏
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

        private ICommand _RefreshStudentListCommand;
        /// <summary>
        /// 刷新列表
        /// </summary>
        public ICommand RefreshStudentListCommand
        {
            get
            {
                return _RefreshStudentListCommand ??
                    (_RefreshStudentListCommand = new RelayCommand(() =>
                    {
                        // 刷新列表
                        int SearchClassId = ClassHttpUtil.GetClassByName(SearchClassName).Id;
                        var list = StudentHttpUtil.GetStudents(SearchStudentName, SearchStudentGender, SearchClassId, CurrentPage, PerPageCount);
                        RefreshStudentList(list.items, list.TotalCount);
                        return;
                    }));
            }
        }



        #endregion

        #endregion

        #region 方法

        private void RefreshStudentList(List<Students> allStudentList, int totalCount)
        {
            TotalCount = totalCount;
            // 总数 对 每页总数 求模等于0
            if (TotalCount % PerPageCount == 0)
            {
                // 求总页数
                TotalPageCount = TotalCount / PerPageCount;
            }
            else
            {
                TotalPageCount = (TotalCount / PerPageCount) + 1;
            }

            // 当前页数 大于 总的页数
            if (CurrentPage > TotalPageCount)
            {
                CurrentPage = TotalPageCount;
            }
            StudentList.Clear(); // 清空岗位列表
            // 重新获取岗位列表
            foreach (var item in allStudentList)
            {
                StudentList.Add(new StudentDto() { Student = item });
            }
        }

        #endregion

    }
}


