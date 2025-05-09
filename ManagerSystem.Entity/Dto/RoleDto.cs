using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    /// <summary>
    /// 权限数据传输类
    /// </summary>
    public class RoleDto : ViewModelBase
    {

        private Role _Role = new Role();
        /// <summary>
        /// 权限数据实体类
        /// </summary>
        public Role Role
        {
            get { return _Role; }
            set
            {
                _Role = value;
                RaisePropertyChanged();
            }
        }


        private List<MenuBarModel> _Menu = new List<MenuBarModel>();
        /// <summary>
        /// 该权限所拥有的菜单列表
        /// </summary>
        public List<MenuBarModel> Menu
        {
            get { return _Menu; }
            set
            {
                _Menu = value;
                RaisePropertyChanged();
            }
        }

        private bool _IsChecked = false;
        /// <summary>
        /// 权限是否被勾选
        /// </summary>
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                RaisePropertyChanged();
            }
        }



    }
}
