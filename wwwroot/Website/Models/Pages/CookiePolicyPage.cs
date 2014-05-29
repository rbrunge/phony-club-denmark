using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PhonyClubDenmark.Website.Models.Pages
{
    /// <summary>
    /// Used for the site's start page and also acts as a container for site settings.
    /// </summary>
    [ContentType(DisplayName = "Cookiepolitik", GUID = "{B8FD5A98-37FF-49F4-A47B-3154249342BA}",
        GroupName = Constants.GroupNames.Specialized, Description = "")]
    [SiteImageUrl("~/static/images/cookie-policy.png/epi-icon.png")]
    [AvailableContentTypes(Availability.Specific,
        ExcludeOn = new[] {typeof (ContainerPage)})]
    public class CookiePolicyPage : StandardLayoutPage
    {
    }

}