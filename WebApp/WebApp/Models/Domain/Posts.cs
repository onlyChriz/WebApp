namespace WebAppAPI.Models.Domain
{
    public class Posts
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

    }
}
