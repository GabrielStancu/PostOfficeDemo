using PostalOfficeDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostalOfficeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        PostDetailViewModel postDetailViewModel;
        public PostDetail()
        {
            InitializeComponent();
        }

        public PostDetail(Post post)
        {
            InitializeComponent();
            postDetailViewModel = new PostDetailViewModel(post);
            this.BindingContext = postDetailViewModel;
        }
    }
}