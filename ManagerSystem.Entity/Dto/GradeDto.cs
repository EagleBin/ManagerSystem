using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class GradeDto : ViewModelBase
    {

        private Grades _Grade;
        /// <summary>
        /// 年级
        /// </summary>
        public Grades Grade
        {
            get { return _Grade; }
            set
            {
                _Grade = value;
                RaisePropertyChanged();
            }
        }


        private int _GradePersonCount;
        /// <summary>
        /// 年级总人数
        /// </summary>
        public int GradePersonCount
        {
            get { return _GradePersonCount; }
            set
            {
                _GradePersonCount = value;
                RaisePropertyChanged();
            }
        }

    }
}
