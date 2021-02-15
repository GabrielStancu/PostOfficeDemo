using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalOfficeDemo.Helpers
{
    public class PostDatabaseHelper<T> where T : PostDatabaseContext
    {
        protected PostDatabaseContext CreateContext()
        {
            PostDatabaseContext postDatabaseContext = (T)Activator.CreateInstance(typeof(T));
            postDatabaseContext.Database.EnsureCreated();
            postDatabaseContext.Database.Migrate();

            return postDatabaseContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            using (var context = CreateContext())
            {
                return await context.Posts
                    .AsNoTracking()
                    .OrderByDescending(post => post.Id)
                    .ToListAsync();
            }
        }

        public async Task AddOrUpdatePostsAsync(List<Post> posts)
        {
            using (var context = CreateContext())
            {
                var newPosts = posts.Where(
                    post => context.Posts.Any(dbPost => dbPost.Id == post.Id) == false);
                await context.Posts.AddRangeAsync(newPosts);
                await context.SaveChangesAsync();
            }
        }
    }
}
