using CompanyManagerSystem.View.subView.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
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
    public class NoticeViewModel : ViewModelBase
    {

        public NoticeViewModel()
        {
            Messenger.Default.Register<List<NoticeDto>>(this, "SelectedNotices", list => SelectedNotices = list);
            PerPageCountList = new List<int>() { 20, 50, 100, 200, 500 };

            var noticeList = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
            RefreshNoticeList(noticeList.items, noticeList.TotalCount);
            var op = NoticeList;
        }

        #region 属性

        #region 公告属性

        private ObservableCollection<NoticeDto> _NoticeList = new ObservableCollection<NoticeDto>();
        /// <summary>
        /// 公告列表
        /// </summary>
        public ObservableCollection<NoticeDto> NoticeList
        {
            get { return _NoticeList; }
            set
            {
                _NoticeList = value;
                RaisePropertyChanged();
            }
        }

        private NoticeDto _SelectedNotice;
        /// <summary>
        /// 表格选中的公告
        /// </summary>
        public NoticeDto SelectedNotice
        {
            get { return _SelectedNotice; }
            set
            {
                _SelectedNotice = value;
                RaisePropertyChanged();
            }
        }

        private List<NoticeDto> _SelectedNotices = new List<NoticeDto>();
        /// <summary>
        /// 表格中选中的多个公告
        /// </summary>
        public List<NoticeDto> SelectedNotices
        {
            get { return _SelectedNotices; }
            set
            {
                _SelectedNotices = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 搜索属性

        private string _SearchTitle;
        /// <summary>
        /// 标题搜索
        /// </summary>
        public string SearchTitle
        {
            get { return _SearchTitle; }
            set
            {
                _SearchTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStatus;
        /// <summary>
        /// 搜索状态
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

        private string _StartDate;
        /// <summary>
        /// 起始时间
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
        /// 终止时间
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

        #region 弹窗属性

        /// <summary>
        /// 公告信息弹窗（新增/修改）
        /// </summary>
        private Dialog noticeInfoDialog;

        private NoticeDto _DialogNotice;
        /// <summary>
        /// 弹窗的公告参数
        /// </summary>
        public NoticeDto DialogNotice
        {
            get { return _DialogNotice; }
            set
            {
                _DialogNotice = value;
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

        #region 其他属性

        private Visibility _SearchPanelVis;

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

        #region 公告命令

        private ICommand _DeleteNoticeCommand;
        /// <summary>
        /// 删除公告
        /// </summary>
        public ICommand DeleteNoticeCommand
        {
            get
            {
                return _DeleteNoticeCommand ??
                    (_DeleteNoticeCommand = new RelayCommand<string>((para) =>
                    {
                        try
                        {
                            if (para == "DeleteOnlyOneNotice")
                            {
                                var resultDialog = HandyControl.Controls.MessageBox.Show($"是否删除【{SelectedNotice.Notice.NoticeTitle}】公告？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (resultDialog == MessageBoxResult.Yes)
                                {
                                    var result = NoticeHttpUtil.DeleteNotice(SelectedNotice.Notice.Id);
                                    if (result)
                                    {
                                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                        RefreshNoticeList(list.items, list.TotalCount);

                                        HandyControl.Controls.Growl.Success("删除公告成功", "NoticeSuccessMsg");
                                        return;
                                    }
                                }
                            }
                            else if (para == "NotDeleteOnlyOneNotice")
                            {
                                var reusltDialog = HandyControl.Controls.MessageBox.Show(SelectedNotices.Count == 1 ? $"是否删除【{SelectedNotice.Notice.NoticeTitle}】公告?" : $"是否删除【{SelectedNotices.Count}】个公告？",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (reusltDialog == MessageBoxResult.Yes)
                                {

                                    int errorCount = 0; // 失败计数
                                    int successCount = 0; // 成功计数
                                    // 遍历删除
                                    foreach (var item in SelectedNotices)
                                    {
                                        if (NoticeHttpUtil.DeleteNotice(item.Notice.Id))
                                        {
                                            successCount++;
                                        }
                                        else
                                        {
                                            errorCount++;
                                        }
                                    }
                                    // 刷新数据
                                    var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshNoticeList(list.items, list.TotalCount);
                                    HandyControl.Controls.Growl.Success($"成功删除{successCount}个公告，失败{errorCount}个");
                                    return;
                                }
                            }
                            else
                            {
                                HandyControl.Controls.Growl.Error("出现异常，请刷新后重试", "NoticeErrorMsg");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"出现异常，详情：{ex.Message}", "NoticeErrorMsg");
                            return;
                        }
                    }));
            }
        }

        private ICommand _AddNoticeCommand;
        /// <summary>
        /// 添加公告
        /// </summary>
        public ICommand AddNoticeCommand
        {
            get
            {
                return _AddNoticeCommand ??
                    (_AddNoticeCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            DialogTitle = "添加公告";
                            DialogNotice = new NoticeDto();
                            noticeInfoDialog = HandyControl.Controls.Dialog.Show<NoticeInfoDialog>();
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error("打开窗体异常，请稍后", "NoticeErrorMsg");
                            return;
                        }
                    }));
            }
        }

        private ICommand _UpdateNoticeCommand;
        /// <summary>
        /// 修改公告
        /// </summary>
        public ICommand UpdateNoticeCommand
        {
            get
            {
                return _UpdateNoticeCommand ??
                    (_UpdateNoticeCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (SelectedNotices.Count > 1)
                            {
                                HandyControl.Controls.Growl.Warning("请选择一行进行修改", "NoticeInfoWarningMsg");
                                return;
                            }

                            DialogTitle = "修改公告";
                            DialogNotice = SelectedNotice;
                            DialogNotice.Notice = (Notice)SelectedNotice.Notice.Clone();
                            // 打开修改窗体
                            noticeInfoDialog = HandyControl.Controls.Dialog.Show<NoticeInfoDialog>();
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error("打开窗体异常，请稍后", "NoticeErrorMsg");
                            return;
                        }
                    }));
            }
        }

        private ICommand _SubmitNoticeInfoCommand;
        /// <summary>
        /// 确认 添加/修改
        /// </summary>
        public ICommand SubmitNoticeInfoCommand
        {
            get
            {
                return _SubmitNoticeInfoCommand ??
                    (_SubmitNoticeInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(DialogNotice.Notice.NoticeTitle))
                            {
                                HandyControl.Controls.Growl.Warning("请输入公告标题", "NoticeInfoWarningMsg");
                                return;
                            }
                            // 添加公告
                            if (DialogTitle == "添加公告")
                            {
                                var result = NoticeHttpUtil.AddNotice(DialogNotice.Notice);
                                if (result)
                                {
                                    noticeInfoDialog.Close(); // 关闭 添加窗体
                                    //刷新列表
                                    var list = NoticeHttpUtil.GetNotices(null, null, null, null, CurrentPage, PerPageCount);
                                    RefreshNoticeList(list.items, list.TotalCount);
                                    HandyControl.Controls.Growl.Success("添加成功", "NoticeSuccessMsg");
                                    return;
                                }
                            }
                            // 修改公告
                            else if (DialogTitle == "修改公告")
                            {
                                var result = NoticeHttpUtil.UpdateNotice(DialogNotice.Notice);
                                if (result)
                                {
                                    noticeInfoDialog.Close(); // 关闭 修改窗体
                                    //刷新列表
                                    var list = NoticeHttpUtil.GetNotices(null, null, null, null, CurrentPage, PerPageCount);
                                    RefreshNoticeList(list.items, list.TotalCount);
                                    HandyControl.Controls.Growl.Success("修改成功", "NoticeSuccessMsg");
                                    return;
                                }
                            }
                            else
                            {
                                HandyControl.Controls.Growl.Warning("异常，请刷新后重试", "NoticeInfoWarningMsg");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            HandyControl.Controls.Growl.Error($"发生异常，请稍候，详情：{ex.Message}", "NoticeInfoErroMsg");
                            return;
                        }
                    }));
            }
        }


        #endregion

        #region 搜索命令

        private ICommand _SearchNoticeCommand;
        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchNoticeCommand
        {
            get
            {
                return _SearchNoticeCommand ??
                    (_SearchNoticeCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1; // 重置当前页码
                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshNoticeList(list.items, list.TotalCount); // 刷新列表
                    }));
            }
        }

        private ICommand _SearchResetCommand;
        /// <summary>
        /// 重置搜索条件，刷新列表
        /// </summary>
        public ICommand SearchResetCommand
        {
            get
            {
                return _SearchResetCommand ??
                    (_SearchResetCommand = new RelayCommand(() =>
                    {
                        // 清空搜索条件
                        SearchTitle = null;
                        SearchStatus = null;
                        StartDate = null;
                        EndDate = null;
                        CurrentPage = 1;
                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshNoticeList(list.items, list.TotalCount);
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
                        CurrentPage = 1; // 重置页码
                        // 刷新列表
                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshNoticeList(list.items, list.TotalCount);
                    }));
            }
        }

        private ICommand _PageUpdatedCommand;
        /// <summary>
        /// 页码改变（翻页）
        /// </summary>
        public ICommand PageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        // 刷新列表
                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshNoticeList(list.items, list.TotalCount);
                    }));
            }
        }


        #endregion

        #region 其他命令

        private ICommand _SearchPanelVisCommand;
        /// <summary>
        /// 隐藏搜索栏
        /// </summary>
        public ICommand SearchPanelVisCommand
        {
            get
            {
                return _SearchPanelVisCommand ??
                    (_SearchPanelVisCommand = new RelayCommand(() =>
                    {
                        // Visibility.Hidden 隐藏了但仍然占据位置空间
                        // Visibility.Collapsed 隐藏而且不占据位置空间，其他元素可以自动补充到该空间
                        SearchPanelVis = SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    }));
            }
        }

        private ICommand _RefreshCommand;
        /// <summary>
        /// 刷新表格
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                return _RefreshCommand ??
                    (_RefreshCommand = new RelayCommand(() =>
                    {
                        // 刷新列表
                        var list = NoticeHttpUtil.GetNotices(SearchTitle, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshNoticeList(list.items, list.TotalCount);
                    }));
            }
        }

        private ICommand _NoticeInfoDialogUnloadedCommand;
        /// <summary>
        /// 关闭弹窗
        /// </summary>
        public ICommand NoticeInfoDialogUnloadedCommand
        {
            get {
                return _NoticeInfoDialogUnloadedCommand ??
                    (_NoticeInfoDialogUnloadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "";
                        DialogNotice = new NoticeDto();

                    }));
            }
        }


        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新表格，获取总页数
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        private void RefreshNoticeList(List<Notice> allNoticeList, int totalCount)
        {
           TotalCount = totalCount; // 获取总条数
            // 获取页码
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

            NoticeList.Clear(); // 清空列表
            foreach (var item in allNoticeList)
            {
                NoticeList.Add(new NoticeDto() { Notice =  item });
            }

        }


        #endregion


    }
}
