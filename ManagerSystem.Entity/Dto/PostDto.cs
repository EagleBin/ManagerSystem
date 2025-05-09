using GalaSoft.MvvmLight;
using ManagerSystem.Entity.SystemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
    /// <summary>
    /// 岗位数据传输类
    /// </summary>
    public class PostDto : ViewModelBase
    {
        private Post _Post = new Post();
        /// <summary>
        /// 岗位
        /// </summary>
        public Post Post
        {
            get { return _Post; }
            set
            {
                _Post = value;
                RaisePropertyChanged();
            }
        }

        private bool _IsChecked;
        /// <summary>
        /// 岗位是否被勾选
        /// </summary>
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                RaisePropertyChanged();
            }
        }


    }
}
