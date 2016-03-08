using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCatalogProject.CustomHtmlHelpers
{
    public static class CustomHtmlHelper
    {
        public static IHtmlString Image(this IHtmlString helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}