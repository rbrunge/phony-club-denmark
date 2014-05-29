using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace PhonyClubDenmark.Website.Models.Pages
{
    public abstract class StandardLayoutPage : SitePageData
    {
        // Frontpage specific
        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_JumbotronContentArea", GroupName = SystemTabNames.Content, Order = 300)]
        [UIHint("OnlyJumbotrons")]
        public virtual ContentArea JumbotronContentArea { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_ContentAreaOne", GroupName = SystemTabNames.Content, Order = 600)]
        public virtual ContentArea ContentAreaOne { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_ContentAreaTwo", GroupName = SystemTabNames.Content, Order = 700)]
        public virtual ContentArea ContentAreaTwo { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_ContentAreaThree", GroupName = SystemTabNames.Content, Order = 800)]
        public virtual ContentArea ContentAreaThree { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_ContentAreaFour", GroupName = SystemTabNames.Content, Order = 900)]
        public virtual ContentArea ContentAreaFour { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "StandardLayoutPage_ContentAreaFive", GroupName = SystemTabNames.Content, Order = 10000)]
        public virtual ContentArea ContentAreaFive { get; set; }
    }
}