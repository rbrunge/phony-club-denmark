using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PhonyClubDenmark.Website.Models.Blocks
{
    /// <summary>
    /// Used for a primary message on a page, commonly used on start pages and landing pages
    /// </summary>
    [SiteContentType(
        DisplayName = "Jumbotron",
        GroupName = Constants.GroupNames.Specialized,
        GUID = "{A9EED97B-84A6-4C50-88FA-01E956C70F33}")]
    [SiteImageUrl]
    public class JumbotronBlock : SiteBlockData
    {
        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_Image", GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_ImageRetina_Billede", GroupName = SystemTabNames.Content, Order = 200)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ImageRetina { get; set; }

        /// <summary>
        /// Gets or sets a description for the image, for example used as the alt text for the image when rendered
        /// </summary>
        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_ImageDescription", GroupName = SystemTabNames.Content,Order = 300)]
        [UIHint(UIHint.LongString)]
        public virtual string ImageDescription
        {
            get
            {
                var propertyValue = this["ImageDescription"] as string;

                // Return image description with fall back to the heading if no description has been specified
                return string.IsNullOrWhiteSpace(propertyValue) ? Heading : propertyValue;
            }
            set { this["ImageDescription"] = value; }
        }

        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_Heading", GroupName = SystemTabNames.Content,Order = 400)]
        public virtual string Heading { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_SubHeading", GroupName = SystemTabNames.Content,Order = 500)]
        [UIHint(UIHint.Textarea)]
        public virtual string SubHeading { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_ButtonLink", GroupName = SystemTabNames.Content, Order = 550)]
        public virtual Url ButtonLink { get; set; }

        [Display(ResourceType = typeof (ResourcesModels), Name = "JumbotronBlock_ButtonText", GroupName = SystemTabNames.Content, Order = 600)]
        public virtual string ButtonText { get; set; }    }
}