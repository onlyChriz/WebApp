using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class BlogPosts
    {
        [Key]
        public int Id { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }

        public BlogPosts(string pageTitle, string content, DateTime publishedDate, string author)
        {
            PageTitle = pageTitle;
            Content = content;
            PublishedDate = publishedDate;
            Author = author;
        }

        public BlogPosts()
        {
        }
    }
}
