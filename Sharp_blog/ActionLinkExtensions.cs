using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sharp_blog.Core.Objects;

namespace Sharp_blog
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString PostLink(this HtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Title, "GetPosts", "Blog",
                new
                {
                    year = post.PublishDate.Year,
                    month = post.PublishDate.Month,
                    title = post.UrlSlug
                },
                new
                {
                    title = post.Title
                });
        }

        public static MvcHtmlString CategoryLink(this HtmlHelper helper, Category category)
        {
            return helper.ActionLink(category.Name, "GetCategories", "Blog",
                new
                {
                    category = category.UrlSlug
                },
                new
                {
                    title = $"See all posts in {category.Name}"
                });
        }

        public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "GetTags", "Blog",
                new
                {
                    tag = tag.UrlSlug
                },
                new
                {
                    title = $"See all posts in {tag.Name}"
                });
        }
    }
}