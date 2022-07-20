using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Sharp_blog.Core.Objects;

namespace Sharp_blog.Core.DAL
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        //TODO: try to construct single SQL statement to handle this
        public IList<Post> GetPosts(int pageNo, int pageSize)
        {
            var postIds = _session.Query<Post>()
                .Where(p => p.IsPublished)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Fetch(p => p.Category)
                .Select(p => p.Id)
                .ToList();

            return _session.Query<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PublishDate)
                .FetchMany(p => p.Tags)
                .ToList();
        }

        public int GetPostCount()
        {
            return _session
                .Query<Post>()
                .Count(p => p.IsPublished);
        }
    }
}