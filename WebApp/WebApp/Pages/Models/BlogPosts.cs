using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class BlogPosts
    {
        public int Id { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
    }
}
