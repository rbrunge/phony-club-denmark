using System.Linq;
using System.Web.Routing;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using PhonyClubDenmark.Website.Helpers;
using PhonyClubDenmark.Website.Models.Pages;
using PhonyClubDenmark.Website.Models.ViewModels;

namespace PhonyClubDenmark.Website.Business
{
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;
        public PageViewContextFactory(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
        }

        public virtual LayoutModel CreateLayoutModel(ContentReference currentContentLink, RequestContext requestContext)
        {
            if (ContentReference.StartPage.ID == 0)
                return null;

            var startPage = _contentLoader.Get<StartPage>(ContentReference.StartPage);

            return new LayoutModel
            {
                // MenuTopPages = startPage.MenuTopPageLinks,
                SearchPageRouteValues = requestContext.GetPageRoute(startPage.SearchPageLink),
                SearchPageLink = startPage.SearchPageLink,

                // header
                SearchLabel = startPage.SearchLabel,
                SearchPlaceholderLabel = startPage.SearchPlaceholderLabel,
                LogoAlternativeText = startPage.LogoAlternativeText,

                // footer
                PhoneNumber = startPage.PhoneNumber,
                PhoneNumberLabel =  startPage.PhoneNumberLabel,
                MailAddress = startPage.MailAddress,
                Address = startPage.Address,
                CvrNumber = startPage.CvrNumber
            };
        }

        public virtual IContent GetSection(ContentReference contentLink)
        {
            var currentContent = _contentLoader.Get<IContent>(contentLink);
            if (currentContent.ParentLink != null && currentContent.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
            {
                return currentContent;
            }

            return _contentLoader.GetAncestors(contentLink)
                .OfType<PageData>()
                .SkipWhile(x => x.ParentLink == null || !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                .FirstOrDefault();
        }
    }
}