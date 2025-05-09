using CompanyManagerSystem.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ManagerSystem.Entity.SystemManager;
using ManagerSystem.Utils.Global;
using ManagerSystem.Utils.Helper;
using ManagerSystem.Utils.Http;
using ManagerSystem.Utils.Http.SystemManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CompanyManagerSystem.ViewModel
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private static Timer _loginTimer = new Timer();
        private LoginWindow _loginWindow = null;

        public LoginViewModel()
        {

            CodeImage = GetImage(200, 60);
            Code_Login = CodeImage;

            _loginTimer.Elapsed += new ElapsedEventHandler(LoginSystem); // 达到间隔时间后发生的事情（登录）
            _loginTimer.AutoReset = false;
        }



        #region 属性

        private string _Account_Login = "admin";
        /// <summary>
        /// 账号
        /// </summary>
        public string Account_Login
        {
            get { return _Account_Login; }
            set
            {
                _Account_Login = value;
                RaisePropertyChanged();
            }
        }

        private string _Password_Login = "admin";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password_Login
        {
            get { return _Password_Login; }
            set
            {
                _Password_Login = value;
                RaisePropertyChanged();
            }
        }

        private string _Code_Login;
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code_Login
        {
            get { return _Code_Login; }
            set
            {
                _Code_Login = value;
                RaisePropertyChanged();
            }
        }

        private string _CodeImage;
        /// <summary>
        /// 验证码图片
        /// </summary>
        public string CodeImage
        {
            get { return _CodeImage; }
            set
            {
                _CodeImage = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _LoginButtonVisibility = Visibility.Visible;
        /// <summary>
        /// 登录按钮显示
        /// </summary>
        public Visibility LoginButtonVisibility
        {
            get { return _LoginButtonVisibility; }
            set
            {
                _LoginButtonVisibility = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _LoadingButtonVisibility = Visibility.Hidden;
        /// <summary>
        /// 登陆中按钮显示
        /// </summary>
        public Visibility LoadingButtonVisibility
        {
            get { return _LoadingButtonVisibility; }
            set
            {
                _LoadingButtonVisibility = value;
                RaisePropertyChanged();
            }
        }

        private User _CurrentUser;
        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                RaisePropertyChanged();
            }
        }

        private ImageSource _CodeImageSource;
        /// <summary>
        /// 图片资源
        /// </summary>
        public ImageSource CodeImageSource
        {
            get { return _CodeImageSource; }
            set
            {
                _CodeImageSource = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 命令

        private ICommand _ChangeCodeCommand;
        /// <summary>
        /// 改变验证码命令
        /// </summary>
        public ICommand ChangeCodeCommand
        {
            get
            {
                //return _ChangeCodeCommand ?? (_ChangeCodeCommand = new RelayCommand(() =>
                //{
                //    CodeImage = GetImage(200, 60);
                //}));

                if (_ChangeCodeCommand == null)
                {
                    _ChangeCodeCommand = new RelayCommand(() =>
                    {
                        CodeImage = GetImage(200, 60);
                    });
                }
                return _ChangeCodeCommand;
            }

        }

        private ICommand _LoginCommand;
        /// <summary>
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return _LoginCommand ?? (_LoginCommand = new RelayCommand<LoginWindow>((loginWindow) =>
                {
                    if (string.IsNullOrEmpty(Account_Login))
                    {
                        HandyControl.Controls.Growl.Warning("账号不能为空", "LoginWarningMsg");
                        return;
                    }
                    if (string.IsNullOrEmpty(Password_Login))
                    {
                        HandyControl.Controls.Growl.Warning("密码不能为空", "LoginWarningMsg");
                        return;
                    }
                    if (string.IsNullOrEmpty(Code_Login))
                    {
                        HandyControl.Controls.Growl.Warning("验证码不能为空", "LoginWarningMsg");
                        return;
                    }

                    if (Code_Login.ToUpper().Trim() == CodeImage)
                    {
                        LoginButtonVisibility = Visibility.Hidden; // 隐藏登录按钮
                        LoadingButtonVisibility = Visibility.Visible; // 显示加载按钮

                        DelayLogin(loginWindow); // 登录
                    }
                    else
                    {
                        HandyControl.Controls.Growl.Warning("验证码错误", "LoginWarningMsg");
                        return;
                    }

                }));


            }

        }
        #endregion

        #region 方法

        /// <summary>
        /// 延时
        /// </summary>
        /// <param name="loginWindow"></param>
        private void DelayLogin(LoginWindow loginWindow)
        {
            this._loginWindow = loginWindow;

            Random random = new Random(); // 随机数范围1~3
            int waitTime = random.Next(1, 3);

            _loginTimer.Interval = waitTime * 1000; // 延时
            _loginTimer.Start();
        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginSystem(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Dispatcher负责管理线程的消息队列
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    LoginButtonVisibility = Visibility.Hidden;
                    LoadingButtonVisibility = Visibility.Visible; // 显示登录中

                    //根据从前端获取的账号和密码 获取当前登录对象
                    User loginUser = UserHttpUtil.GetLoginUser(Account_Login, Password_Login);

                    Code_Login = "";
                    CodeImage = GetImage(200, 60);

                    if (loginUser != null)
                    {
                        UserInfo.Instance.CurrentUser = loginUser; // 获取当前登录用户
                        UserInfo.Instance.CurrentUser.Password = ""; // 密码清空
                        UserInfo.Instance.CurrentRoles = UserHttpUtil.GetUserRole(loginUser.Id).items; // 获取用户权限列表
                        
                        Dictionary<string, Menu> menuDic = new Dictionary<string, Menu>();
                        if (UserInfo.Instance.CurrentRoles != null && UserInfo.Instance.CurrentRoles.Count > 0)
                        {
                            //根据 用户的权限 获取 菜单列表
                            foreach (var role in UserInfo.Instance.CurrentRoles)
                            {
                                List<Menu> menuList = RoleHttpUtil.GetRoleMenu(role.Id).items;
                                foreach (var menu in menuList)
                                {
                                    menuDic.Add(menu.Title, menu);
                                }

                            }
                            // 添加用户所拥有的菜单
                            foreach (var item in menuDic)
                            {
                                UserInfo.Instance.CurrentMenus.Add(item.Value); 
                            }

                        }
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show(); // 打开主窗体
                        _loginWindow.Close(); // 关闭登录窗体
                    }
                    else
                    {
                        LoginButtonVisibility = Visibility.Visible;// 显示按钮 
                        LoadingButtonVisibility = Visibility.Hidden;  // 隐藏按钮
                        HandyControl.Controls.Growl.Warning("用户名或密码错误", "LoginWarningMsg");
                        return;
                    }

                    Account_Login = ""; // 清空输入信息
                    Password_Login = "";
                });
            }
            catch (Exception ex)
            {
                HandyControl.Controls.Growl.Error($"发生异常，详情：{ex.Message}", "LoginErrorMsg");
                return;
            }
        }

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        private string GetImage(int width, int height)
        {
            string code = "";
            //返回一个 Bitmap 对象，代表生成的验证码图片。
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code, width, height);
            CodeImageSource = ImageFormatConvertHelper.ChangeBitmapToImageSource(bitmap);
            return code;
        }


        #endregion
    }
}
