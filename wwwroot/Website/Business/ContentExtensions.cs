using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PhonyClubDenmark.Website.Business
{
    /// <summary>
    /// Extension methods for content
    /// </summary>
    public static class ContentExtensions
    {
        /// <summary>
        /// Shorthand for DataFactory.Instance.Get
        /// </summary>
        /// <typeparam name="TContent"></typeparam>
        /// <param name="contentLink"></param>
        /// <returns></returns>
        public static IContent Get<TContent>(this ContentReference contentLink) where TContent : IContent
        {
            return DataFactory.Instance.Get<TContent>(contentLink);
        }

        /// <summary>
        /// Filters content which should not be visible to the user. 
        /// </summary>
        public static IEnumerable<T> FilterForDisplay<T>(this IEnumerable<T> contents, bool requirePageTemplate = false, bool requireVisibleInMenu = false)
            where T : IContent
        {
            var accessFilter = new FilterAccess();
            var publishedFilter = new FilterPublished(ServiceLocator.Current.GetInstance<IContentRepository>());
            contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));
            if (requirePageTemplate)
            {
                var templateFilter = ServiceLocator.Current.GetInstance<FilterTemplate>();
                templateFilter.TemplateTypeCategories = TemplateTypeCategories.Page;
                contents = contents.Where(x => !templateFilter.ShouldFilter(x));
            }
            if (requireVisibleInMenu)
            {
                contents = contents.Where(x => VisibleInMenu(x));
            }
            return contents;
        }

        private static bool VisibleInMenu(IContent content)
        {
            var page = content as PageData;
            if (page == null)
            {
                return true;
            }
            return page.VisibleInMenu;
        }

        /// <summary>
        /// http://joelabrahamsson.com/convert-a-linkitemcollection-to-a-list-of-pagedata/
        /// </summary>
        /// <param name="linkItemCollection"></param>
        /// <returns></returns>
        public static List<PageData> ToPages(this LinkItemCollection linkItemCollection)
        {
            var pages = new List<PageData>();

            foreach (LinkItem linkItem in linkItemCollection)
            {
                string linkUrl;
                if (!PermanentLinkMapStore.TryToMapped(linkItem.Href, out linkUrl))
                    continue;

                if (string.IsNullOrEmpty(linkUrl))
                    continue;

                PageReference pageReference = PageReference.ParseUrl(linkUrl);

                if (PageReference.IsNullOrEmpty(pageReference))
                    continue;

                pages.Add(DataFactory.Instance.GetPage((pageReference)));
            }

            return pages;
        }
    }
}