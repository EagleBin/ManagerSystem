using GalaSoft.MvvmLight;
using ManagerSystem.Utils.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagerSystem.ViewModel.subViewModel
{
    public class PersonalViewModel : ViewModelBase
    {
        private UserInfo _CurrentUserInfo;

        /// <summary>
        ///  用户信息
        /// </summary>
        public UserInfo CurrentUserInfo
        {
            get { return UserInfo.Instance; }
            set
            {
                _CurrentUserInfo = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 当前权限名称
        /// </summary>
        public string CurrentRoleName
        {
            get
            {
                string roleName = "";

                for (int i = 0; i < CurrentUserInfo.CurrentRoles.Count; i++)
                {
                    roleName += CurrentUserInfo.CurrentRoles[i].RoleName;
                    if (i != CurrentUserInfo.CurrentRoles.Count - 1)
                    {
                        roleName += ",";
                    }
                }
                return roleName;
            }
        }

    }
}
