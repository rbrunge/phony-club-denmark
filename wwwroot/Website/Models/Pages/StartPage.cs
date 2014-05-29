using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PhonyClubDenmark.Website.Models.Pages
{
    /// <summary>
    /// Used for the site's start page and also acts as a container for site settings.
    /// </summary>
    [ContentType(DisplayName = "Privat/forsiden", GUID = "{82C8B2B1-26A7-486E-9220-ABDE9F1502ED}",
        GroupName = Constants.GroupNames.Specialized, Description = "")]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability.Specific,
        ExcludeOn = new[] {typeof (ContainerPage)})]
    public class StartPage : CoverLayoutPage
    {
        [Display(ResourceType = typeof (ResourcesModels), Name = "StartPage_MenuTopPageLinks",
            GroupName = Constants.GroupNames.SiteSettings, Order = 350)]
        public virtual LinkItemCollection MenuTopPageLinks { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StartPage_SearchPageLink",
            GroupName = Constants.GroupNames.SiteSettings)]
        public virtual PageReference SearchPageLink { get; set; }

        // Header
        [Display(GroupName = Constants.GroupNames.Header, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_SearchPlaceholderLabel", Order = 120)]
        public virtual string SearchPlaceholderLabel { get; set; }

        [Display(GroupName = Constants.GroupNames.Header, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_HomeBankingReference", Order = 130)]
        public virtual PageReference HomeBankingReference { get; set; }

        [Display(GroupName = Constants.GroupNames.Header, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_HomeBankingButtonText", Order = 130)]
        public virtual string HomeBankingButtonText { get; set; }

        [Display(GroupName = Constants.GroupNames.Header, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_LogoAlternativeText", Order = 140)]
        public virtual string LogoAlternativeText { get; set; }

        [Display(GroupName = Constants.GroupNames.Header, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_SearchLabel", Order = 110)]
        public virtual string SearchLabel { get; set; }

        // Footer
        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_PhoneNumber", Order = 100)]
        public virtual string PhoneNumber { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_PhoneNumberLabel", Order = 105)]
        public virtual string PhoneNumberLabel { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_MailAddress", Order = 110)]
        public virtual string MailAddress { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_Address", Order = 120)]
        [UIHint(UIHint.LongString)]
        public virtual string Address { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_CvrNumber", Order = 130)]
        public virtual string CvrNumber { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_LocalAdvisorPageLink", Order = 140)]
        public virtual PageReference LocalAdvisorPageLink { get; set; }

        [Display(GroupName = Constants.GroupNames.Footer, ResourceType = typeof (ResourcesModels),
            Name = "StartPage_DepartmentPageLink", Order = 160)]
        public virtual PageReference DepartmentPageLink { get; set; }
    }
}