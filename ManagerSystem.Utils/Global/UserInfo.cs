using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System.Collections.Generic;

namespace ManagerSystem.Utils.Global
{
    /// <summary>
    /// 用户信息类，用于存储当前用户的相关信息
    /// </summary>
    public class UserInfo : ViewModelBase
    {
        private static UserInfo _Instance; // 静态私有字段，用于存储UserInfo唯一实例
        /// <summary>
        /// 单例模式
        /// </summary>
        public static UserInfo Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserInfo();
                }
                return _Instance;
            }
            set { _Instance = value; }
        }

        private User _CurrentUser;
        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set { _CurrentUser = value; }
        }

        private List<Role> _CurrentRoles = new List<Role>();
        /// <summary>
        /// 当前用户所拥有的 权限列表
        /// </summary>
        public List<Role> CurrentRoles
        {
            get { return _CurrentRoles; }
            set
            {
                _CurrentRoles = value;
                RaisePropertyChanged();
            }
        }

        private List<Menu> _CurrentMenus = new List<Menu>();
        /// <summary>
        /// 当前用户所拥有的 菜单列表
        /// </summary>
        public List<Menu> CurrentMenus
        {
            get { return _CurrentMenus; }
            set
            {
                _CurrentMenus = value;
                RaisePropertyChanged();
            }
        }

        private List<Department> _CurrentDepartments = new List<Department>();
        /// <summary>
        /// 当前用户所拥有的 部门列表
        /// </summary>
        public List<Department> CurrentDepartments
        {
            get { return _CurrentDepartments; }
            set
            {
                _CurrentDepartments = value;
                RaisePropertyChanged();
            }
        }



    }
}
