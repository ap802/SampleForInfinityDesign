using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MySMA.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Allows defining a script in a partial view. From http://stackoverflow.com/a/5433722/2551528.
        /// </summary>
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Used to render the scripts defined with Script(), above. From http://stackoverflow.com/a/5433722/2551528.
        /// </summary>
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return MvcHtmlString.Empty;
        }
    }
}