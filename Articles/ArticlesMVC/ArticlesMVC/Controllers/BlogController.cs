using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticlesMVC.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ArticlesMVC.Controllers
{

    
    public class BlogController:Controller
    {

        private readonly IBlogServices _blogServices;

        public  BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }


        public IActionResult Index()
        {
            var post = _blogServices.GetLatestPost(5);
            return View(post);
        }

        public IActionResult Archive(int year,int month)
        {
            var post = _blogServices.GetPostByDate(year, month);
            return View(post);
        }

        public IActionResult Viewpost(string slug)
        {
            var post = _blogServices.GetPost(slug);
            if (post == null)
                return NotFound();
            else
                return View(post);
        }



    }
}
