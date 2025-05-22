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
using GalaSoft.MvvmLight;
using HandyControl.Controls;
using CompanyManagerSystem.View.subView.InformationManager.Dialog;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public class TeacherViewModel : ViewModelBase
    {
        public TeacherViewModel()
        {
            Messenger.Default.Register<List<TeacherDto>>(this, "SeletedTeacherList", cl => SeletedTeacherList = cl);
            SearchTeacherTypeList = new List<string>() {"全部", "班主任", "普通教师" }; // 初始化教师类型
            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 }; // 初始化每页容量

            // 初始化 窗体教师类型
            DialogTeacherTypeList = new List<string>() { "班主任", "普通教师" }; // 教师类型
            DialogSubjectList = new List<string>() { "语文", "数学", "英语" };

            foreach (var item in TeacherHttpUtil.GetAllTeacher().items)
            {
                TeacherList.Add(new TeacherDto() { Teacher =  item });
            }
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

        private int _SearchTeacherType;
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

        private List<string> _DialogSubjectList = new List<string>();
        /// <summary>
        /// 窗体 课程列表
        /// </summary>
        public List<string> DialogSubjectList
        {
            get { return _DialogSubjectList; }
            set
            {
                _DialogSubjectList = value;
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
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{deleteTeacher.Teacher.Name}]的教师?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = ClassHttpUtil.DeleteClass(deleteTeacher.Teacher.Id);
                                    if (resultDelete)
                                    {
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{deleteTeacher.Teacher.Name}]的教师！", "TeacherSuccessMsg");
                                        // 刷新列表
                                        var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                        RefreshTeacherList(teacherList.items, teacherList.TotalCount);
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
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个教师,失败删除{errorCount}个教师");
                                    // 刷新列表
                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
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
                        // 使用直接赋值，会指向同一个对象实例
                        // 使用使用Clone()创建副本，形成两个独立的对象，修改对话框中的数据不会影响原始数据。
                        DialogTeacher = new TeacherDto() { Teacher = (Teachers)SelectedTeacher.Teacher.Clone() };
                        // 打开窗体
                        teacherInfoDialog = HandyControl.Controls.Dialog.Show<TeacherInfoDialog>();
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
                            // 教师名称是否为空
                            if (string.IsNullOrEmpty(DialogTeacher.Teacher.Name))
                            {
                                HandyControl.Controls.Growl.Warning("教师名称不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            else if (string.IsNullOrEmpty(DialogTeacher.Teacher.IsHeadTeacher.ToString()))
                            {
                                HandyControl.Controls.Growl.Warning("教师类型不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            else if (string.IsNullOrEmpty(DialogTeacher.Teacher.Age.ToString()))
                            {
                                HandyControl.Controls.Growl.Warning("年龄不能为空！", "TeacherInfoWarningMsg");
                                return;
                            }
                            // 添加教师
                            if (DialogTitle == "添加教师")
                            {
                                if (TeacherHttpUtil.GetTeacherByName(DialogTeacher.Teacher.Name) != null) // 查看教师是否存在
                                {
                                    HandyControl.Controls.Growl.Warning("教师名称已经存在！", "TeacherInfoWarningMsg");
                                    return;
                                }
                                else if (!string.IsNullOrEmpty(DialogTeacher.Teacher.Name)) // 查看教师是否存在
                                {

                                }

                                DialogTeacher.Teacher.insertTime = DateTime.Now; // 获取时间
                                var id = TeacherHttpUtil.AddTeacher(DialogTeacher.Teacher); // 添加教师
                                // 是否添加成功
                                if (id > 0)
                                {
                                    // 关闭窗体
                                    teacherInfoDialog.Close();
                                    // 刷新
                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"教师添加成功！", "TeacherSuccessMsg");
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
                                var resultEdit = TeacherHttpUtil.UpdateTeacher(DialogTeacher.Teacher);

                                if (resultEdit)
                                {

                                    var teacherList = TeacherHttpUtil.GetTeachers(SearchTeacherName, SearchTeacherAge, SearchTeacherPhone, SearchTeacherSubject, SearchTeacherType, CurrentPage, PerPageCount);
                                    RefreshTeacherList(teacherList.items, teacherList.TotalCount);
                                    teacherInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"修改成功！", "TeacherSuccessMsg");
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

            //var allStudent = StudentHttpUtil.GetAllStudent();
            //var allClass = ClassHttpUtil.GetAllClass();
            //allTeacherList.ForEach(g =>
            //{
            //    var classList = allClass.items.Where(c => c.TeacherId == g.Id);
            //    List<Students> studentList = new List<Students>();
            //    foreach (var item in classList)
            //    {
            //        studentList = allStudent.items.Where(s => s.ClassId == item.Id).ToList();
            //    }

            //    TeacherList.Add(new TeacherDto() { Teacher = g,TeacherPersonCount = studentList.Count });
            //});

            allTeacherList.ForEach(g =>
            {
                TeacherList.Add(new TeacherDto() { Teacher = g });
            });
        }

        #endregion
    }
}
