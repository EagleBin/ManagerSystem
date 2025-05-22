using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
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
using ManagerSystem.Utils.Http.InformationManager;
using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using System.Security;
using ManagerSystem.Entity.InformationManager.Link;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public class ClassViewModel : ViewModelBase
    {


        public ClassViewModel()
        {
            Messenger.Default.Register<List<ClassDto>>(this, "SelectedClasses", cl => SelectedClassList = cl);
            SearchClassesTypeList = new List<string>() { "全部班级", "理科班级", "文科班级" }; // 初始化班级类型
            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 }; // 初始化每页容量
            // 年级列表
            foreach (var item in GradeHttpUtil.GetAllGrade().items)
            {
                SearchGradeList.Add(new GradeDto() { Grade = item });
            };
            // 班级列表
            var classList = ClassHttpUtil.GetClasses(null, null, 2, CurrentPage, PerPageCount);
            RefreshClassesList(classList.items, classList.TotalCount);

            // 初始化 窗体年级列表
            foreach (var grade in GradeHttpUtil.GetAllGrade().items)
            {
                DialogGradeNameList.Add(grade.Name);
            }
            // 初始化 窗体班级类型
            DialogClassesTypeList = new List<string>() { "理科班级", "文科班级" }; // 班级类型
            return;
        }

        #region 属性

        #region 班级属性

        private ObservableCollection<ClassDto> _ClassesList = new ObservableCollection<ClassDto>();
        /// <summary>
        /// 班级列表
        /// </summary>
        public ObservableCollection<ClassDto> ClassesList
        {
            get { return _ClassesList; }
            set
            {
                _ClassesList = value;
                RaisePropertyChanged();
            }
        }

        private ClassDto _SelectedClasses;
        /// <summary>
        /// 选择的班级
        /// </summary>
        public ClassDto SelectedClasses
        {
            get { return _SelectedClasses; }
            set
            {
                _SelectedClasses = value;
                RaisePropertyChanged();
            }
        }

        private List<ClassDto> _SelectedClassList;
        /// <summary>
        /// 选择的班级班级
        /// </summary>
        public List<ClassDto> SelectedClassList
        {
            get { return _SelectedClassList; }
            set
            {
                _SelectedClassList = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 搜索属性

        private List<GradeDto> _SearchGradeList = new List<GradeDto>();
        /// <summary>
        /// 搜索的 年级的列表
        /// </summary>
        public List<GradeDto> SearchGradeList
        {
            get { return _SearchGradeList; }
            set
            {
                _SearchGradeList = value;
                RaisePropertyChanged();
            }
        }

        private GradeDto _SearchGrade = new GradeDto() { Grade = new Grades() };
        /// <summary>
        /// 搜索 的年级
        /// </summary>
        public GradeDto SearchGrade
        {
            get { return _SearchGrade; }
            set
            {
                _SearchGrade = value;
                RaisePropertyChanged();
            }
        }


        private string _SearchClassesName;
        /// <summary>
        /// 搜索的班级的名称
        /// </summary>
        public string SearchClassesName
        {
            get { return _SearchClassesName; }
            set
            {
                _SearchClassesName = value;
                RaisePropertyChanged();
            }
        }

        private int _SearchClassesType = 2;
        /// <summary>
        /// 搜索的班级的类别
        /// </summary>
        public int SearchClassesType
        {
            get { return _SearchClassesType; }
            set
            {
                _SearchClassesType = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _SearchClassesTypeList = new List<string>();
        /// <summary>
        /// 班级类型列表
        /// </summary>
        public List<string> SearchClassesTypeList
        {
            get { return _SearchClassesTypeList; }
            set
            {
                _SearchClassesTypeList = value;
                RaisePropertyChanged();
            }
        }




        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改班级）
        /// </summary>
        private Dialog gradeInfoDialog;

        private ClassDto _DialogClasses = new ClassDto();
        /// <summary>
        /// 弹窗中的 班级
        /// </summary>
        public ClassDto DialogClasses
        {
            get { return _DialogClasses; }
            set
            {
                _DialogClasses = value;
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

        private List<string> _DialogClassesTypeList = new List<string>();
        /// <summary>
        /// 窗体 班级类型列表
        /// </summary>
        public List<string> DialogClassesTypeList
        {
            get { return _DialogClassesTypeList; }
            set
            {
                _DialogClassesTypeList = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _DialogGradeNameList = new List<string>();
        /// <summary>
        /// 窗体 年级列表
        /// </summary>
        public List<string> DialogGradeNameList
        {
            get { return _DialogGradeNameList; }
            set
            {
                _DialogGradeNameList = value;
                RaisePropertyChanged();
            }
        }


        private TeacherDto _DialogHeadTeacher = new TeacherDto();
        /// <summary>
        /// 窗体 班主任
        /// </summary>
        public TeacherDto DialogHeadTeacher
        {
            get { return _DialogHeadTeacher; }
            set
            {
                _DialogHeadTeacher = value;
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

        #region 班级命令

        private ICommand _DeleteClassesInfoCommand;
        /// <summary>
        /// 删除班级
        /// </summary>
        public ICommand DeleteClassesInfoCommand
        {
            get
            {
                return _DeleteClassesInfoCommand ??
                    (_DeleteClassesInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedClasses == null || SelectedClasses.Classes == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "ClassesWarningMsg");
                                return;
                            }
                            // 删除单个班级
                            if (para == "DeleteOnlyOneClasses")
                            {
                                var deleteClasses = SelectedClasses;
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{deleteClasses.Classes.Name}]的班级?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = ClassHttpUtil.DeleteClass(deleteClasses.Classes.Id);
                                    if (resultDelete)
                                    {
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{deleteClasses.Classes.Name}]的班级！", "ClassesSuccessMsg");
                                        // 刷新列表
                                        var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                                        RefreshClassesList(gradeList.items, gradeList.TotalCount);
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "ClassesWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个班级
                            else if (para == "DeleteNotOnlyOneClasses")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SelectedClassList.Count == 1 ? $"是否删除名为[{SelectedClasses.Classes.Name}]的班级?" : $"是否删除{SelectedClassList.Count}个班级",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var gradeDto in SelectedClassList)
                                    {
                                        var resultDelete = ClassHttpUtil.DeleteClass(gradeDto.Classes.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除{gradeDto.Classes.Name}失败，请刷新列表后重试！", "ClassesWarningMsg");
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个班级,失败删除{errorCount}个班级");
                                    // 刷新列表
                                    var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                                    RefreshClassesList(gradeList.items, gradeList.TotalCount);
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "ClassesErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion


        #region 搜索命令

        private ICommand _SearchClassesCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand SearchClassesCommand
        {
            get
            {
                return _SearchClassesCommand ??
                    (_SearchClassesCommand = new RelayCommand(() =>
                    {

                        CurrentPage = 1; // 设置当前页面为第一页
                        // 根据 搜索条件 搜索，刷新列表
                        var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                        RefreshClassesList(gradeList.items, gradeList.TotalCount);
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
                        SearchClassesName = null;
                        SearchGrade = new GradeDto() { Grade = new Grades() };
                        SearchClassesType = 2;
                        CurrentPage = 1;
                        // 刷新列表
                        var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                        RefreshClassesList(gradeList.items, gradeList.TotalCount);
                        return;
                    }));
            }
        }


        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _ClassesInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand ClassesInfoDialogLoadedCommand
        {
            get
            {
                return _ClassesInfoDialogLoadedCommand ??
                    (_ClassesInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _ClassesInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand ClassesInfoDialogUnloadedCommand
        {
            get
            {
                return _ClassesInfoDialogUnloadedCommand ??
                    (_ClassesInfoDialogLoadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        DialogClasses = new ClassDto(); // 重新 赋值 班级实例
                        DialogHeadTeacher = new TeacherDto();
                    }));
            }
        }

        private ICommand _AddClassesInfoCommand;
        /// <summary>
        /// 打开 添加班级 窗体
        /// </summary>
        public ICommand AddClassesInfoCommand
        {
            get
            {
                return _AddClassesInfoCommand ??
                    (_AddClassesInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加班级"; // 窗体标题
                        DialogClasses = new ClassDto(); // 窗体班级

                        DialogHeadTeacher = new TeacherDto();
                        // 打开窗体
                        gradeInfoDialog = HandyControl.Controls.Dialog.Show<ClassesInfoDialog>();
                    }));
            }
        }

        private ICommand _EditClassesInfoCommand;
        /// <summary>
        /// 打开 编辑班级 窗体
        /// </summary>
        public ICommand EditClassesInfoCommand
        {
            get
            {
                return _EditClassesInfoCommand ??
                    (_EditClassesInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedClasses == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择要修改的班级！", "ClassesWarningMsg");
                            return;
                        }
                        if (SelectedClassList.Count > 1)
                        {
                            HandyControl.Controls.Growl.Warning("请选择一个要修改的班级！", "ClassesWarningMsg");
                            return;
                        }
                        DialogTitle = "修改班级";
                        // 使用直接赋值，会指向同一个对象实例
                        // 使用使用Clone()创建副本，形成两个独立的对象，修改对话框中的数据不会影响原始数据。
                        DialogClasses.Classes = (Classes)SelectedClasses.Classes.Clone();
                        DialogClasses.Teachers = (Teachers)TeacherHttpUtil.GetTeacher(DialogClasses.Classes.HeadTeacher_Id).Clone();
                        DialogHeadTeacher = new TeacherDto() { Teacher = (Teachers)DialogClasses.Teachers.Clone() };
                        // 打开窗体
                        gradeInfoDialog = HandyControl.Controls.Dialog.Show<ClassesInfoDialog>();
                    }));
            }
        }

        private ICommand _SubmitClassesInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitClassesInfoCommand
        {
            get
            {
                return _SubmitClassesInfoCommand ??
                    (_SubmitClassesInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (DialogClasses == null || DialogClasses.Classes == null)
                            {
                                return;
                            }
                            // 班级名称是否为空
                            if (string.IsNullOrEmpty(DialogClasses.Classes.Name))
                            {
                                HandyControl.Controls.Growl.Warning("班级名称不能为空！", "ClassesInfoWarningMsg");
                                return;
                            }
                            else if (string.IsNullOrEmpty(DialogClasses.Classes.GradeId.ToString()))
                            {
                                HandyControl.Controls.Growl.Warning("年级不能为空！", "ClassesInfoWarningMsg");
                                return;
                            }
                            // 添加班级
                            if (DialogTitle == "添加班级")
                            {
                                Teachers headTeacher = null;
                                if (ClassHttpUtil.GetClasses(DialogClasses.Classes.Name, "", 2, 1, 1).items.Count > 0) // 查看班级是否存在
                                {
                                    HandyControl.Controls.Growl.Warning("班级名称已经存在！", "ClassesInfoWarningMsg");
                                    return;
                                }
                                else if (!string.IsNullOrEmpty(DialogClasses.Teachers.Name)) // 查看教师是否存在
                                {
                                    var teacher = TeacherHttpUtil.GetTeacherByName(DialogClasses.Teachers.Name);
                                    if (teacher == null)
                                    {
                                        HandyControl.Controls.Growl.Warning("教师名称不存在！", "ClassesInfoWarningMsg");
                                        return;
                                    }
                                    else
                                    {
                                        // 教师存在
                                        headTeacher = teacher;
                                    }
                                }

                                DialogClasses.Classes.insertTime = DateTime.Now; // 获取时间
                                var id = ClassHttpUtil.AddClass(DialogClasses.Classes); // 添加班级
                                // 是否添加成功
                                if (id > 0)
                                {
                                    if (headTeacher != null) // 添加中间表
                                    {
                                        Teachers_Classes teachers_Classes = new Teachers_Classes() { ClassId = id, TeacherId = headTeacher.Id };
                                        var result_add = ClassHttpUtil.AddTeachers_Classes(teachers_Classes);
                                        if (result_add || headTeacher.IsHeadTeacher == 0)
                                        {
                                            headTeacher.IsHeadTeacher = 1; // 更改教师为班主任
                                            TeacherHttpUtil.UpdateTeacher(headTeacher);
                                        }
                                    }
                                    // 关闭窗体
                                    gradeInfoDialog.Close();
                                    // 刷新
                                    var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                                    RefreshClassesList(gradeList.items, gradeList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"班级添加成功！", "ClassesSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("班级添加失败！", "ClassesInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改班级
                            else if (DialogTitle == "修改班级")
                            {
                                Teachers headTeacher = null;
                                if (DialogHeadTeacher.Teacher.Name != DialogClasses.Teachers.Name) // 是否修改了教师
                                {
                                    if (!string.IsNullOrEmpty(DialogClasses.Teachers.Name)) // 查看教师是否存在
                                    {
                                        var teacher = TeacherHttpUtil.GetTeacherByName(DialogClasses.Teachers.Name);
                                        if (teacher == null)
                                        {
                                            HandyControl.Controls.Growl.Warning("教师名称不存在！", "ClassesInfoWarningMsg");
                                            return;
                                        }
                                        else
                                        {
                                            // 教师存在
                                            headTeacher = teacher;
                                        }
                                    }
                                }

                                var resultEdit = ClassHttpUtil.UpdateClass(DialogClasses.Classes);

                                if (resultEdit)
                                {
                                    if (headTeacher != null) // 删除并添加中间表
                                    {
                                        // 删除中间表
                                        ClassHttpUtil.DeleteTeachers_Classes(DialogHeadTeacher.Teacher.Id, DialogClasses.Classes.Id);

                                        Teachers_Classes teachers_Classes = new Teachers_Classes() { ClassId = DialogClasses.Classes.Id, TeacherId = headTeacher.Id };
                                        ClassHttpUtil.AddTeachers_Classes(teachers_Classes);
                                    }
                                    var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                                    RefreshClassesList(gradeList.items, gradeList.TotalCount);
                                    gradeInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"修改成功！", "ClassesSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("班级修改失败！", "ClassesInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "ClassesErrorMsg");
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
                        var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                        RefreshClassesList(gradeList.items, gradeList.TotalCount);
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
                        var gradeList = ClassHttpUtil.GetClasses(SearchClassesName, SearchGrade.Grade.Id.ToString(), SearchClassesType, CurrentPage, PerPageCount);
                        RefreshClassesList(gradeList.items, gradeList.TotalCount);
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


        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="allClassesList"></param>
        /// <param name="totalCount"></param>
        private void RefreshClassesList(List<Classes> allClassesList, int totalCount)
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

            ClassesList.Clear();

            //var allStudent = StudentHttpUtil.GetAllStudent();
            //var allClass = ClassHttpUtil.GetAllClass();
            //allClassesList.ForEach(g =>
            //{
            //    var classList = allClass.items.Where(c => c.ClassesId == g.Id);
            //    List<Students> studentList = new List<Students>();
            //    foreach (var item in classList)
            //    {
            //        studentList = allStudent.items.Where(s => s.ClassId == item.Id).ToList();
            //    }

            //    ClassesList.Add(new ClassDto() { Classes = g,ClassesPersonCount = studentList.Count });
            //});

            allClassesList.ForEach(g =>
            {
                ClassesList.Add(new ClassDto() { Classes = g, StudentTotalCount = 0 });
            });
        }

        #endregion



        

    }
}
