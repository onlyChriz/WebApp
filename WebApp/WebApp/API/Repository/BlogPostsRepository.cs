using System.Diagnostics.Contracts;
using WebApp.API.Interfaces;
using WebApp.Data;

namespace WebApp.API.Repository
{
    public class BlogPostsRepository : IBlogPostsRepository
    {
        private readonly ApplicationDbContext context;

        public BlogPostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<BlogPosts> GetBlogPosts() //RETURNS LIST OF ALL BLOG POSTS
        {
            return context.BlogPosts.OrderBy(b => b.Id).ToList();
        }

        public BlogPosts GetBlogPostByID(int id) //RETURNS A BLOG POST BY ID
        {
            return context.BlogPosts.Where(b => b.Id == id).FirstOrDefault();
        }

        public bool BlogPostExists(int blogPostID) //CHECKS IF ID EXISTS
        {
            return context.BlogPosts.Any(p => p.Id == blogPostID);
        }

        public bool CreateBlogPost(BlogPosts blogPosts)
        {
            
            context.Add(blogPosts);
            return Save(); //this is a "Change Tracker". It will add, update and modify
        }

        public bool UpdateBlogPost(BlogPosts blogPosts)
        {
            context.Update(blogPosts);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges(); //Save changes - entity framework converts what you want to enter and puts it in to sql 
            return saved > 0 ? true : false;
        }

        public bool DeleteBlogPost(BlogPosts blogPosts)
        {
            context.BlogPosts.Remove(blogPosts);
            return Save();
        }

    }

}
