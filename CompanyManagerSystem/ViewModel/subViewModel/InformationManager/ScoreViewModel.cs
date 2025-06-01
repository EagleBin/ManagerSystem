using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using ManagerSystem.Utils.Http.InformationManager;
using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using GalaSoft.MvvmLight;
using HandyControl.Controls;
using System.Data;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    /// <summary>
    ///  单科成绩和全科成绩
    /// </summary>
    public enum ScoreType
    {
        Single,
        All
    }

    public class ScoreViewModel : ViewModelBase
    {

        public ScoreViewModel()
        {
            Messenger.Default.Register<List<Students>>(this, "StudentChanged", s => StudentChanged(s));
            Messenger.Default.Register<List<Students>>(this, "ClassChanged", c => ClassChanged(c));
            Messenger.Default.Register<List<Grades>>(this, "GradeChanged", g => GradeChanged(g));
            Messenger.Default.Register<List<Courses>>(this, "CourseChanged", c => CourseChanged(c));

            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 };

            // 初始化全局属性
            InitializeAllProp();

            
            InitializeSearch();

            //// 初始化成绩表
            //ScoreTable = new DataTable();

            // 初始化单科成绩列表
            var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
            RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);

        }

        #region 属性

        #region 成绩属性


        private DataTable _ScoreTable = new DataTable();
        /// <summary>
        /// 成绩表
        /// </summary>
        public DataTable ScoreTable
        {
            get { return _ScoreTable; }
            set
            {
                _ScoreTable = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<ScoreDto> _ScoreList = new ObservableCollection<ScoreDto>();
        /// <summary>
        /// 成绩列表
        /// </summary>
        public ObservableCollection<ScoreDto> ScoreList
        {
            get { return _ScoreList; }
            set
            {
                _ScoreList = value;
                RaisePropertyChanged();
            }
        }

        private ScoreDto _SelectedScore;
        /// <summary>
        /// 选择的成绩
        /// </summary>
        public ScoreDto SelectedScore
        {
            get { return _SelectedScore; }
            set
            {
                _SelectedScore = value;
                RaisePropertyChanged();
            }
        }

        private List<ScoreDto> _SeletedScoreList = new List<ScoreDto>();
        /// <summary>
        /// 选择的成绩成绩
        /// </summary>
        public List<ScoreDto> SeletedScoreList
        {
            get { return _SeletedScoreList; }
            set
            {
                _SeletedScoreList = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        // 完成
        #region 全局属性



        private List<ExaminationDto> _AllExamination = new List<ExaminationDto>();
        /// <summary>
        /// 所有考次
        /// </summary>
        public List<ExaminationDto> AllExamination
        {
            get { return _AllExamination; }
            set
            {
                _AllExamination = value;
                RaisePropertyChanged();
            }
        }

        private List<GradeDto> _AllGrade = new List<GradeDto>();
        /// <summary>
        /// 所有年级
        /// </summary>
        public List<GradeDto> AllGrade
        {
            get { return _AllGrade; }
            set
            {
                _AllGrade = value;
                RaisePropertyChanged();
            }
        }

        private List<ClassDto> _AllClasses = new List<ClassDto>();
        /// <summary>
        /// 所有班级
        /// </summary>
        public List<ClassDto> AllClasses
        {
            get { return _AllClasses; }
            set
            {
                _AllClasses = value;
                RaisePropertyChanged();
            }
        }

        private List<CourseDto> _AllCourse = new List<CourseDto>();
        /// <summary>
        /// 所有课程
        /// </summary>
        public List<CourseDto> AllCourse
        {
            get { return _AllCourse; }
            set
            {
                _AllCourse = value;
                RaisePropertyChanged();
            }
        }






        #endregion

        #region 搜索属性

        private string _SearchExamName;
        /// <summary>
        /// 搜索的考次名称
        /// </summary>
        public string SearchExamName
        {
            get { return _SearchExamName; }
            set
            {
                _SearchExamName = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchExamNameList = new List<string>();
        /// <summary>
        /// 搜索的考次列表
        /// </summary>
        public List<string> SearchExamNameList
        {
            get { return _SearchExamNameList; }
            set
            {
                _SearchExamNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStudentName;
        /// <summary>
        /// 搜索的学生的名称
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

        private string _SearchScoreNumber;
        /// <summary>
        /// 搜索的成绩分数
        /// </summary>
        public string SearchScoreNumber
        {
            get { return _SearchScoreNumber; }
            set
            {
                _SearchScoreNumber = value;
                RaisePropertyChanged();
            }
        }

        private Dictionary<string, int> _GradeDic = new Dictionary<string, int>();
        /// <summary>
        /// 年级字典 -《年级名称,年级Id》
        /// </summary>
        public Dictionary<string, int> GradeDic
        {
            get { return _GradeDic; }
            set
            {
                _GradeDic = value;
                RaisePropertyChanged();
            }
        }

        private Dictionary<int, List<Classes>> _ClassesDic = new Dictionary<int, List<Classes>>();
        /// <summary>
        /// 班级字典 - 《年级ID,班级列表》
        /// </summary>
        public Dictionary<int, List<Classes>> ClassesDic
        {
            get { return _ClassesDic; }
            set
            {
                _ClassesDic = value;
                RaisePropertyChanged();
            }
        }


        private string _SearchGradeName;
        /// <summary>
        /// 搜索的年级
        /// </summary>
        public string SearchGradeName
        {
            get { return _SearchGradeName; }
            set
            {
                _SearchGradeName = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchGradeNameList = new List<string>();
        /// <summary>
        /// 搜索的年级列表
        /// </summary>
        public List<string> SearchGradeNameList
        {
            get { return _SearchGradeNameList; }
            set
            {
                _SearchGradeNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchClassName;
        /// <summary>
        /// 搜索的班级
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

        private ObservableCollection<string> _SearchClassNameList = new ObservableCollection<string>();
        /// <summary>
        /// 搜索的班级列表
        /// </summary>
        public ObservableCollection<string> SearchClassNameList
        {
            get { return _SearchClassNameList; }
            set
            {
                _SearchClassNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchCourseName;
        /// <summary>
        /// 搜索的科目名称
        /// </summary>
        public string SearchCourseName
        {
            get { return _SearchCourseName; }
            set
            {
                _SearchCourseName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _SearchCourseNameList = new ObservableCollection<string>();
        /// <summary>
        /// 搜索的科目名称列表
        /// </summary>
        public ObservableCollection<string> SearchCourseNameList
        {
            get { return _SearchCourseNameList; }
            set
            {
                _SearchCourseNameList = value;
                RaisePropertyChanged();
            }
        }

        private List<CourseDto> _SearchAllCourse = new List<CourseDto>();
        /// <summary>
        ///搜索框 所有科目，用来存储所有课程
        /// </summary>
        public List<CourseDto> SearchAllCourse
        {
            get { return _SearchAllCourse; }
            set
            {
                _SearchAllCourse = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改成绩）
        /// </summary>
        private Dialog scoreInfoDialog;

        private ScoreDto _DialogScore = new ScoreDto();
        /// <summary>
        /// 弹窗中的 成绩
        /// </summary>
        public ScoreDto DialogScore
        {
            get { return _DialogScore; }
            set
            {
                _DialogScore = value;
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

        private string _DialogExaminationName;
        /// <summary>
        /// 弹窗 考次名称
        /// </summary>
        public string DialogExaminationName
        {
            get { return _DialogExaminationName; }
            set
            {
                _DialogExaminationName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogExaminationNameList = new ObservableCollection<string>();
        /// <summary>
        /// 弹窗 考次列表
        /// </summary>
        public ObservableCollection<string> DialogExaminationNameList
        {
            get { return _DialogExaminationNameList; }
            set
            {
                _DialogExaminationNameList = value;
                RaisePropertyChanged();
            }
        }


        private string _DialogGradeName;
        /// <summary>
        /// 弹窗年级名称
        /// </summary>
        public string DialogGradeName
        {
            get { return _DialogGradeName; }
            set
            {
                _DialogGradeName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogGradeNameList = new ObservableCollection<string>();
        /// <summary>
        /// 弹窗 年级列表
        /// </summary>
        public ObservableCollection<string> DialogGradeNameList
        {
            get { return _DialogGradeNameList; }
            set
            {
                _DialogGradeNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogClassName;
        /// <summary>
        /// 弹窗 班级名称
        /// </summary>
        public string DialogClassName
        {
            get { return _DialogClassName; }
            set
            {
                _DialogClassName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogClassNameList = new ObservableCollection<string>();
        /// <summary>
        /// 窗体 班级列表
        /// </summary>
        public ObservableCollection<string> DialogClassNameList
        {
            get { return _DialogClassNameList; }
            set
            {
                _DialogClassNameList = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogStudentName;
        /// <summary>
        /// 弹窗 学生姓名
        /// </summary>
        public string DialogStudentName
        {
            get { return _DialogStudentName; }
            set
            {
                _DialogStudentName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _DialogStudentNameList = new ObservableCollection<string>();
        /// <summary>
        /// 学生姓名列表
        /// </summary>
        public ObservableCollection<string> DialogStudentNameList
        {
            get { return _DialogStudentNameList; }
            set
            {
                _DialogStudentNameList = value;
                RaisePropertyChanged();
            }
        }

        private int _DialogStudentId;
        /// <summary>
        /// 学生学号
        /// </summary>
        public int DialogStudentId
        {
            get { return _DialogStudentId; }
            set
            {
                _DialogStudentId = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogCourseName;
        /// <summary>
        /// 弹窗 课程列表
        /// </summary>
        public string DialogCourseName
        {
            get { return _DialogCourseName; }
            set
            {
                _DialogCourseName = value;
                RaisePropertyChanged();
            }
        }



        private ObservableCollection<string> _DialogCourseNameList = new ObservableCollection<string>();
        /// <summary>
        /// 弹窗 课程列表
        /// </summary>
        public ObservableCollection<string> DialogCourseNameList
        {
            get { return _DialogCourseNameList; }
            set
            {
                _DialogCourseNameList = value;
                RaisePropertyChanged();
            }
        }

        private int _DialogScoreNumber;
        /// <summary>
        /// 弹窗 科目成绩
        /// </summary>
        public int DialogScoreNumber
        {
            get { return _DialogScoreNumber; }
            set
            {
                _DialogScoreNumber = value;
                RaisePropertyChanged();
            }
        }

        private bool _DialogIsEnabled = true;
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool DialogIsEnabled
        {
            get { return _DialogIsEnabled; }
            set
            {
                _DialogIsEnabled = value;
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

        private ScoreType _CurrentScoreType;
        /// <summary>
        /// 单科与全科成绩表格切换
        /// </summary>
        public ScoreType CurrentScoreType
        {
            get { return _CurrentScoreType; }
            set
            {
                if (value != _CurrentScoreType)
                {
                    _CurrentScoreType = value;
                    ScoreTypeChanged();

                    RaisePropertyChanged();
                }
            }
        }

        private void ScoreTypeChanged()
        {
            if (CurrentScoreType == ScoreType.Single && SingleStatus == Visibility.Collapsed)
            {
                SingleStatus = Visibility.Visible;
                AllStatus = Visibility.Collapsed;
            }
            else if (CurrentScoreType == ScoreType.All && AllStatus == Visibility.Collapsed)
            {
                SingleStatus = Visibility.Collapsed;
                AllStatus = Visibility.Visible;
            }
        }


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


        private Visibility _SingleStatus = Visibility.Visible;
        /// <summary>
        /// 单科表格显示（默认显示）
        /// </summary>
        public Visibility SingleStatus
        {
            get { return _SingleStatus; }
            set
            {
                if (value == Visibility.Visible)
                {
                    var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                    RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                }
                _SingleStatus = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _AllStatus = Visibility.Collapsed;
        /// <summary>
        /// 全科表格显示（默认隐藏）
        /// </summary>
        public Visibility AllStatus
        {
            get { return _AllStatus; }
            set
            {
                if (value == Visibility.Visible)
                {
                    InitializeTable(SearchExamName, 3);
                }
                _AllStatus = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #endregion


        #region 命令

        #region 成绩命令

        private ICommand _DeleteScoreInfoCommand;
        /// <summary>
        /// 删除成绩
        /// </summary>
        public ICommand DeleteScoreInfoCommand
        {
            get
            {
                return _DeleteScoreInfoCommand ??
                    (_DeleteScoreInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedScore == null || SelectedScore.Score == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "ScoreWarningMsg");
                                return;
                            }
                            var student = StudentHttpUtil.GetStudent(SelectedScore.Score.StudentId); // 获取选中的成绩的学生对象
                            var course = CourseHttpUtil.GetCourse(SelectedScore.Score.CourseId); // 获取选中的成绩的课程对象
                            // 删除单个成绩
                            if (para == "DeleteOnlyOneScore" || SeletedScoreList.Count == 1)
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{student.Name}]的[{course.Name}]成绩?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                // 确认删除
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = ClassHttpUtil.DeleteClass(SelectedScore.Score.Id);
                                    if (resultDelete)
                                    {
                                        HandyControl.Controls.Growl.Success($"成功删除成绩！", "ScoreSuccessMsg");
                                        // 刷新列表
                                        var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                                        RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "ScoreWarningMsg");
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            // 删除多个成绩
                            else if (para == "DeleteNotOnlyOneScore")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除{SeletedScoreList.Count}个成绩", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var scoreDto in SeletedScoreList)
                                    {
                                        var resultDelete = ClassHttpUtil.DeleteClass(scoreDto.Score.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除失败，请刷新列表后重试！", "ScoreWarningMsg");
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个成绩,失败删除{errorCount}个成绩");
                                    // 刷新列表
                                    var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                                    RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "ScoreErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion

        // 完成
        #region 搜索命令

        private ICommand _SearchScoreCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand SearchScoreCommand
        {
            get
            {
                return _SearchScoreCommand ??
                    (_SearchScoreCommand = new RelayCommand(() =>
                    {

                        CurrentPage = 1; // 设置当前页面为第一页
                                         // 根据 搜索条件 搜索，刷新列表

                        if (CurrentScoreType == ScoreType.Single && SingleStatus == Visibility.Visible)
                        {
                            var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                            RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                        }
                        else if (CurrentScoreType == ScoreType.All && AllStatus == Visibility.Visible)
                        {
                            var classSearch = ClassHttpUtil.GetClassByName(SearchClassName);
                            InitializeTable(SearchExamName, classSearch.Id);
                        }

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
                        SearchScoreNumber = null;
                        SearchStudentName = null;
                        SearchClassName = null;
                        SearchGradeName = null;
                        SearchExamName = null;

                        CurrentPage = 1;
                        PerPageCount = 20;
                        // 刷新列表
                        var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                        RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _SearchGradeChangedCommand;
        /// <summary>
        /// 搜索的年级改变时，改变班级列表
        /// </summary>
        public ICommand SearchGradeChangedCommand
        {
            get
            {
                return _SearchGradeChangedCommand ??
                    (_SearchGradeChangedCommand = new RelayCommand(() =>
                    {
                        SearchClassNameList.Clear();
                        if (string.IsNullOrEmpty(SearchGradeName))
                        {
                            return;
                        }
                        foreach (var item in ClassHttpUtil.GetClassByGrade(GradeDic[SearchGradeName]).items)
                        {
                            SearchClassNameList.Add(item.Name);
                        }

                    }));
            }
        }

        private ICommand _SearchClassChangedCommand;
        /// <summary>
        /// 根据班级类型获取课程
        /// </summary>
        public ICommand SearchClassChangedCommand
        {
            get
            {
                return _SearchClassChangedCommand ??
                    (_SearchClassChangedCommand = new RelayCommand(() =>
                    {
                        SearchCourseNameList.Clear();
                        var searchClass = ClassHttpUtil.GetClassByName(SearchClassName);
                        var courseList = CourseHttpUtil.GetCourseByClassType(searchClass.ClassType).items;
                        if (searchClass == null)
                        {
                            return;
                        }
                        // 获取理科科目
                        if (searchClass.ClassType == 0)
                        {
                            // 添加到表中
                            foreach (var item in courseList)
                            {
                                if (item.CourseType == 0 || item.CourseType == 2)
                                {
                                    SearchCourseNameList.Add(item.Name);
                                }

                            }
                            return;

                        }
                        // 文科
                        else if (searchClass.ClassType == 1)
                        {
                            // 添加到表中
                            foreach (var item in courseList)
                            {
                                if (item.CourseType == 1 || item.CourseType == 2)
                                {
                                    SearchCourseNameList.Add(item.Name);
                                }

                            }
                            return;

                        }

                    }));
            }
        }



        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _ScoreInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand ScoreInfoDialogLoadedCommand
        {
            get
            {
                return _ScoreInfoDialogLoadedCommand ??
                    (_ScoreInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _ScoreInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand ScoreInfoDialogUnloadedCommand
        {
            get
            {
                return _ScoreInfoDialogUnloadedCommand ??
                    (_ScoreInfoDialogUnloadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogExaminationNameList.Clear(); // 清空考次
                        DialogGradeNameList.Clear(); // 清空年级列表
                        DialogClassNameList.Clear(); // 清空班级列表
                        DialogCourseNameList.Clear(); // 清空课程列表
                        DialogExaminationName = null;
                        DialogGradeName = null; ;
                        DialogClassName = null;
                        DialogStudentName = null;
                        DialogCourseName = null;
                        DialogStudentId = 0;
                        DialogScoreNumber = 0;
                        DialogIsEnabled = false;
                        DialogScore = new ScoreDto(); // 重新 赋值 成绩实例
                    }));
            }
        }

        private ICommand _AddScoreInfoCommand;
        /// <summary>
        /// 打开 添加成绩 窗体
        /// </summary>
        public ICommand AddScoreInfoCommand
        {
            get
            {
                return _AddScoreInfoCommand ??
                    (_AddScoreInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加成绩"; // 窗体标题
                        DialogIsEnabled = true; // 可编辑
                        DialogExaminationNameList.Clear(); // 清空考次
                        DialogGradeNameList.Clear(); // 清空年级列表
                        DialogClassNameList.Clear(); // 清空班级列表
                        DialogStudentNameList.Clear(); // 清空学生姓名列表
                        DialogCourseNameList.Clear(); // 清空课程列表

                        // 初始化考次列表
                        foreach (var item in AllExamination)
                        {
                            DialogExaminationNameList.Add(item.Examination.Name);
                        }
                        foreach (var item in ExaminationHttpUtil.GetAllExamination().items)
                        {
                            DialogExaminationNameList.Add(item.Name);
                        }

                        // 初始化年级列表
                        foreach (var item in AllGrade)
                        {
                            DialogGradeNameList.Add(item.Grade.Name);
                        }

                        DialogScore = new ScoreDto(); // 窗体成绩

                        // 打开窗体
                        scoreInfoDialog = HandyControl.Controls.Dialog.Show<ScoreInfoDialog>();
                    }));
            }
        }

        private ICommand _EditScoreInfoCommand;
        /// <summary>
        /// 打开 编辑成绩 窗体
        /// </summary>
        public ICommand EditScoreInfoCommand
        {
            get
            {
                return _EditScoreInfoCommand ??
                    (_EditScoreInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedScore == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择要修改的成绩！", "ScoreWarningMsg");
                            return;
                        }
                        if (SeletedScoreList.Count > 1)
                        {
                            HandyControl.Controls.Growl.Warning("请选择一个要修改的成绩！", "ScoreWarningMsg");
                            return;
                        }
                        DialogTitle = "修改成绩";
                        DialogScore = new ScoreDto() { Score = (Scores)SelectedScore.Score.Clone() }; // 克隆参数

                        DialogExaminationNameList.Clear(); // 清空考次
                        DialogGradeNameList.Clear(); // 清空年级列表
                        DialogClassNameList.Clear(); // 清空班级列表
                        DialogCourseNameList.Clear(); // 清空课程列表

                        // 获取当前选择的学生的考次
                        DialogExaminationName = ExaminationHttpUtil.GetExamination(DialogScore.Score.ExamId).Name;
                        DialogExaminationNameList.Add(DialogExaminationName);
                        // 获取当前选择的学生的年级
                        DialogGradeName = GradeHttpUtil.GetGrade(DialogScore.Score.GradeId).Name;
                        DialogGradeNameList.Add(DialogGradeName);
                        // 获取当前选择的学生的班级
                        DialogClassName = ClassHttpUtil.GetClass(SelectedScore.Score.ClassId).Name;
                        DialogClassNameList.Add(DialogClassName);
                        // 获取当前选择的学生的名称
                        DialogStudentName = StudentHttpUtil.GetStudent(SelectedScore.Score.StudentId).Name;
                        DialogStudentNameList.Add(DialogStudentName);
                        // 学生学号
                        DialogStudentId = DialogScore.Score.StudentId;
                        // 获取当前选择的学生的科目
                        DialogCourseName = CourseHttpUtil.GetCourse(SelectedScore.Score.CourseId).Name;
                        DialogCourseNameList.Add(DialogCourseName);
                        DialogIsEnabled = false; // 启动不可编辑
                        // 打开窗体
                        scoreInfoDialog = HandyControl.Controls.Dialog.Show<ScoreInfoDialog>();
                    }));
            }
        }

        private ICommand _SubmitScoreInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitScoreInfoCommand
        {
            get
            {
                return _SubmitScoreInfoCommand ??
                    (_SubmitScoreInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (DialogScore == null || DialogScore.Score == null)
                            {
                                return;
                            }
                            // 添加成绩
                            if (DialogTitle == "添加成绩")
                            {
                                DialogScore.Score.Number = DialogScoreNumber; // 分数
                                DialogScore.Score.TeacherId = TeacherHttpUtil.GetTeacher_CourseByCourse(DialogScore.Score.CourseId).TeacherId; // 获取教师ID
                                DialogScore.Score.insertTime = DateTime.Now; // 获取时间
                                var id = ScoreHttpUtil.AddScore(DialogScore.Score); // 添加成绩

                                // 是否添加成功
                                if (id > 0)
                                {
                                    // 关闭窗体
                                    scoreInfoDialog.Close();
                                    // 刷新
                                    var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                                    RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"成绩添加成功！", "ScoreSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("成绩添加失败！", "ScoreInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改成绩
                            else if (DialogTitle == "修改成绩")
                            {
                                var resultEdit = ScoreHttpUtil.UpdateScore(DialogScore.Score);
                                if (resultEdit)
                                {
                                    var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                                    RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                                    scoreInfoDialog.Close();
                                    HandyControl.Controls.Growl.Success($"修改成功！", "ScoreSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("成绩修改失败！", "ScoreInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "ScoreErrorMsg");
                            return;
                        }
                    }));
            }
        }

        private ICommand _DialogGradeChangedCommand;
        /// <summary>
        /// 年级改变时
        /// </summary>
        public ICommand DialogGradeChangedCommand
        {
            get
            {
                return _DialogGradeChangedCommand ??
                    (_DialogGradeChangedCommand = new RelayCommand(() =>
                    {
                        DialogClassNameList.Clear();
                        if (string.IsNullOrEmpty(DialogGradeName))
                        {
                            return;
                        }
                        DialogScore.Score.GradeId = GradeDic[DialogGradeName]; // 接收选择的年级Id
                        DialogScore.Score.ExamId = ExaminationHttpUtil.GetExaminationByName(DialogExaminationName).Id; //接收选择的考次Id 
                                                                                                                       // 根据年级相应 获取 班级列表
                        foreach (var item in ClassesDic[GradeDic[DialogGradeName]])
                        {
                            DialogClassNameList.Add(item.Name); // ObservableCollection使得前端同时改变
                        }
                    }));
            }
        }

        private ICommand _DialogClassChangedCommand;
        /// <summary>
        /// 班级改变时，更新科目
        /// </summary>
        public ICommand DialogClassChangedCommand
        {
            get
            {
                return _DialogClassChangedCommand ??
                    (_DialogClassChangedCommand = new RelayCommand(() =>
                    {
                        DialogCourseNameList.Clear(); // 清空科目列表
                        if (string.IsNullOrEmpty(DialogClassName))
                        {
                            return;
                        }
                        // 获取班级Id
                        foreach (var item in AllClasses)
                        {
                            if (item.Classes.Name == DialogClassName)
                            {
                                DialogScore.Score.ClassId = item.Classes.Id; // 接收选择的班级
                            }
                        }

                        // 遍历所有班级
                        foreach (var item in AllClasses)
                        {
                            // 符合所选的班级，获取科目列表
                            if (item.Classes.Name == DialogClassName)
                            {
                                // 理科班级
                                if (item.Classes.ClassType == 0) // 理科班级
                                {
                                    // 获取理科科目
                                    foreach (var science in SearchAllCourse)
                                    {
                                        if (science.Course.CourseType == 2) // 基本课程
                                        {
                                            DialogCourseNameList.Add(science.Course.Name);
                                        }
                                        if (science.Course.CourseType == 0) // 理科
                                        {
                                            DialogCourseNameList.Add(science.Course.Name);
                                        }

                                    }
                                    DialogStudentNameList.Clear();
                                    // 获取学生列表
                                    foreach (var student in StudentHttpUtil.GetStudentByClass(DialogScore.Score.ClassId).items)
                                    {
                                        DialogStudentNameList.Add(student.Name);
                                    }
                                }
                                // 文科班级
                                else if (item.Classes.ClassType == 1)
                                {
                                    // 获取文科科目
                                    foreach (var art in SearchAllCourse)
                                    {
                                        if (art.Course.CourseType == 2) // 基本课程
                                        {
                                            DialogCourseNameList.Add(art.Course.Name);
                                        }
                                        if (art.Course.CourseType == 1) // 文科
                                        {
                                            DialogCourseNameList.Add(art.Course.Name);
                                        }
                                    }
                                    // 获取学生列表
                                    foreach (var student in StudentHttpUtil.GetStudentByClass(DialogScore.Score.Id).items)
                                    {
                                        DialogStudentNameList.Add(student.Name);
                                    }
                                }
                            }
                        }
                    }));
            }
        }

        private ICommand _DialogStudentChangedCommand;
        /// <summary>
        /// 学生姓名改变时，获取学号 和 指定科目成绩
        /// </summary>
        public ICommand DialogStudentChangedCommand
        {
            get
            {
                return _DialogStudentChangedCommand ??
                    (_DialogStudentChangedCommand = new RelayCommand(() =>
                    {
                        if (string.IsNullOrEmpty(DialogStudentName))
                        {
                            return;
                        }
                        DialogStudentId = StudentHttpUtil.GetStudentByName(DialogStudentName).Id;
                        DialogScore.Score.StudentId = DialogStudentId; // 接收选择的学生的学号

                    }));
            }
        }

        private ICommand _DialogCourseChangedCommand;
        /// <summary>
        /// 科目改变时，获取指定科目成绩
        /// </summary>
        public ICommand DialogCourseChangedCommand
        {
            get
            {
                return _DialogCourseChangedCommand ??
                    (_DialogCourseChangedCommand = new RelayCommand(() =>
                    {
                        if (string.IsNullOrEmpty(DialogCourseName))
                        {
                            return;
                        }
                        DialogScore.Score.CourseId = CourseHttpUtil.GetCourseByName(DialogCourseName).Id;

                        // 获取指定科目成绩
                        var result = ScoreHttpUtil.GetScoreByStuAndCourse(DialogScore.Score.StudentId, DialogScore.Score.CourseId, DialogScore.Score.ExamId);
                        if (result == null)
                        {
                            DialogScoreNumber = 0;
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
                        var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                        RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
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
                        var scoreList = ScoreHttpUtil.GetScoresSingle(SearchScoreNumber, SearchStudentName, SearchCourseName, SearchClassName, SearchGradeName, SearchExamName, CurrentPage, PerPageCount);
                        RefreshSingleScoreList(scoreList.items, scoreList.TotalCount);
                        return;
                    }));
            }
        }



        #endregion

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
                        SearchPanelVis = (SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
                    }));
            }
        }


        private ICommand _ScoreStatusChangeCommand;
        /// <summary>
        /// 单科表格和全科表格切换
        /// </summary>
        public ICommand ScoreStatusChangeCommand
        {
            get
            {
                return _ScoreStatusChangeCommand ??
                    (_ScoreStatusChangeCommand = new RelayCommand(() =>
                    {
                        // 显示全科
                        if (SingleStatus == Visibility.Visible)
                        {
                            SingleStatus = Visibility.Collapsed;
                            AllStatus = Visibility.Visible;
                        }
                        // 显示单科
                        else
                        {
                            SingleStatus = Visibility.Visible;
                            AllStatus = Visibility.Collapsed;
                        }
                    }));
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="allScoreList"></param>
        /// <param name="totalCount"></param>
        private void RefreshSingleScoreList(List<Scores> allScoreList, int totalCount)
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

            ScoreList.Clear();

            allScoreList.ForEach(g =>
            {
                ScoreList.Add(new ScoreDto() { Score = g });
            });

        }


        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="allScoreList"></param>
        /// <param name="totalCount"></param>
        private void RefreshAllScoreList(List<Scores> allScoreList, int totalCount)
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

            ScoreList.Clear();

            allScoreList.ForEach(g =>
            {
                ScoreList.Add(new ScoreDto() { Score = g });
            });

        }

        /// <summary>
        /// 初始化全局属性（所有年级，所有班级，所有课程）
        /// </summary>
        private void InitializeAllProp()
        {

            foreach (var item in ExaminationHttpUtil.GetAllExamination().items) // 考次
            {
                AllExamination.Add(new ExaminationDto() { Examination = item });
            }
            foreach (var item in GradeHttpUtil.GetAllGrade().items) // 年级
            {
                AllGrade.Add(new GradeDto() { Grade = item });
            }
            foreach (var item in ClassHttpUtil.GetAllClass().items) // 科目
            {
                AllClasses.Add(new ClassDto() { Classes = item });
            }
            foreach (var item in CourseHttpUtil.GetAllCourse().items) // 课程
            {
                AllCourse.Add(new CourseDto() { Course = item });
            }
        }

        /// <summary>
        /// 初始化搜索内容
        /// </summary>
        private void InitializeSearch()
        {
            // 获取全部考次
            foreach (var item in ExaminationHttpUtil.GetAllExamination().items)
            {
                SearchExamNameList.Add(item.Name);
            }
            if (SearchExamNameList.Count > 0)
            {
                SearchExamName = SearchExamNameList[0];
            }

            // 获取 所有年级
            foreach (var item in GradeHttpUtil.GetAllGrade().items)
            {
                SearchGradeNameList.Add(item.Name);
                if (!GradeDic.ContainsKey(item.Name))
                {
                    GradeDic.Add(item.Name, item.Id); // 年级名称， 年级Id
                }
            }
            // 获取 每个年级 的 所有班级
            foreach (var gradeId in GradeDic.Values)
            {
                ClassesDic.Add(gradeId, new List<Classes>()); // 年级Id, 班级列表
                var a = ClassHttpUtil.GetClassByGrade(gradeId).items;
                ClassesDic[gradeId] = a;
            }
            // 获取 当前年级 的 所有班级（搜索）
            foreach (var item in ClassesDic[1])
            {
                SearchClassNameList.Add(item.Name);
            }

            // 全部科目列表
            foreach (var item in CourseHttpUtil.GetAllCourse().items)
            {
                SearchAllCourse.Add(new CourseDto() { Course = item });
                SearchCourseNameList.Add(item.Name); // 搜索框 课程列表
            }
        }

        /// <summary>
        /// 初始化全科表格
        /// </summary>
        private void InitializeTable(string examName, int ClassId)
        {
            // 清空表格
            ScoreTable.Clear();
            // 获取某班级学生
            var studentList = StudentHttpUtil.GetStudentByClass(ClassId).items;
            // 获取理科课程
            var scientCourse = CourseHttpUtil.GetCourseByType(0);
            // 获取考次
            var examNew = ExaminationHttpUtil.GetExaminationByName(examName);
            if (ScoreTable.Columns.Count <= 0)
            {
               
                ScoreTable.Columns.Add("学生姓名");
               
                foreach (var item in scientCourse)
                {
                    ScoreTable.Columns.Add(item.Name);
                }
                ScoreTable.Columns.Add("总分"); 
            }
            foreach (var student in studentList)
            {
                var scoreRow = ScoreTable.NewRow();
                // 学生姓名
                scoreRow["学生姓名"] = StudentHttpUtil.GetStudent(student.Id).Name;
                // 每一科成绩
                int scoreCount = 0;
                foreach (var course in scientCourse)
                {
                    // 获取考生在当前考次的科目的成绩
                    var score = ScoreHttpUtil.GetScoreByStuAndCourse(student.Id, course.Id, examNew.Id);
                    var number = 0;
                    if (score != null)
                    {
                        number = score.Number;
                    }
                    scoreRow[course.Name] = number;
                    scoreCount += number;
                }
                // 获取总分
                scoreRow["总分"] = scoreCount;
                // 将列添加到表格中
                ScoreTable.Rows.Add(scoreRow);
            }

            TotalCount = ScoreTable.Rows.Count;
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

        }

        /// <summary>
        /// 学生信息发生变换
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void StudentChanged(List<Students> s)
        {
            foreach (var item in s)
            {
                DialogStudentNameList.Add(item.Name);
            }
        }

        /// <summary>
        /// 班级信息发生变化
        /// </summary>
        /// <param name="c"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ClassChanged(List<Students> c)
        {
            foreach (var item in c)
            {
                DialogClassNameList.Add(item.Name);
                SearchClassNameList.Add(item.Name);
            }
        }

        /// <summary>
        /// 年级发生变换
        /// </summary>
        /// <param name="g"></param>
        private void GradeChanged(List<Grades> g)
        {
            foreach (var item in g)
            {
                DialogGradeNameList.Add(item.Name);
                SearchGradeNameList.Add(item.Name);
            }
        }

        /// <summary>
        /// 课程列表发生变换
        /// </summary>
        /// <param name="c"></param>
        private void CourseChanged(List<Courses> c)
        {
            foreach (var item in c)
            {
                DialogCourseNameList.Add(item.Name);
                SearchCourseNameList.Add(item.Name);
            }
        }

        #endregion
    }
}
