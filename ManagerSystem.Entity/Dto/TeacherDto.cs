using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class TeacherDto : ViewModelBase
    {

        private Teachers _Teacher = new Teachers();
        /// <summary>
        /// 教师类
        /// </summary>
        public Teachers Teacher
        {
            get { return _Teacher; }
            set
            {
                _Teacher = value;
                RaisePropertyChanged();
            }
        }

    }
}
