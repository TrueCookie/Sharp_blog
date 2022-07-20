using System.Collections.Generic;
using Sharp_blog.Core.Objects;

namespace Sharp_blog.Core.DAL
{
    public interface IBlogRepository
    {
        IList<Post> GetPosts(int pageNo, int pageSize);
        int GetPostCount();
    }
}