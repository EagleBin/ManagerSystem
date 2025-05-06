using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Utils.Global
{
    public class UserInfo: ViewModelBase
    {
		private static UserInfo _Instance;
		/// <summary>
		/// 单例模式
		/// </summary>
		public static UserInfo Instance
        {
			get {
				if (_Instance == null)
				{
					_Instance = new UserInfo();
				}
				return _Instance; }
			set { _Instance = value; }
		}

		private User _CurrentUser;

		public User CurrentUser
        {
			get { return _CurrentUser; }
			set { _CurrentUser = value; }
		}

		private List<Role> _CurrentRoles = new List<Role>();

		public List<Role> CurrentRoles
        {
			get { return _CurrentRoles; }
			set { _CurrentRoles = value; RaisePropertyChanged(); }
		}

		private List<Menu> _CurrentMenus = new List<Menu>();

		public List<Menu> CurrentMenus
        {
			get { return _CurrentMenus; }
			set { _CurrentMenus = value; RaisePropertyChanged(); }
		}

		private List<Department> _CurrentDepartments = new List<Department>();

		public List<Department> CurrentDepartments
        {
			get { return _CurrentDepartments; }
			set { _CurrentDepartments = value; RaisePropertyChanged(); }
		}



	}
}
