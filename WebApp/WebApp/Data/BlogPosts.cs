using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class BlogPosts
    {
        public Guid Id { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
    }
}
