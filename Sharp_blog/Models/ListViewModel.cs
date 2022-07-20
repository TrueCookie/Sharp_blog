using System.Collections.Generic;
using Sharp_blog.Core.DAL;
using Sharp_blog.Core.Objects;

namespace Sharp_blog.Models
{
    public class ListViewModel
    {
        private const int DefaultPagesize = 10;

        public ListViewModel(IBlogRepository blogRepository, int pageNo)
        {
            Posts = blogRepository.GetPosts(pageNo - 1, DefaultPagesize);
            PostCount = blogRepository.GetPostCount();
        }
        
        public IList<Post> Posts { get; private set; }
        public int PostCount { get; private set; }
    }
}