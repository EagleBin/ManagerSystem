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
    public class PostDto : ViewModelBase
    {
        private Post _Post = new Post();

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
