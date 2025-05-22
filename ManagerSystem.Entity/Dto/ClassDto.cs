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

        private Classes _Classes = new Classes();
        /// <summary>
        /// 班级类
        /// </summary>
        public Classes Classes
        {
            get { return _Classes; }
            set
            {
                _Classes = value;
                RaisePropertyChanged();
            }
        }

        private Teachers _Teachers = new Teachers();
        /// <summary>
        /// 临时教师类
        /// </summary>
        public Teachers Teachers
        {
            get { return _Teachers; }
            set { _Teachers = value;
                RaisePropertyChanged();
            }
        }


        private int _StudentTotalCount;
        /// <summary>
        /// 班级总人数
        /// </summary>
        public int StudentTotalCount
        {
            get { return _StudentTotalCount; }
            set
            {
                _StudentTotalCount = value;
                RaisePropertyChanged();
            }
        }


    }
}
