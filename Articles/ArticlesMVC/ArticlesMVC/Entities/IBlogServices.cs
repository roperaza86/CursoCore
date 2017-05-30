using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Options;

namespace ArticlesMVC.Entities
{
   public  interface IBlogServices
    {
        IEnumerable<Post> GetLatestPost(int max);
        IEnumerable<Post> GetPostByDate(int year, int month);
        Post GetPost(string slug);
    }

    public class BlogServices : IBlogServices
    {
        private static readonly List<Post> Posts;

        static BlogServices()
        {
            Posts = new List<Post>()
            {
                new Post()
                {
                    Title = "Welcome to MVC",
                    Slug = "welcome-to-mvc",
                    Author = "jmaguilar",
                    Text = "Hi! Welcome to MVC!",
                    Date = new DateTime(2016, 01, 01)
                },
                new Post()
                {
                    Title = "Second post",
                    Slug = "second-post",
                    Author = "jmaguilar",
                    Text = "Hello, this is my second post :)",
                    Date = new DateTime(2016, 01, 10)
                },
                new Post()
                {
                    Title = "Another post",
                    Slug = "another-post",
                    Author = "jmaguilar",
                    Text = "Wow, this is my third post!",
                    Date = new DateTime(2016, 03, 15)
                }
            };

            for (int i = 1; i < 5; i++)
            {
                Posts.Add(
                    new Post()
                    {
                        Title = $"Post number {i}",
                        Slug = $"Post-number-{i}",
                        Author = "jmaguilar",
                        Text = $"Text of post #{i}",
                        Date = new DateTime(2016, 06, 01).AddDays(i)
                    }
                );
            }
        }

        public IEnumerable<Post> GetLatestPost(int max)
        {
            return Posts.Take(max).ToList();
        }

        public IEnumerable<Post> GetPostByDate(int year, int month)
        {
            var posts = from p in Posts
                where p.Date.Year == year && p.Date.Month == month
                select p;
            return posts.ToList();
        }

        public Post GetPost(string slug)
        {
            var post = from p in Posts
                where p.Slug.Equals(slug)
                select p;
            return post.FirstOrDefault();
        }
    }
}