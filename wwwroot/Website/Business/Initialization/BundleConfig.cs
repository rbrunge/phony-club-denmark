using System.Web.Optimization;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace PhonyClubDenmark.Business.Initialization
{
    [InitializableModule]
    public class BundleConfig : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                RegisterBundles(BundleTable.Bundles);
            }
        }

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-*", //jquery.js can be removed and linked from CDN instead, we use a local one for demo purposes without internet connectionzz
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                // .Include("~/Content/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css"));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}