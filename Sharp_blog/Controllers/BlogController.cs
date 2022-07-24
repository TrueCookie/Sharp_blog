using System;
using System.Web.Mvc;
using Sharp_blog.Core.DAL;
using Sharp_blog.Models;

namespace Sharp_blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ViewResult GetPosts(int pageNo = 1)
        {
            var listViewModel = new ListViewModel(_blogRepository, pageNo);

            ViewBag.Title = "Latest Posts";
            return View("List", listViewModel);
        }


        public ActionResult GetCategories(string category)
        {
            throw new NotImplementedException();
        }

        public ActionResult GetTags(string tag)
        {
            throw new NotImplementedException();
        }
    }
}