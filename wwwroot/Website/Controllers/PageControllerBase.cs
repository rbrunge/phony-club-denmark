using EPiServer.Web.Mvc;
using PhonyClubDenmark.Website.Business;
using PhonyClubDenmark.Website.Models.Pages;
using PhonyClubDenmark.Website.Models.ViewModels;

namespace PhonyClubDenmark.Website.Controllers
{
    /// <summary>
    /// All controllers that renders pages should inherit from this class so that we can 
    /// apply action filters, such as for output caching site wide, should we want to.
    /// </summary>
    public abstract class PageControllerBase<T> : PageController<T>, IModifyLayout  where T : SitePageData
    {
        public virtual void ModifyLayout(LayoutModel layoutModel)
        {
            var page = PageContext.Page as SitePageData;
            if (page != null)
            {

            }
        }

    }
}