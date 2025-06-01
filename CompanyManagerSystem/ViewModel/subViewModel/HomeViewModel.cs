using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts.Wpf;
using LiveCharts;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Utils.Http;
using ManagerSystem.Utils.Http.InformationManager;
using ManagerSystem.Utils.Http.SystemManager;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;


namespace CompanyManagerSystem.ViewModel.subViewModel
{
    public class HomeViewModel : ObservableObject
    {

        public HomeViewModel()
        {
            Initialize();
            InitializeLineData();
            InitializePieData();
        }

        #region 属性

        #region 教育信息

        private int _StudentCount;
        /// <summary>
        /// 学生总数
        /// </summary>
        public int StudentCount
        {
            get { return _StudentCount; }
            set
            {
                _StudentCount = value;
                RaisePropertyChanged();
            }
        }

        private int _ClassCount;
        /// <summary>
        /// 班级总数
        /// </summary>
        public int ClassCount
        {
            get { return _ClassCount; }
            set
            {
                _ClassCount = value;
                RaisePropertyChanged();
            }
        }

        private int _TeacherCount;
        /// <summary>
        /// 教师总数
        /// </summary>
        public int TeacherCount
        {
            get { return _TeacherCount; }
            set
            {
                _TeacherCount = value;
                RaisePropertyChanged();
            }
        }

        private string _PassRate;
        /// <summary>
        /// 一本率
        /// </summary>
        public string PassRate
        {
            get { return _PassRate; }
            set
            {
                _PassRate = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 系统管理属性

        private int _UserCount;
        /// <summary>
        /// 用户总数
        /// </summary>
        public int UserCount
        {
            get { return _UserCount; }
            set { _UserCount = value; }
        }


        private ObservableCollection<string> _RootMenuList = new ObservableCollection<string>();
        /// <summary>
        /// 总部门的列表
        /// </summary>
        public ObservableCollection<string> RootMenuList
        {
            get { return _RootMenuList; }
            set
            {
                _RootMenuList = value;
                RaisePropertyChanged();
            }
        }

        private int _AnnouncementCount;
        /// <summary>
        /// 公告总数
        /// </summary>
        public int AnnouncementCount
        {
            get { return _AnnouncementCount; }
            set
            {
                _AnnouncementCount = value;
                RaisePropertyChanged();
            }
        }

        private NoticeDto _LatestAnnouncement = new NoticeDto();
        /// <summary>
        /// 最新公告
        /// </summary>
        public NoticeDto LatestAnnouncement
        {
            get { return _LatestAnnouncement; }
            set
            {
                _LatestAnnouncement = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region 表格

        #region 曲线图



        #endregion
        // 使用旧版 SeriesCollection
        public SeriesCollection GradeScoreTrends { get; private set; }

        // 考试名称（X轴标签）
        public string[] ExamNames { get; private set; } = { "第一次月考", "期中考试", "第二次月考", "期末考试", "模拟考1", "模拟考2" };

        private void InitializeLineData()
        {
            GradeScoreTrends = new SeriesCollection
            {
                // 高一年级成绩
                new LineSeries
                {
                    Title = "高一",
                    Values = new ChartValues<double> { 450, 480, 500, 520, 530, 540 },
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    Stroke = Brushes.ForestGreen,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent
                },
            
                // 高二年级成绩
                new LineSeries
                {
                    Title = "高二",
                    Values = new ChartValues<double> { 500, 520, 535, 550, 560, 570 },
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    Stroke = Brushes.Purple,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent
                },
            
                // 高三年级成绩
                new LineSeries
                {
                    Title = "高三",
                    Values = new ChartValues<double> { 550, 565, 575, 585, 590, 600 },
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent
                }
            };
        }

        #region 柱状图

        // 饼图数据：各年级500分以上比例
        public SeriesCollection GradeDistribution { get; private set; }

        private void InitializePieData()
        {
            // 饼图数据
            GradeDistribution = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "高一",
                    Values = new ChartValues<double> { 30 },  // 30%
                    DataLabels = true,
                    LabelPoint = chartPoint =>
                        $"{chartPoint.SeriesView.Title}: {chartPoint.Y:0}%",
                    Fill = Brushes.ForestGreen,
                    FontSize = 12
                },
                new PieSeries
                {
                    Title = "高二",
                    Values = new ChartValues<double> { 45 },  // 45%
                    DataLabels = true,
                    LabelPoint = chartPoint =>
                        $"{chartPoint.SeriesView.Title}: {chartPoint.Y:0}%",
                    Fill = Brushes.Purple,
                    FontSize = 12
                },
                new PieSeries
                {
                    Title = "高三",
                    Values = new ChartValues<double> { 65 },  // 65%
                    DataLabels = true,
                    LabelPoint = chartPoint =>
                        $"{chartPoint.SeriesView.Title}: {chartPoint.Y:0}%",
                    Fill = Brushes.Red,
                    FontSize = 12
                }
            };
        }

        #endregion

        #endregion



        #endregion

        #region 命令
        private ICommand _NavigateToStudentListCommand;
        /// <summary>
        /// 打开学生管理界面
        /// </summary>
        public ICommand NavigateToStudentListCommand
        {
            get
            {
                return _NavigateToStudentListCommand ??
                    (_NavigateToStudentListCommand = new RelayCommand(() =>
                    {

                    }));
            }
        }


        #endregion

        #region 方法 

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void Initialize()
        {
            // 教育信息概述

            StudentCount = StudentHttpUtil.GetAllStudent().TotalCount;// 获取学生总数

            ClassCount = ClassHttpUtil.GetAllClass().TotalCount; // 班级总数

            TeacherCount = TeacherHttpUtil.GetAllTeacher().TotalCount; // 教师总数

            PassRate = "50%"; // 一本率

            // 管理信息
            UserCount = UserHttpUtil.GetAllUser().TotalCount; // 用户总数

            foreach (var item in DepHttpUtil.GetAllDepartment().items) // 总部门列表
            {
                if (item.parent_id == 0)
                {
                    RootMenuList.Add(item.DepName);
                }
            }

            AnnouncementCount = NoticeHttpUtil.GetAllNotice().TotalCount; // 公告数目

            LatestAnnouncement = new NoticeDto() { Notice = NoticeHttpUtil.GetLatestNotice() }; // 获取公告
        }

        #endregion
    }
}


