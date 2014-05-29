using EPiServer.DataAbstraction;
using PhonyClubDenmark.Website.Business.Rendering;

namespace PhonyClubDenmark.Website.Models.Pages
{
    [SiteContentType(DisplayName = "Mappe", GUID = "{00551D96-B42A-47C3-908E-89657F7D437E}", GroupName = SystemTabNames.Content, Description = "Bruges til at indeholde andre mapper eller sider som ikke findes i den almindelige struktur")]
    [SiteImageUrl("~/static/images/folder.png/epi-icon.png")]
    public class ContainerPage : SitePageData, IContainerPage
    {

    }
}