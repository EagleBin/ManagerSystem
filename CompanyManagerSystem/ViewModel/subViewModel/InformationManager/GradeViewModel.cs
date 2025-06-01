using CompanyManagerSystem.View.subView.InformationManager.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.InformationManager;
using ManagerSystem.Utils.Http.InformationManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.InformationManager
{
    public class GradeViewModel : ViewModelBase
    {

        public GradeViewModel()
        {
            // 获取多行数据
            Messenger.Default.Register<List<GradeDto>>(this, "SelectedGrades", gs => SelectedGrades = gs);
            Messenger.Default.Register<List<Grades>>(this, "GradeChanged", gc => GradeChanged(gc)); // 年级更新的同时，更新搜索列表
            // 刷新列表
            var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
            RefreshGradeList(gradeList.items, gradeList.TotalCount);

            // 清空搜索栏年级列表
            SearchGradeList.Clear();
            foreach (var item in gradeList.items)
            {
                SearchGradeList.Add(new GradeDto() { Grade = item });
            }

            // 初始化 弹窗年级级别
            DialogGradeLevelNameList = new List<int> { 1, 2, 3 };
        }


        #region 属性

        #region 年级属性

        private ObservableCollection<GradeDto> _GradeList = new ObservableCollection<GradeDto>();
        /// <summary>
        /// 年级列表
        /// </summary>
        public ObservableCollection<GradeDto> GradeList
        {
            get { return _GradeList; }
            set
            {
                _GradeList = value;
                RaisePropertyChanged();
            }
        }

        private GradeDto _SelectedGrade;
        /// <summary>
        /// 选择的年级
        /// </summary>
        public GradeDto SelectedGrade
        {
            get { return _SelectedGrade; }
            set
            {
                _SelectedGrade = value;
                RaisePropertyChanged();
            }
        }

        private List<GradeDto> _SelectedGrades;
        /// <summary>
        /// 选择的年级年级
        /// </summary>
        public List<GradeDto> SelectedGrades
        {
            get { return _SelectedGrades; }
            set
            {
                _SelectedGrades = value;
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

        private GradeDto _SearchdGrade;
        /// <summary>
        /// 搜索的年级
        /// </summary>
        public GradeDto SearchdGrade
        {
            get { return _SearchdGrade; }
            set
            {
                _SearchdGrade = value;
                RaisePropertyChanged();
            }
        }


        private string _SearchName;
        /// <summary>
        /// 搜索的年级的名称
        /// </summary>
        public string SearchName
        {
            get { return _SearchName; }
            set
            {
                _SearchName = value;
                RaisePropertyChanged();
            }
        }

        private int _SearchGradeLevel;
        /// <summary>
        /// 搜索的级别
        /// </summary>
        public int SearchGradeLevel
        {
            get { return _SearchGradeLevel; }
            set
            {
                _SearchGradeLevel = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 弹窗属性

        /// <summary>
        /// 弹窗（用于增加/修改年级）
        /// </summary>
        private Dialog gradeInfoDialog;

        private GradeDto _DialogGrade = new GradeDto();
        /// <summary>
        /// 弹窗中的 年级
        /// </summary>
        public GradeDto DialogGrade
        {
            get { return _DialogGrade; }
            set
            {
                _DialogGrade = value;
                RaisePropertyChanged();
            }
        }

        private int _DialogGradeLevelName;
        /// <summary>
        /// 弹窗中的级别
        /// </summary>
        public int DialogGradeLevelName
        {
            get { return _DialogGradeLevelName; }
            set
            {
                _DialogGradeLevelName = value;
                RaisePropertyChanged();
            }
        }

        private List<int> _DialogGradeLevelNameList = new List<int>();  
        /// <summary>
        /// 弹窗中的级别列表
        /// </summary>
        public List<int> DialogGradeLevelNameList
        {
            get { return _DialogGradeLevelNameList; }
            set
            {
                _DialogGradeLevelNameList = value;
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

        #region 年级命令

        private ICommand _DeleteGradeInfoCommand;
        /// <summary>
        /// 删除年级
        /// </summary>
        public ICommand DeleteGradeInfoCommand
        {
            get
            {
                return _DeleteGradeInfoCommand ??
                    (_DeleteGradeInfoCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            // 信息校验
                            if (SelectedGrade == null || SelectedGrade.Grade == null || string.IsNullOrEmpty(para))
                            {
                                HandyControl.Controls.Growl.Warning("请选择要删除的用户！", "GradeWarningMsg");
                                return;
                            }
                            // 删除单个年级
                            if (para == "DeleteOnlyOneGrade")
                            {
                                var deleteGrade = SelectedGrade;
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除名为[{deleteGrade.Grade.Name}]的年级?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var resultDelete = GradeHttpUtil.DeleteGrade(deleteGrade.Grade.Id);
                                    if (resultDelete)
                                    {
                                        HandyControl.Controls.Growl.Success($"成功删除名为[{deleteGrade.Grade.Name}]的年级！", "GradeSuccessMsg");
                                        // 刷新列表
                                        var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                                        RefreshGradeList(gradeList.items, gradeList.TotalCount);
                                        Messenger.Default.Send(gradeList.items, "GradeChanged");
                                        return;
                                    }
                                    else
                                    {
                                        HandyControl.Controls.Growl.Success("删除失败，请刷新列表后重试！", "GradeWarningMsg");
                                        return;
                                    }
                                }
                            }
                            // 删除多个年级
                            else if (para == "DeleteNotOnlyOneGrade")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show(SelectedGrades.Count == 1 ? $"是否删除名为[{SelectedGrade.Grade.Name}]的年级?" : $"是否删除{SelectedGrades.Count}个年级",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var gradeDto in SelectedGrades)
                                    {
                                        var resultDelete = GradeHttpUtil.DeleteGrade(gradeDto.Grade.Id);
                                        // 统计数量
                                        if (resultDelete == false)
                                        {
                                            HandyControl.Controls.Growl.Success($"删除{gradeDto.Grade.Name}失败，请刷新列表后重试！", "GradeWarningMsg");
                                            errorCount++;
                                        }
                                        else
                                        {
                                            successCount++;
                                        }
                                    }
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个年级,失败删除{errorCount}个年级");
                                    // 刷新列表
                                    var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                                    RefreshGradeList(gradeList.items, gradeList.TotalCount);
                                    Messenger.Default.Send(gradeList.items, "GradeChanged");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"删除失败，发生异常错误，详情:{ex.Message}", "GradeErrorMsg");
                            return;
                        }
                    }));
            }

        }

        #endregion


        #region 搜索命令

        private ICommand _SearchGradeCommand;
        /// <summary>
        /// 条件搜索
        /// </summary>
        public ICommand SearchGradeCommand
        {
            get
            {
                return _SearchGradeCommand ??
                    (_SearchGradeCommand = new RelayCommand(() =>
                    {

                        CurrentPage = 1; // 设置当前页面为第一页
                        // 根据 搜索条件 搜索，刷新列表
                        var gradeList = GradeHttpUtil.GetGrades(SearchdGrade.Grade.Name, CurrentPage, PerPageCount);
                        RefreshGradeList(gradeList.items, gradeList.TotalCount);
                        return;
                    }));
            }
        }

        private ICommand _ResetConditionalSearchGradeCommand;
        /// <summary>
        /// 重置搜索条件，并刷新数据
        /// </summary>
        public ICommand ResetConditionalSearchGradeCommand
        {
            get
            {
                return _ResetConditionalSearchGradeCommand ??
                    (_ResetConditionalSearchGradeCommand = new RelayCommand(() =>
                    {
                        SearchName = null;
                        SearchdGrade = new GradeDto();
                        CurrentPage = 1;
                        // 刷新列表
                        var gradeList = GradeHttpUtil.GetGrades(SearchdGrade.Grade.Name, CurrentPage, PerPageCount);
                        RefreshGradeList(gradeList.items, gradeList.TotalCount);
                        return;
                    }));
            }
        }


        #endregion

        #region 弹窗命令（打开弹窗 添加修改）

        private ICommand _GradeInfoDialogLoadedCommand;
        /// <summary>
        /// 弹窗加载
        /// </summary>
        public ICommand GradeInfoDialogLoadedCommand
        {
            get
            {
                return _GradeInfoDialogLoadedCommand ??
                    (_GradeInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }

        private ICommand _GradeInfoDialogUnloadedCommand;
        /// <summary>
        /// 弹窗关闭命令
        /// </summary>
        public ICommand GradeInfoDialogUnloadedCommand
        {
            get
            {
                return _GradeInfoDialogUnloadedCommand ??
                    (_GradeInfoDialogLoadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = ""; // 清空标题
                        
                        DialogGrade = new GradeDto(); // 重新 赋值 年级实例
                    }));
            }
        }

        private ICommand _AddGradeInfoCommand;
        /// <summary>
        /// 打开 添加年级 窗体
        /// </summary>
        public ICommand AddGradeInfoCommand
        {
            get
            {
                return _AddGradeInfoCommand ??
                    (_AddGradeInfoCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "添加年级";
                        DialogGrade = new GradeDto() { Grade = new Grades() };
                        // 打开窗体
                        gradeInfoDialog = HandyControl.Controls.Dialog.Show<GradeInfoDialog>();
                    }));
            }
        }

        private ICommand _EditGradeInfoCommand;
        /// <summary>
        /// 打开 编辑年级 窗体
        /// </summary>
        public ICommand EditGradeInfoCommand
        {
            get
            {
                return _EditGradeInfoCommand ??
                    (_EditGradeInfoCommand = new RelayCommand(() =>
                    {
                        if (SelectedGrade == null)
                        {
                            HandyControl.Controls.Growl.Warning("请选择要修改的年级！", "GradeWarningMsg");
                            return;
                        }
                        DialogTitle = "修改年级";
                        // 使用直接赋值，会指向同一个对象实例
                        // 使用使用Clone()创建副本，形成两个独立的对象，修改对话框中的数据不会影响原始数据。
                        DialogGrade.Grade = (Grades)SelectedGrade.Grade.Clone();
                        DialogGradeLevelName = DialogGrade.Grade.Level;
                        // 打开窗体
                        gradeInfoDialog = HandyControl.Controls.Dialog.Show<GradeInfoDialog>();
                    }));
            }
        }

        private ICommand _SubmitGradeInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitGradeInfoCommand
        {
            get
            {
                return _SubmitGradeInfoCommand ??
                    (_SubmitGradeInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (DialogGrade == null || DialogGrade.Grade == null)
                            {
                                return;
                            }
                            // 年级名称是否为空
                            if (string.IsNullOrEmpty(DialogGrade.Grade.Name))
                            {
                                HandyControl.Controls.Growl.Warning("年级名称不能为空！", "GradeInfoWarningMsg");
                                return;
                            }
                            // 添加年级
                            if (DialogTitle == "添加年级")
                            {
                                if (GradeHttpUtil.ExistName(DialogGrade.Grade.Name))
                                {
                                    HandyControl.Controls.Growl.Warning("年级名称已经存在！", "GradeInfoWarningMsg");
                                    return;
                                }
                                DialogGrade.Grade.Level = DialogGradeLevelName; // 获取级别
                                DialogGrade.Grade.insertTime = DateTime.Now; // 获取时间
                                var id = GradeHttpUtil.AddGrade(DialogGrade.Grade); // 添加年级
                                // 是否添加成功
                                if (id > 0)
                                {
                                    // 关闭窗体
                                    gradeInfoDialog.Close();
                                    // 刷新
                                    var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                                    RefreshGradeList(gradeList.items, gradeList.TotalCount);
                                    HandyControl.Controls.Growl.Success($"年级添加成功！", "GradeSuccessMsg");

                                    // 向 信息中心 发送 信息 ，说明改变年级发生改变
                                    Messenger.Default.Send(gradeList.items, "GradeChanged"); 

                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("年级添加失败！", "GradeInfoWarningMsg");
                                    return;
                                }
                            }
                            // 修改年级
                            else if (DialogTitle == "修改年级")
                            {
                                if (GradeHttpUtil.ExistName(DialogGrade.Grade.Name))
                                {
                                    HandyControl.Controls.Growl.Warning("年级名称已经存在！", "GradeInfoWarningMsg");
                                    return;
                                }
                                DialogGrade.Grade.Level = DialogGradeLevelName; // 获取级别
                                var resultEdit = GradeHttpUtil.UpdateGrade(DialogGrade.Grade);

                                if (resultEdit)
                                {
                                    var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                                    RefreshGradeList(gradeList.items, gradeList.TotalCount);
                                    gradeInfoDialog.Close();

                                    HandyControl.Controls.Growl.Success($"修改成功！", "GradeSuccessMsg");

                                    // 向 信息中心 发送 信息 ，说明改变年级发生改变
                                    Messenger.Default.Send(gradeList.items, "GradeChanged");

                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("年级修改失败！", "GradeInfoWarningMsg");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Warning($"发生异常，请刷新列表后，重新尝试。详情：{ex.Message}！", "GradeErrorMsg");
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
                        var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                        RefreshGradeList(gradeList.items, gradeList.TotalCount);
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
                        var gradeList = GradeHttpUtil.GetGrades(SearchName, CurrentPage, PerPageCount);
                        RefreshGradeList(gradeList.items, gradeList.TotalCount);
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
        /// <param name="allGradeList"></param>
        /// <param name="totalCount"></param>
        private void RefreshGradeList(List<Grades> allGradeList, int totalCount)
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

            GradeList.Clear();

            // 获取学生总数
            
            foreach (var grade in allGradeList)
            {
                int studentCount = 0;
                foreach (var classes in ClassHttpUtil.GetClassByGrade(grade.Id).items)
                {
                    studentCount += StudentHttpUtil.GetStudentByClass(classes.Id).TotalCount; // 获取学生总数
                }
                GradeList.Add(new GradeDto() { Grade = grade, GradePersonCount = studentCount }); // 添加到列表中
            }
        }

        /// <summary>
        /// 年级改变时
        /// </summary>
        /// <param name="gc"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private void GradeChanged(List<Grades> gc)
        {
            foreach (var item in gc)
            {
                SearchGradeList.Add(new GradeDto() { Grade =  item });
            }
        }

        #endregion
    }
}
