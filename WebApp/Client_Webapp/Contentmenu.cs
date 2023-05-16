using Client_Webapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Client_Webapp
{
    public class Contentmenu
    {
        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. GET");
                Console.WriteLine("2. GET ID");
                Console.WriteLine("3. POST");
                Console.WriteLine("4. PUT");
                Console.WriteLine("5. DELETE");
                Console.WriteLine("6. Quit");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "get":
                        Get();
                        break;
                    case "2":
                    case "get id":
                        GetBuyId();
                        break;
                    case "3":
                    case "post":
                        Post();
                        break;
                    case "4":
                    case "put":
                        Put();
                        break;
                    case "5":
                    case "delete":
                        Delete();
                        break;
                    case "6":
                    case "quit":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        private void Get()
        {
            //Console.WriteLine("Hämta alla.");
            //string content = Console.ReadLine();

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44343/api/BlogPosts"); //CHANGED THE URI

            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                List<BlogPosts> blogPosts = JsonSerializer.Deserialize<List<BlogPosts>>(json);  //BLOGPOST CLASS WAS INITIALLY CALLED BLOG - CHANGED TO BLOGPOST
                foreach (BlogPosts blogPost in blogPosts)
                {  
                    Console.WriteLine("content " + blogPost.Author + " arrived. : " + blogPost.Content); 
                }
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }

        private void Post()
        {
            Console.WriteLine("Enter your username");
            string author = Console.ReadLine();
            Console.WriteLine("Enter your title");
            string pageTitle = Console.ReadLine();
            Console.WriteLine("Enter your post");
            string content = Console.ReadLine();

            BlogPosts blogPost = new BlogPosts() { Author = author, Content = content, Pagetitle = pageTitle, Publisheddate = DateTime.Now };

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44343/api/BlogPosts");

            string json = JsonSerializer.Serialize(blogPost);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine(blogPost.Content + " successfully registered!");
            }
            else
            {
                Console.WriteLine("Post failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }

        private void GetBuyId()
        {
            Console.WriteLine("Enter the id of the post you want");
            int id = 0;
            id = Input(id);


            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44343/api/BlogPosts/" + id); //CHANGED THE URI

            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                BlogPosts blogPosts = JsonSerializer.Deserialize<BlogPosts>(json);  //BLOGPOST CLASS WAS INITIALLY CALLED BLOG - CHANGED TO BLOGPOST
                              
                Console.WriteLine("content " + blogPosts.Author + " arrived. : " + blogPosts.Content);
                
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }
        private void Put()
        {
            Console.WriteLine("Enter the id of the post you would like to update");
            int id = 0;
            id = Input(id);
            Console.WriteLine("Update the content of your post and hit enter");
            string content =Console.ReadLine();
            Console.WriteLine("Update the title of your post and hit enter");
            string pageTitle = Console.ReadLine();
            Console.WriteLine("Update the username of your post and hit enter");
            string author = Console.ReadLine();

            BlogPosts blogPost = new BlogPosts() {Id = id, Pagetitle = pageTitle, Content = content, Publisheddate = DateTime.Now, Author = author };

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:44343/api/BlogPosts/" + id);

            string json = JsonSerializer.Serialize(blogPost);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully updated.");
            }
            else
            {
                Console.WriteLine("Put failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter the ID of the blogpost you would like to delete.");
            int id = 0;
            id = Input(id);

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44343/api/BlogPosts/" + id);

            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Blogpost " + id + " was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }

        private static int Input(int id)
        {
            while (id == 0)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {
                    Console.WriteLine("input number not letters IDIOT");
                }
            }
            return id;
        }
    }
}
