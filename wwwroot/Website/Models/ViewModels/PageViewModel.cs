using EPiServer.Core;
using EPiServer.Web;
using PhonyClubDenmark.Website.Models.Pages;

namespace PhonyClubDenmark.Website.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            TeaserText = currentPage.TeaserText;
            IsInEditMode = EPiServer.Web.Routing.Segments.RequestSegmentContext.CurrentContextMode == ContextMode.Edit;
        }

        public T CurrentPage { get; private set; }
        public LayoutModel Layout { get; set; }
        public IContent Section { get; set; }
        public string TeaserText { get; set; }
        /// <summary>
        /// Returns true if in editing mode
        /// </summary>
        public bool IsInEditMode { get; set; }
    }

    public static class PageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static PageViewModel<T> Create<T>(T page) where T : SitePageData
        {
            return new PageViewModel<T>(page);
        }
    }
}