using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace PhonyClubDenmark.Website.Helpers
{
    public class CustomPngHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        protected RequestContext RequestContext { get; set; }

        public CustomPngHandler()
        {
            
        }

        public CustomPngHandler(RequestContext requestContext)
        {
            RequestContext = requestContext;
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            // if background image is missing, leave
            var fileNameBack = context.Server.MapPath("~/static/images/contenttype-background.png");
            if (!File.Exists(fileNameBack))
                return;

            var regEx = new System.Text.RegularExpressions.Regex("static/images/(.*)/epi-icon.png");
            if (!regEx.IsMatch(context.Request.RawUrl))
                return;

            var found = regEx.Match(context.Request.RawUrl).Groups[1].Value;
            var fileNameFore = context.Server.MapPath(System.IO.Path.Combine("~/static/images/", found));
            if (!File.Exists(fileNameFore))
            {
                ImageHelper.ImageWithText(found + ".png is missing", 120, 90, context);
                return;
            }

            var imageBackGround = Image.FromFile(fileNameBack);
            var imageForeGround = Image.FromFile(fileNameFore);

            ImageHelper.MergeImages(imageBackGround, imageForeGround, context);
        }
    }
}