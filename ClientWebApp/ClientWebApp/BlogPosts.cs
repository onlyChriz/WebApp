using System.Text.Json.Serialization;

namespace Client_Webapp
{
    public class BlogPosts
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("author")]
        public string Author { get; set; }
        
        [JsonPropertyName("content")]
        public string Content { get; set; }
        
        [JsonPropertyName("pageTitle")]
        public string Pagetitle { get; set; }
        
        [JsonPropertyName("publishedDate")]
        public DateTime Publisheddate { get; set; }




        public BlogPosts(int id, string author, string content, string pagetitle, DateTime publisheddate)
        {
            Id = id;
            Author = author;
            Content = content;
            Pagetitle = pagetitle;
            Publisheddate = publisheddate;
        }

        public BlogPosts()
        {

        }
    }
}
