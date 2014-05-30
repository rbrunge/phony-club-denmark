using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PhonyClubDenmark.Website.Models.Pages
{
    [ContentType(AvailableInEditMode = false)]
    public  class CoverLayoutPage : SitePageData
    {
        [Display(ResourceType = typeof(ResourcesModels), Name = "CoverLayoutPage_BackgroundImage",
            GroupName = SystemTabNames.Content, Order = 500)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [Display(ResourceType = typeof(ResourcesModels), Name = "CoverLayoutPage_CallToActionLink",
            GroupName = SystemTabNames.Content, Order = 600)]
        public virtual Url CallToActionLink { get; set; }

        [Display(ResourceType = typeof(ResourcesModels), Name = "CoverLayoutPage_CallToActionLink_Label", GroupName = SystemTabNames.Content, Order = 700)]
        public virtual string CallToActionLabel { get; set; }

    }
}