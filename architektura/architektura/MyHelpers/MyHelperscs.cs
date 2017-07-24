using System.Web.Mvc;

namespace MyHelpers.MyHelpers
{
    public static class MyHelpers
    {
        public static MvcHtmlString AddPicture(string src, string alt, int width, string data_src)
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("width", width.ToString());
            imageTag.MergeAttribute("data-src", data_src);

            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
