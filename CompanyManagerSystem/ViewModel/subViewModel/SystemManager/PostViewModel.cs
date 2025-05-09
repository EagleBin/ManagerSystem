using CompanyManagerSystem.View.subView.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Http.SystemManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel.subViewModel.SystemManager
{
    public class PostViewModel : ViewModelBase
    {

        public PostViewModel()
        {
            // 注册消息
            Messenger.Default.Register<List<PostDto>>(this, "SelectedPosts", (o) => { SelectedPosts = o; });

            PerPageCountList = new List<int> { 20, 50, 100, 200, 500 }; // 每页最大条数列表 初始化

            // 获取岗位列表
            var posts = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
            RefreshPostlist(posts.items, posts.TotalCount);

        }

        #region 属性

        #region 岗位属性

        private ObservableCollection<PostDto> _PostList = new ObservableCollection<PostDto>();
        /// <summary>
        /// 岗位列表
        /// </summary>
        public ObservableCollection<PostDto> PostList
        {
            get { return _PostList; }
            set
            {
                _PostList = value;
                RaisePropertyChanged();
            }
        }

        private PostDto _SelectedPost;
        /// <summary>
        /// 选择的岗位
        /// </summary>
        public PostDto SelectedPost
        {
            get { return _SelectedPost; }
            set
            {
                _SelectedPost = value;
                RaisePropertyChanged();
            }
        }

        private List<PostDto> _SelectedPosts = new List<PostDto>();
        /// <summary>
        /// 选择的岗位列表
        /// </summary>
        public List<PostDto> SelectedPosts
        {
            get { return _SelectedPosts; }
            set
            {
                _SelectedPosts = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region 搜索属性

        private string _SearchPostName;
        /// <summary>
        /// 要搜索的岗位的名称
        /// </summary>
        public string SearchPostName
        {
            get { return _SearchPostName; }
            set
            {
                _SearchPostName = value;
                RaisePropertyChanged();
            }
        }

        private string _SearchStatus;
        /// <summary>
        /// 要搜索的岗位的状态
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

        #endregion

        #region 弹框属性

        /// <summary>
        /// 岗位信息 窗体（用于添加和修改）
        /// </summary>
        private Dialog postInfoDialog;

        private PostDto _DialogPost;
        /// <summary>
        /// 弹窗中的职位
        /// </summary>
        public PostDto DialogPost
        {
            get { return _DialogPost; }
            set
            {
                _DialogPost = value;
                RaisePropertyChanged();
            }
        }

        private string _DialogTitle;
        /// <summary>
        /// 弹窗的标题
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

        #region 岗位命令

        private ICommand _DeletePostInfoCommand;
        /// <summary>
        /// 删除岗位
        /// </summary>
        public ICommand DeletePostInfoCommand
        {
            get
            {
                return _DeletePostInfoCommand ?? 
                    (_DeletePostInfoCommand = new RelayCommand<string>((str) =>
                {
                    try
                    {
                        // 当前选择的岗位不为空
                        if (SelectedPost != null)
                        {
                            // 只删除一个岗位
                            if (str == "DeleteOnlyOnePost")
                            {
                                var deletePost = SelectedPost;
                                var result = HandyControl.Controls.MessageBox.Show($"确定要删除岗位[{deletePost.Post.PostName}]吗?", "提示",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    // 删除
                                    PostHttpUtil.DeletePost(SelectedPost.Post.Id);
                                    //刷新
                                    var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshPostlist(postList.items, postList.TotalCount);

                                    HandyControl.Controls.Growl.Success($"岗位[{deletePost.Post.PostName}]删除成功！", "PostSuccessMsg");
                                }
                            }
                            // 同时删除多个岗位时
                            else if (str == "DeleteNotOnlyOnePost")
                            {
                                var deletePost = SelectedPost;
                                var result = HandyControl.Controls.MessageBox.Show(SelectedPosts.Count == 1 ? $"是否删除岗位[{deletePost.Post.PostName}]吗" : $"是否删除{SelectedPosts.Count}个岗位?",
                                    "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    // 遍历删除
                                    foreach (var item in SelectedPosts)
                                    {
                                        PostHttpUtil.DeletePost(item.Post.Id);
                                    }
                                    // 清空和刷新列表
                                    PostList.Clear();
                                    var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshPostlist(postList.items, postList.TotalCount);

                                    HandyControl.Controls.Growl.Success("岗位删除成功！", "PostSuccessMsg");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        HandyControl.Controls.Growl.Success($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                        return;
                    }

                }));
            }

        }

        private ICommand _AddPostInfoCommand;
        /// <summary>
        /// 添加岗位
        /// </summary>
        public ICommand AddPostInfoCommand
        {
            get
            {
                return _AddPostInfoCommand ??
                    (_AddPostInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            DialogTitle = "添加岗位";
                            DialogPost = new PostDto();
                            // 显示PostInfoDialog弹窗
                            postInfoDialog = HandyControl.Controls.Dialog.Show<PostInfoDialog>();
                        }
                        catch (Exception ex)
                        {

                            HandyControl.Controls.Growl.Warning($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                            return;
                        }
                    }));
            }

        }

        private ICommand _EditPostInfoCommand;
        /// <summary>
        /// 编辑岗位信息命令
        /// </summary>
        public ICommand EditPostInfoCommand
        {
            get
            {
                return _EditPostInfoCommand ??
                    (_EditPostInfoCommand = new RelayCommand(() =>
                    {
                        try
                        {
                            if (SelectedPost != null)
                            {
                                DialogTitle = "修改岗位";
                                DialogPost = SelectedPost; // 将选中的岗位传入弹窗
                                // 显示PostInfoDialog弹窗
                                postInfoDialog = HandyControl.Controls.Dialog.Show<PostInfoDialog>();
                            }
                            else
                            {
                                HandyControl.Controls.Growl.Warning("出现异常，请刷新。", "PostWarningMsg");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {

                            HandyControl.Controls.Growl.Warning($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                            return;
                        }
                    }));
            }

        }

        private ICommand _SubmitPostInfoCommand;
        /// <summary>
        /// 确认（添加/修改）命令
        /// </summary>
        public ICommand SubmitPostInfoCommand
        {
            get
            {
                return _SubmitPostInfoCommand ??
                    (_SubmitPostInfoCommand = new RelayCommand(() =>
                    {
                        if (DialogPost == null || DialogPost.Post == null)
                        {
                            return;
                        }
                        // 空名字检验
                        if (string.IsNullOrEmpty(DialogPost.Post.PostName))
                        {
                            HandyControl.Controls.Growl.Warning("岗位名称不能为空！", "PostInfoWarningMsg");
                            return;
                        }

                        // “添加”窗体
                        if (DialogTitle == "添加岗位")
                        {
                            try
                            {
                                // 是否添加成功
                                if (PostHttpUtil.AddPost(DialogPost.Post))
                                {
                                    // 刷新岗位列表
                                    var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshPostlist(postList.items, postList.TotalCount);
                                    // 关闭“添加”窗体
                                    postInfoDialog.Close();
                                    HandyControl.Controls.Growl.Success($"岗位添加成功！", "PostSuccessMsg");
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("添加岗位失败！", "PostInfoWarningMsg");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                HandyControl.Controls.Growl.Warning($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                                return;
                            }
                        }
                        // “修改”窗体
                        if (DialogTitle == "修改岗位")
                        {
                            try
                            {
                                // 是否修改成功
                                if (PostHttpUtil.UpdatePost(DialogPost.Post))
                                {
                                    var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                                    RefreshPostlist(postList.items, postList.TotalCount);
                                    // 关闭“修改”窗体
                                    postInfoDialog.Close();
                                    HandyControl.Controls.Growl.Success($"岗位修改成功！", "PostSuccessMsg");
                                    return;
                                }
                                else
                                {
                                    HandyControl.Controls.Growl.Warning("修改岗位失败！", "PostInfoWarningMsg");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                HandyControl.Controls.Growl.Error($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                                return;
                            }
                        }
                    }));
            }

        }



        #endregion

        #region 搜索命令

        private ICommand _ConditionalSearchPostCommand;
        /// <summary>
        /// 条件查询命令
        /// </summary>
        public ICommand ConditionalSearchPostCommand
        {
            get
            {
                return _ConditionalSearchPostCommand ?? (_ConditionalSearchPostCommand = new RelayCommand(() =>
                {
                    try
                    {
                        CurrentPage = 1;
                        var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshPostlist(postList.items, postList.TotalCount);
                    }
                    catch (Exception ex)
                    {
                        HandyControl.Controls.Growl.Success($"出现异常，请刷新。详情：{ex.Message}。", "PostErrorMsg");
                        return;
                    }
                }));
            }
        }


        private ICommand _ResetConditionalSearchPostCommand;
        /// <summary>
        /// 清空搜索框条件
        /// </summary>
        public ICommand ResetConditionalSearchPostCommand
        {
            get
            {
                return _ResetConditionalSearchPostCommand ?? (_ResetConditionalSearchPostCommand = new RelayCommand(() =>
                {
                    CurrentPage = 1;
                    SearchPostName = null;
                    SearchStatus = null;
                    StartDate = null;
                    EndDate = null;
                    var postList = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                    RefreshPostlist(postList.items, postList.TotalCount);

                }));
            }
        }


        #endregion

        #region 弹框命令

        private ICommand _PostInfoDialogLoadedCommand;
        /// <summary>
        /// 弹框加载命令
        /// </summary>
        public ICommand PostInfoDialogLoadedCommand
        {
            get
            {
                return _PostInfoDialogLoadedCommand ??
                    (_PostInfoDialogLoadedCommand = new RelayCommand(() =>
                    {

                    }));
            }

        }

        private ICommand _PostInfoDialogUnloadedCommand;
        /// <summary>
        /// 关闭弹框时加载
        /// </summary>
        public ICommand PostInfoDialogUnloadedCommand
        {
            get
            {
                return _PostInfoDialogUnloadedCommand ??
                    (_PostInfoDialogUnloadedCommand = new RelayCommand(() =>
                    {
                        DialogTitle = "";
                        DialogPost = new PostDto();
                    }));
            }

        }


        #endregion

        #region 分页命令

        private ICommand _PerPageCountChangedCommand;
        /// <summary>
        /// 每页容量变化时，所执行
        /// </summary>
        public ICommand PerPageCountChangedCommand
        {
            get
            {
                return _PerPageCountChangedCommand ??
                    (_PerPageCountChangedCommand = new RelayCommand(() =>
                    {
                        CurrentPage = 1; // 跳转到第一页
                        var posts = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshPostlist(posts.items, posts.TotalCount);
                    }));
            }

        }

        private ICommand _PageUpdatedCommand;
        /// <summary>
        /// 页数跳转
        /// </summary>
        public ICommand PageUpdatedCommand
        {
            get
            {
                return _PageUpdatedCommand ??
                    (_PageUpdatedCommand = new RelayCommand(() =>
                    {
                        //例如 CurrentPage 为5时，获取第五页的数据。PerPageCount为每页容量
                        var posts = PostHttpUtil.GetPosts(SearchPostName, SearchStatus, StartDate, EndDate, CurrentPage, PerPageCount);
                        RefreshPostlist(posts.items, posts.TotalCount);
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
                return _ChangeSearchPanelVisCommand ??
                    (_ChangeSearchPanelVisCommand = new RelayCommand(() =>
                    {
                        SearchPanelVis = (SearchPanelVis == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible);
                    }));
            }

        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 刷新岗位列表同时修改分页数据
        /// </summary>
        /// <param name="allPostList">岗位列表</param>
        /// <param name="totalCount">当前岗位列表的总数</param>
        private void RefreshPostlist(List<Post> allPostList, int totalCount)
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
            PostList.Clear(); // 清空岗位列表
            // 重新获取岗位列表
            foreach (var item in allPostList)
            {
                PostList.Add(new PostDto() { Post = item });
            }
        }

        #endregion
    }
}
