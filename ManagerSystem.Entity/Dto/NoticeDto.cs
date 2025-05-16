using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    /// <summary>
    /// 公告数据传输类
    /// </summary>
    public class NoticeDto : ViewModelBase
    {
        private Notice _Notice = new Notice();
        /// <summary>
        /// 公告
        /// </summary>
        public Notice Notice
        {
            get { return _Notice; }
            set
            {
                _Notice = value;
                RaisePropertyChanged();
            }

        }
    }
}
