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
    /// 用户数据传输类
    /// </summary>
    public class UserDto : ViewModelBase
    {
        private User _User = new User();
        /// <summary>
        /// 用户数据实体类
        /// </summary>
        public User User
        {
            get { return _User; }
            set
            {
                _User = value;
                RaisePropertyChanged();
            }
        }

        private List<RoleDto> _Role = new List<RoleDto>();
        /// <summary>
        /// 用户所拥有的权限列表
        /// </summary>
        public List<RoleDto> Role
        {
            get { return _Role; }
            set
            {
                _Role = value;
                RaisePropertyChanged();
            }
        }

        private DepartmentDto _Department = new DepartmentDto();
        /// <summary>
        /// 用户的部门
        /// </summary>
        public DepartmentDto Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
                RaisePropertyChanged();
            }
        }
        private List<PostDto> _Post = new List<PostDto>();
        /// <summary>
        /// 用户的岗位（列表）
        /// </summary>
        public List<PostDto> Post
        {
            get { return _Post; }
            set
            {
                _Post = value;
                RaisePropertyChanged();
            }
        }


    }
}
