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
    public partial class ItemListPage : ContentPage
    {
        ItemListViewModel itemListViewModel;
        public ItemListPage()
        {
            InitializeComponent();
            itemListViewModel = new ItemListViewModel();
            BindingContext = itemListViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await itemListViewModel.UpdatePostsAsync();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var postDetailPage = new PostDetail(e.SelectedItem as Post);
            await Navigation.PushModalAsync(postDetailPage);
        }
    }
}