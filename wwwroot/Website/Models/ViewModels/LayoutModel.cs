using System.Web.Routing;
using EPiServer.Core;

namespace PhonyClubDenmark.Website.Models.ViewModels
{
    public class LayoutModel
    {
        public RouteValueDictionary SearchPageRouteValues { get; set; }
        public bool HideHeader { get; set; }
        public bool HideFooter { get; set; }
        //public LinkItemCollection MenuTopPages { get; set; }
        public PageReference SearchPageLink { get; set; }

        // header
        public string SearchLabel { get; set; }
        public string SearchPlaceholderLabel { get; set; }
        public string LogoAlternativeText { get; set; }

        // footer
        public string PhoneNumber { get; set; }
        public string PhoneNumberLabel { get; set; }
        public string MailAddress { get; set; }
        public string Address { get; set; }
        public string CvrNumber { get; set; }
    }
}