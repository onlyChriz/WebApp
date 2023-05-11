using System;
using System.Text.Json.Serialization;

namespace ClientWebApp
{
	public class BlogPosts
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("pageTitle")]
        public string PageTitle { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("publishedDate")]
        public DateTime PublishedDate { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }

        public BlogPosts(int id, string PageTitle, string Content, DateTime PublishedData, string Author)
        {
            this.Id = id;
            this.PageTitle = PageTitle;
            this.Content = Content;
            this.PublishedDate = PublishedDate;
            this.Author = Author;
        }

        public BlogPosts()
        {

        }
    }
}

