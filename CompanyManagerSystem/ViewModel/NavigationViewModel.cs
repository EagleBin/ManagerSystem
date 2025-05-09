using CompanyManagerSystem.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.Dto;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyManagerSystem.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
            Messenger.Default.Register<string>(this, "NavigateView", NavigateViewMethod);
            Messenger.Default.Register<string>(this, "MenuExpander", menuExpanderMethod);

            MenuBarList = new ObservableCollection<MenuBarModel>();
            CreateMenuBar(UserInfo.Instance.CurrentMenus);

        }

        #region 属性

        private ObservableCollection<MenuBarModel> _MenuBarList;
        /// <summary>
        /// 菜单列表
        /// </summary>
        public ObservableCollection<MenuBarModel> MenuBarList
        {
            get { return _MenuBarList; }
            set
            {
                _MenuBarList = value;
                RaisePropertyChanged();
            }
        }

        private object _CurrentView;
        /// <summary>
        /// 当前视图
        /// </summary>
        public object CurrentView
        {
            get { return _CurrentView; }
            set
            {
                _CurrentView = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 命令

        private ICommand _HomeCommand;
        /// <summary>
        /// 首页
        /// </summary>
        public ICommand HomeCommand
        {
            get
            {
                return _HomeCommand ?? (_HomeCommand = new RelayCommand(() =>
                {
                    NavigateViewMethod("HomeView");
                }));
            }

        }

        private ICommand _PersonalCommand;
        /// <summary>
        /// 个人中心
        /// </summary>
        public ICommand PersonalCommand
        {
            get
            {
                return _PersonalCommand ?? (_PersonalCommand = new RelayCommand(() =>
                {
                    NavigateViewMethod("PersonView");
                }));
            }

        }

        private ICommand _LogoutCommand;
        /// <summary>
        /// 账号退出
        /// </summary>
        public ICommand LogoutCommand
        {
            get
            {
                return _LogoutCommand ?? (_LogoutCommand = new RelayCommand<MainWindow>((mainWindow) =>
                {
                    var result = HandyControl.Controls.MessageBox.Show("确认退出登录", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        GlobalDic.pageDic.Clear(); // 清空存储的页面
                        UserInfo.Instance = null; // 清空用户信息

                        Application.Current.Dispatcher.Invoke((Action)delegate ()
                        {
                            LoginWindow loginWindow = new LoginWindow();
                            loginWindow.Show();
                            mainWindow.Close();
                            ViewModelLocator.Cleanup(); // 清理 ViewModel 资源
                            ViewModelLocator.Register();
                        });
                    }
                }));
            }
        }

        private ICommand _UserCommand;
        /// <summary>
        /// 用户管理
        /// </summary>
        public ICommand UserCommand
        {
            get
            {
                return _UserCommand ?? (_UserCommand = new RelayCommand(() =>
                {
                    NavigateViewMethod("SystemManager.UserView");
                }));
            }

        }

        #endregion

        #region 方法

        /// <summary>
        /// 创建用户拥有的菜单列表
        /// </summary>
        /// <param name="allMenuList"></param>
        private void CreateMenuBar(List<Menu> allMenuList)
        {
            MenuBarList.Clear(); // 清空菜单列表
            List<Menu> rootMenus = allMenuList.Where(t => t.parent_Id == 0).ToList(); // 寻找根节点
            // 遍历根节点并获取子列表，添加进菜单列表
            foreach (var menu in rootMenus)
            {
                MenuBarModel treeNode = new MenuBarModel();
                treeNode.Menu = menu;
                treeNode.Menu.Icon = GlobalDic.iconDic[menu.Icon];
                treeNode.ChildMenuBarModel = GetChildrenTree(menu.Id, allMenuList);
                MenuBarList.Add(treeNode);
            }
            NavigateViewMethod("HomeView"); // 导航到首页
        }

        private void NavigateViewMethod(string viewName)
        {
            // 记录有界面，直接使用
            if (GlobalDic.pageDic.ContainsKey(viewName))
            {
                CurrentView = GlobalDic.pageDic[viewName];
            }
            // 没有则直接创建
            else 
            {
                string fullName = "CompanyManagerSystem.View.subView." + viewName;
                CurrentView = GetUserControlByName(fullName);
                GlobalDic.pageDic.Add(viewName, CurrentView);
            }

        }

        /// <summary>
        /// 菜单展开
        /// </summary>
        /// <param name="title"></param>
        private void menuExpanderMethod(string title)
        {
            //遍历所有顶级菜单项
            //如果菜单项的标题与接收到的标题匹配，则展开该菜单
            //其他菜单项则保持折叠状态
            //这种实现确保每次只有一个菜单组会被展开
            foreach (var menu in MenuBarList)
            {
                menu.IsExpanded = (menu.Menu.Title == title);
            }
        }


        private object GetUserControlByName(string fullName)
        {
            string currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name; // 获取程序集名称
            Assembly currentAssembly = Assembly.Load(new AssemblyName(currentAssemblyName)); // 加载程序集
            return currentAssembly.CreateInstance(fullName); // 创建对象实例
        }

        private List<MenuBarModel> GetChildrenTree(int curNodeId, List<Menu> allNode)
        {
            if (allNode == null || allNode.Count < 0)
            {
                return new List<MenuBarModel>();
            }

            List<MenuBarModel> TreeList = new List<MenuBarModel>();
            List<Menu> childrens = allNode.Where(t => t.parent_Id == curNodeId).ToList(); // 获取子节点集合
            foreach (var children in childrens)
            {
                MenuBarModel treeNode = new MenuBarModel();
                treeNode.Menu = children;
                treeNode.Menu.Icon = GlobalDic.iconDic[children.Icon];
                treeNode.ChildMenuBarModel = GetChildrenTree(children.Id, allNode);
                TreeList.Add(treeNode);
            }
            return TreeList;
        }
        #endregion






    }
}
