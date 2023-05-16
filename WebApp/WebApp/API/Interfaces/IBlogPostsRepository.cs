using WebApp.Data;

namespace WebApp.API.Interfaces
{
    public interface IBlogPostsRepository

    {
        ICollection<BlogPosts> GetBlogPosts();

        BlogPosts GetBlogPostByID(int id);
        bool BlogPostExists(int blogPostID);

        bool CreateBlogPost(BlogPosts blogPosts);

        bool UpdateBlogPost(BlogPosts blogPosts);

        bool DeleteBlogPost(BlogPosts blogPosts);
        bool Save();    
    }
}
