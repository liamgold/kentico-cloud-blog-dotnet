using System;
using System.Collections.Generic;
using System.Linq;
using Kentico.Kontent.Delivery;

namespace KontentBlog.Models
{
    public class CustomTypeProvider : ITypeProvider
    {
        private static readonly Dictionary<Type, string> _codenames = new Dictionary<Type, string>
        {
            {typeof(Article), "article"},
            {typeof(BlogPost), "blog_post"},
            {typeof(Home), "home"},
        };

        public Type GetType(string contentType)
        {
            return _codenames.Keys.FirstOrDefault(type => GetCodename(type).Equals(contentType));
        }

        public string GetCodename(Type contentType)
        {
            return _codenames.TryGetValue(contentType, out var codename) ? codename : null;
        }
    }
}