using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class ClassDto : ViewModelBase
    {

        private Classes _Class;
        /// <summary>
        /// 班级类
        /// </summary>
        public Classes Class
        {
            get { return _Class; }
            set
            {
                _Class = value;
                RaisePropertyChanged();
            }
        }


    }
}
