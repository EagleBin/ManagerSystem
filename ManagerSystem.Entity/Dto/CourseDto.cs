using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class CourseDto : ViewModelBase
    {

        private Courses _Course;
        /// <summary>
        /// 课程
        /// </summary>
        public Courses Course
        {
            get { return _Course; }
            set
            {
                _Course = value;
                RaisePropertyChanged();
            }
        }

    }
}
