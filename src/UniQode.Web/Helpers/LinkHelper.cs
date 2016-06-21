using System.Text;
using System.Web;

namespace UniQode.Web.Helpers
{
    public class LinkHelper
    {
        //public static IHtmlString ShareOnLinkedIn(string url, string title, string summary)
        //{
        //    var encodedUrl = HttpUtility.UrlEncode(url);
        //    var encodedTitle = HttpUtility.UrlEncode(title);
        //    var encodedSummary = HttpUtility.UrlEncode(summary);

        //    var linkedInUrl = $"https://www.linkedin.com/shareArticle?mini=true&url={encodedUrl}&title={encodedTitle}&summary={encodedSummary}";

        //    return new HtmlString($"<a href='{linkedInUrl}' title='Share on LinkedIn'><i class='fa fa-linkedin'></i> Share on LinkedIn</a>");
        //}

        public static IHtmlString ShareOnLinkedIn(string url)
        {
            //url = HttpUtility.UrlEncode(url);
            var builder = new StringBuilder();

            builder.Append("<script src='//platform.linkedin.com/in.js' type='text/javascript'> lang: en_US </script>");

            builder.AppendFormat("<script type='IN/Share' data-url='{0}' data-counter='none'></script>", url);
            
            return new HtmlString(builder.ToString()); 
        }

        public static IHtmlString ShareOnFacebook(string url)
        {
            var encodedUrl = HttpUtility.UrlEncode(url);
            var builder = new StringBuilder();

            builder.AppendFormat("<div class='fb-share-button' data-href='{0}' data-layout='button' data-mobile-iframe='true'>", url);
            builder.AppendFormat(
                "<a class='fb-xfbml-parse-ignore' target='_blank' href='https://www.facebook.com/sharer/sharer.php?u={0}&src=sdkpreparse'>Share</a>",
                encodedUrl);
            builder.Append("</div>");

            return new HtmlString(builder.ToString());
        }
    }
}