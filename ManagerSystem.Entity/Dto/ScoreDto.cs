using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    public class ScoreDto : ViewModelBase
    {

        private Scores _Scores = new Scores();
        /// <summary>
        /// 成绩表
        /// </summary>
        public Scores Score
        {
            get { return _Scores; }
            set
            {
                _Scores = value;
                RaisePropertyChanged();
            }
        }

    }
}
