using System;
using System.Text;
using System.Text.Json;

namespace ClientWebApp
{
	public class BlogPostMenu
	{
        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. GET");
                Console.WriteLine("2. POST");
                Console.WriteLine("3. PUT");
                Console.WriteLine("4. DELETE");
                Console.WriteLine("5. Quit");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "get":
                        Get();
                        break;
                    case "2":
                    case "post":
                        Post();
                        break;
                    case "3":
                    case "put":
                        Put();
                        break;
                    case "4":
                    case "delete":
                        Delete();
                        break;
                    case "quit":

                        return;
                }
            }
        }

        private void Get() // Get by post author
        {
            Console.WriteLine("Please write the author of the post you want.");
            string author = Console.ReadLine();

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7289/api/Posts/getbyauthor?author=" + author);

            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                BlogPosts post = JsonSerializer.Deserialize<BlogPosts>(json);
                Console.WriteLine("Post: " + post.PageTitle + ". Content: " + post.Content);
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }

        private void Post() // add a new post
        {
            Console.WriteLine("What's the page title?");
            string title = Console.ReadLine();
            Console.WriteLine("What's the page content");
            string content = Console.ReadLine();
            Console.WriteLine("What's the author name?");
            string author = Console.ReadLine();
          
            BlogPosts post = new BlogPosts() { PageTitle = title, Content = content, PublishedDate = DateTime.Now, Author = author};

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:7289/api/Posts/post");

            string json = JsonSerializer.Serialize(post);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(post.PageTitle + " successfully registered!");
            }
            else
            {
                Console.WriteLine("Post failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }

        private void Put()
        {
            Console.WriteLine("What is the page author you want to update?");
            string author = Console.ReadLine();
            Console.WriteLine("What's the new title?");
            string newTitle = Console.ReadLine();

            BlogPosts post = new BlogPosts() { PageTitle = newTitle, Author = author};

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:7289/api/Posts/put");

            string json = JsonSerializer.Serialize(post);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(post.Author + "'s post successfully changed to " + post.PageTitle + "!");
            }
            else
            {
                Console.WriteLine("Put failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }

        private void Delete()
        {
            Console.WriteLine("Please write the title of the post you want to delete.");
            string title = Console.ReadLine();

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7289/api/Posts/delete?pageTitle=" + title);

            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post with title [" + title + "] successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }
    }
}

