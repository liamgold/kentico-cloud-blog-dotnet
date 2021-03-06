﻿using KontentBlog.Models;
using Kentico.Kontent.Delivery;
using System.Globalization;

namespace KontentBlog
{
    public class CustomContentLinkUrlResolver : IContentLinkUrlResolver
    {
        protected string CurrentCulture => CultureInfo.CurrentUICulture.Name;

        public string ResolveLinkUrl(ContentLink link)
        {
            switch (link.ContentTypeCodename)
            {
                case Article.Codename:
                    return $"/{CurrentCulture}/articles/{link.UrlSlug}";
                case BlogPost.Codename:
                    return $"/{CurrentCulture}/blog/{link.UrlSlug}";
                case Home.Codename:
                    return $"/{CurrentCulture}/";
                default:
                    return $"/not_found";
            }
        }

        public string ResolveBrokenLinkUrl()
        {
            return $"/broken_link";
        }
    }
}