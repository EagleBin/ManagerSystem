using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ManagerSystem.Entity.SystemManager;
using System.Collections.Generic;
using System.Windows;



namespace ManagerSystem.Entity.Dto
{
    public class DepartmentDto : ViewModelBase
    {
        private Department _Department = new Department();

        public Department Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
                RaisePropertyChanged();
            }


        }

        private bool _IsChecked =false;

        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                Messenger.Default.Send<DepartmentDto>(this, "DepartmentCheckChanged");
                RaisePropertyChanged();
            }
        }

        private float _MarginLeft = 0;

        public float MarginLeft
        {
            get { return _MarginLeft; }
            set { _MarginLeft = value; }
        }

        private Visibility _IsVisibility = Visibility.Collapsed;

        public Visibility IsVisibility
        {
            get { return _IsVisibility; }
            set
            {
                _IsVisibility = value;
                RaisePropertyChanged();
            }
        }

        private List<DepartmentDto> _ChildDepartmentList;

        public List<DepartmentDto> ChildDepartmentList
        {
            get { return _ChildDepartmentList; }
            set
            {
                _ChildDepartmentList = value;
                RaisePropertyChanged();
            }
        }




    }
}
