using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Http.InformationManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using ManagerSystem.Entity.InformationManager.Link;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public class CourseViewModel : ViewModelBase
    {

        public CourseViewModel()
        {
            // 获取选择的多行数据
            Messenger.Default.Register<List<CourseDto>>(this, "SelectedCourses", items=> SelectedCourses = items);
            // 初始化列表
            SearchCourseTypeList = new List<string>() { "全部学科", "普通学科", "理科", "文科" };
            DialogCourseTypeList = new List<string>() {"普通学科", "理科", "文科" };

            // 遍历分页获取所有课程
            foreach (var item in CourseHttpUtil.GetCourses(null,4,1,20).items)
            {
                CourseList.Add(new CourseDto() { Course = item });
            }

        }
        #region 属性

        #region 课程属性

        private ObservableCollection<CourseDto> _CourseList = new ObservableCollection<CourseDto>();
        /// <summary>
        /// 课程列表
        /// </summary>
        public ObservableCollection<CourseDto> CourseList
        {
            get { return _CourseList; }
            set
            {
                _CourseList = value;
                RaisePropertyChanged();
            }
        }

        private CourseDto _SelectedCourse;
        /// <summary>
        /// 选择的课程
        /// </summary>
        public CourseDto SelectedCourse
        {
            get { return _SelectedCourse; }
            set
            {
                _SelectedCourse = value;
                RaisePropertyChanged();
            }
        }

        private List<CourseDto> _SelectedCourses = new List<CourseDto>();
        /// <summary>
        /// 选择的课程课程
        /// </summary>
        public List<CourseDto> SelectedCourses
        {
            get { return _SelectedCourses; }
            set
            {
                _SelectedCourses = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 搜索属性


        private string _SearchCourseName;
        /// <summary>
        /// 搜索的课程的名称
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

        private int _SearchdCourseType;
        /// <summary>
        /// 搜索的课程类型
        /// </summary>
        public int SearchdCourseType
        {
            get { return _SearchdCourseType; }
            set
            {
                _SearchdCourseType = value;
                RaisePropertyChanged();
            }
        }


        private List<string> _SearchCourseTypeList;
        /// <summary>
        /// 搜索的课程类型列表
        /// </summary>
        public List<string> SearchCourseTypeList
        {
            get { return _SearchCourseTypeList; }
            set
            {
                _SearchCourseTypeList = value;
                RaisePropertyChanged();
            }
        }




        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改课程）
        /// </summary>
        private Dialog courseInfoDialog;

        private CourseDto _DialogCourse = new CourseDto();
        /// <summary>
        /// 弹窗中的 课程
        /// </summary>
        public CourseDto DialogCourse
        {
            get { return _DialogCourse; }
            set
            {
                _DialogCourse = value;
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

        private List<string> _DialogCourseTypeList;
        /// <summary>
        /// 窗体 课程类型列表
        /// </summary>
        public List<string> DialogCourseTypeList
        {
            get { return _DialogCourseTypeList; }
            set
            {
                _DialogCourseTypeList = value;
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

        #region 课程命令

        private ICommand _DeleteCourseInfoCommand;
        /// <summary>
        /// 删除课程
        /// </summary>
        public ICommand DeleteCourseInfoCommand
        {
            get
            {
                return _DeleteCourseInfoCommand ??
                    (_DeleteCourseInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedCourse == null || SelectedCourse.Course == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "CourseWarningMsg");
                                return;
                            }
                            // 删除单个课程
                            if (para == "DeleteOnlyOneCourse")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"删除名为[{SelectedCourse.Course.Name}]的课程, 同时将会删除相关学生的所有成绩以及教师教学科目,是否继续? ", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                // 确认删除
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = CourseHttpUtil.DeleteCourse(SelectedCourse.Course.Id); // 删除课程
                                    // 删除成功
                                    if (resultDelete)
                                    {
                                        // 删除相关的表数据 (成绩表数据)
                                        foreach (var item in ScoreHttpUtil.GetScoreByCourse(SelectedCourse.Course.Name).items) // 获取当前课程的全部成绩
                                        {
                                            ScoreHttpUtil.DeleteScore(item.Id); // 删除 相关课程的全部成绩数据
                                        }

                                        // 修改相关教师数据 (将教师的课程修改为NULL)
                                        foreach (var item in TeacherHttpUtil.GetTeacherByCourse(DialogCourse.Course.Name).items)
                                        {
                                            item.Subject = "NULL";
                                            TeacherHttpUtil.UpdateTeacher(item);
                                            // 删除教师_课程中间表
                                            TeacherHttpUtil.DeleteCourses_Teachers(DialogCourse.Course.Id, item.Id);
                                            // 添加教师_课程中间表
                                            TeacherHttpUtil.AddCourses_Teachers(new Courses_Teachers() { CourseId = 14, TeacherId = item.Id, insertTime = DateTime.Now });
                                        }
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{SelectedCourse.Course.Name}]的课程！", "CourseSuccessMsg");
                                        // 刷新列表
                                        var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                                        RefreshCourseList(courseList.items, courseList.TotalCount);
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "CourseWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个课程
                            else if (para == "DeleteNotOnlyOneCourse")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SelectedCourses.Count == 1 ? $"是否删除名为[{SelectedCourse.Course.Name}]的课程?" : $"是否删除{SelectedCourses.Count}个课程",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var courseDto in SelectedCourses)
                                    {
                                        var resultDelete = CourseHttpUtil.DeleteCourse(courseDto.Course.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除{courseDto.Course.Name}失败，请刷新列表后重试！", "CourseWarningMsg");
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;

                                            // 删除相关的表数据 (成绩表数据)
                                            foreach (var item in ScoreHttpUtil.GetScoreByCourse(courseDto.Course.Name).items) // 获取当前课程的全部成绩
                                            {
                                                ScoreHttpUtil.DeleteScore(item.Id); // 删除 相关课程的全部成绩数据
                                            }

                                            // 修改相关教师数据 (将教师的课程修改为NULL)
                                            foreach (var item in TeacherHttpUtil.GetTeacherByCourse(courseDto.Course.Name).items)
                                            {
                                                item.Subject = "NULL";
                                                TeacherHttpUtil.UpdateTeacher(item);
                                                // 删除教师_课程中间表
                                                TeacherHttpUtil.DeleteCourses_Teachers(courseDto.Course.Id, item.Id);
                                                // 添加教师_课程中间表
                                                TeacherHttpUtil.AddCourses_Teachers(new Courses_Teachers() { CourseId = 14, TeacherId = item.Id, insertTime = DateTime.Now });
                                            }
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个课程,失败删除{errorCount}个课程");
                                    // 刷新列表
                                    var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                                    RefreshCourseList(courseList.items, courseList.TotalCount);
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "CourseErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion


        #region 搜索命令

        private ICommand _SearchCourseCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand SearchCourseCommand
        {
            get
            {
                return _SearchCourseCommand ??
                    (_SearchCourseCommand = new RelayCommand(() =>
                    {

                        CurrentPage = 1; // 设置当前页面为第一页
                        // 根据 搜索条件 搜索，刷新列表
                        var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                        RefreshCourseList(courseList.items, courseList.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _ResetConditionalSearchCourseCommand;
        /// <summary>
        /// 重置搜索条件，并刷新数据
        /// </summary>
        public ICommand ResetConditionalSearchCourseCommand
        {
            get
            {
                return _ResetConditionalSearchCourseCommand ??
                    (_ResetConditionalSearchCourseCommand = new RelayCommand(() =>
                    {
                        SearchCourseName = null;
                        SearchdCourseType = 3;
                        CurrentPage = 1;
                        // 刷新列表
                        var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                        RefreshCourseList(courseList.items, courseList.TotalCount);
                        return;
                    }));
            }
        }


        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _CourseInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand CourseInfoDialogLoadedCommand
        {
            get
            {
                return _CourseInfoDialogLoadedCommand ??
                    (_CourseInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _CourseInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand CourseInfoDialogUnloadedCommand
        {
            get
            {
                return _CourseInfoDialogUnloadedCommand ??
                    (_CourseInfoDialogLoadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogCourse = new CourseDto(); // 重新 赋值 课程实例
                    }));
            }
        }

        private ICommand _AddCourseInfoCommand;
        /// <summary>
        /// 打开 添加课程 窗体
        /// </summary>
        public ICommand AddCourseInfoCommand
        {
            get
            {
                return _AddCourseInfoCommand ??
                    (_AddCourseInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加课程";
                        DialogCourse = new CourseDto() { Course = new Courses() };
                        // 打开窗体
                        courseInfoDialog = HandyControl.Controls.Dialog.Show<CourseInfoDialog>();
                    }));
            }
        }

        private ICommand _EditCourseInfoCommand;
        /// <summary>
        /// 打开 编辑课程 窗体
        /// </summary>
        public ICommand EditCourseInfoCommand
        {
            get
            {
                return _EditCourseInfoCommand ??
                    (_EditCourseInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedCourse == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择要修改的课程！", "CourseWarningMsg");
                            return;
                        }
                        if (SelectedCourses.Count >= 2)
                        {
                            HandyControl.Controls.Growl.Warning("请选择单个修改的课程！", "CourseWarningMsg");
                            return;
                        }
                        DialogTitle = "修改课程";
                        // 使用直接赋值，会指向同一个对象实例
                        // 使用使用Clone()创建副本，形成两个独立的对象，修改对话框中的数据不会影响原始数据。
                        DialogCourse = new CourseDto() { Course = (Courses)SelectedCourse.Course.Clone() };
                        // 打开窗体
                        courseInfoDialog = HandyControl.Controls.Dialog.Show<CourseInfoDialog>();
                    }));
            }
        }

        private ICommand _SubmitCourseInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitCourseInfoCommand
        {
            get
            {
                return _SubmitCourseInfoCommand ??
                    (_SubmitCourseInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (DialogCourse == null || DialogCourse.Course == null)
                            {
                                return;
                            }
                            // 课程名称是否为空
                            if (string.IsNullOrEmpty(DialogCourse.Course.Name))
                            {
                                HandyControl.Controls.Growl.Warning("课程名称不能为空！", "CourseInfoWarningMsg");
                                return;
                            }
                            // 添加课程
                            if (DialogTitle == "添加课程")
                            {
                                if (CourseHttpUtil.GetCourseByName(DialogCourse.Course.Name) != null)
                                {
                                    HandyControl.Controls.Growl.Warning("课程名称已经存在！", "CourseInfoWarningMsg");
                                    return;
                                }

                                DialogCourse.Course.insertTime = DateTime.Now; // 获取时间
                                var id = CourseHttpUtil.AddCourse(DialogCourse.Course); // 添加课程
                                // 是否添加成功
                                if (id > 0)
                                {
                                    // 关闭窗体
                                    courseInfoDialog.Close();
                                    // 刷新
                                    var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                                    RefreshCourseList(courseList.items, courseList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"课程添加成功！", "CourseSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("课程添加失败！", "CourseInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改课程
                            else if (DialogTitle == "修改课程")
                            {
                                // 是否存在
                                if (CourseHttpUtil.GetCourseByName(DialogCourse.Course.Name) != null)
                                {
                                    HandyControl.Controls.Growl.Warning("课程名称已经存在！", "CourseInfoWarningMsg");
                                    return;
                                }
                                // 修改
                                var resultEdit = CourseHttpUtil.UpdateCourse(DialogCourse.Course);

                                if (resultEdit)
                                {
                                    // 刷新列表
                                    var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                                    RefreshCourseList(courseList.items, courseList.TotalCount);
                                    courseInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"修改成功！", "CourseSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("课程修改失败！", "CourseInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "CourseErrorMsg");
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
                        var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                        RefreshCourseList(courseList.items, courseList.TotalCount);
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
                        var courseList = CourseHttpUtil.GetCourses(SearchCourseName, SearchdCourseType, CurrentPage, PerPageCount);
                        RefreshCourseList(courseList.items, courseList.TotalCount);
                        return;
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
        /// <param name="allCourseList"></param>
        /// <param name="totalCount"></param>
        private void RefreshCourseList(List<Courses> allCourseList, int totalCount)
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

            CourseList.Clear();

            //var allStudent = StudentHttpUtil.GetAllStudent();
            //var allClass = ClassHttpUtil.GetAllClass();
            //allCourseList.ForEach(g =>
            //{
            //    var classList = allClass.items.Where(c => c.CourseId == g.Id);
            //    List<Students> studentList = new List<Students>();
            //    foreach (var item in classList)
            //    {
            //        studentList = allStudent.items.Where(s => s.ClassId == item.Id).ToList();
            //    }

            //    CourseList.Add(new CourseDto() { Course = g,CoursePersonCount = studentList.Count });
            //});

            allCourseList.ForEach(g =>
            {
                CourseList.Add(new CourseDto() { Course = g });
            });
        }

        #endregion
    }
}
