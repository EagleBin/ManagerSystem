using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class StudentDto : ViewModelBase
    {

        private Students _Student;
        /// <summary>
        /// 学生类
        /// </summary>
        public Students Student
        {
            get { return _Student; }
            set
            {
                _Student = value;
                RaisePropertyChanged();
            }
        }






    }
}
