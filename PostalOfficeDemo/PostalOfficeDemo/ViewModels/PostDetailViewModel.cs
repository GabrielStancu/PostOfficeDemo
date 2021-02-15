using System;
using System.Collections.Generic;
using System.Text;

namespace PostalOfficeDemo.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        private Post _post;
        public Post Post
        {
            get => _post;
            set
            {
                SetProperty(ref _post, value);
            }
        }

        public PostDetailViewModel(Post post)
        {
            this.Post = post;
        }
    }
}
