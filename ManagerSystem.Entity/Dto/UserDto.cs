using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class UserDto : ViewModelBase
    {
        private User _User = new User();

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
