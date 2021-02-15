using PostalOfficeDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostalOfficeDemo.ViewModels
{
    public class ItemListViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }
        private PostDatabaseHelper<PostDatabaseContext> PostDatabaseHelper { get; set; }

        public ItemListViewModel()
        {
            this.Posts = new ObservableCollection<Post>();
            PostDatabaseHelper = new PostDatabaseHelper<PostDatabaseContext>();
        }

        public async Task UpdatePostsAsync()
        {
            try
            {
                //update the backend if possible and update database 
                var newPosts = await JsonPlaceholderHelper.GetPostsAsync();

                for (int i = 0; i < newPosts.Count; i++)
                {
                    newPosts[i].ImageUrl = $"https://picsum.photos/70/?image={i + 1}";
                }

                await PostDatabaseHelper.AddOrUpdatePostsAsync(newPosts);
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP request exception {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Accessed in offline mode. Error message: {ex.Message}");
            }

            //always display what's in the database 
            var databasePosts = PostDatabaseHelper.GetPostsAsync().Result;
            
            //The following algorithm allows to replace only the items that changed in the observable collection
            for (int i = 0; i < databasePosts.Count; i++)
            {
                if (Posts.Count <= i)
                {
                    Posts.Add(databasePosts[i]);
                }
                else if (databasePosts[i].Id != Posts[i].Id)
                {
                    Posts[i] = databasePosts[i];
                }
            }

            //delete remaining items in the Post collection
            for (int i = databasePosts.Count; i < Posts.Count; i++)
            {
                Posts.RemoveAt(i);
            }
        }
    }
}
