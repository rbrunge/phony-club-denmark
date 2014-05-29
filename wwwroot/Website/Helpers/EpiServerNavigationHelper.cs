using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using PhonyClubDenmark.Website.Business;

namespace PhonyClubDenmark.Website.Helpers
{
    public static class EpiServerNavigationHelper
    {
        /// <summary>
        /// Ebita - extention
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool HasChildren(this PageData page)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            return contentLoader.GetChildren<PageData>(page.PageLink).ToRawPageArray().Length > 0;
        }

        /// <summary>
        /// Ebita - extention
        /// </summary>
        /// <param name="page"></param>
        /// <param name="onlyVisibleToMenu"></param>
        /// <returns></returns>
        public static IEnumerable<PageData> GetPageChildren(this PageData page, bool onlyVisibleToMenu = false)
        {
            return GetPageChildren(page.PageLink, onlyVisibleToMenu);
        }


        public static IEnumerable<PageData> GetPageChildren(PageReference reference, bool onlyVisibleToMenu = false)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            if (onlyVisibleToMenu)
            {
                var unfiltered = contentLoader.GetChildren<PageData>(reference);
                var pageDatas = unfiltered as IList<PageData> ?? unfiltered.ToList();
                if (unfiltered != null && pageDatas.Any())
                {
                    var l = pageDatas.FilterForDisplay(true, true);
                    //// .Filter(new FilterPublished(PagePublishedStatus.Published))
                    //.Where(x => !x.IsDeleted 
                    //    && x.VisibleInMenu 
                    //    && x.CheckPublishedStatus(PagePublishedStatus.Published)
                    //    //&& x.StartPublish < DateTime.Now
                    //    );
                    return l;
                }
            }

            return contentLoader.GetChildren<PageData>(reference);
        }

        /// <summary>
        /// Gets a collection of links for all children to a given page. 
        /// It returns only visible links, which means:
        /// - not deleted
        /// - published
        /// </summary>
        /// <param name="pageLink"></param>
        /// <returns></returns>
        public static LinkItemCollection GetLinkCollectionChildren(PageReference pageLink)
        {
            LinkItemCollection result = null;
            var children = DataFactory.Instance.GetChildren(pageLink);
            if (children != null && children.Count > 0)
            {
                result = new LinkItemCollection();
                foreach (var page in children.Where(x => !x.IsDeleted && x.VisibleInMenu && x.CheckPublishedStatus(PagePublishedStatus.Published))
                        .OrderByDescending(x => x.StartPublish))
                {
                    result.Add(
                        new LinkItem
                        {
                            Href = page.LinkURL,
                            Text = page.PageName,
                            Target = "",
                            Title = page.PageName,
                        });
                }
            }
            return result;
        }

    }
}