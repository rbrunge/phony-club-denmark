using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using PhonyClubDenmark.Website.Models.Pages;
using PhonyClubDenmark.Website.Models.ViewModels;

namespace PhonyClubDenmark.Website.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            // Check if it is the StartPage or just a page of the StartPage type.
            if (ContentReference.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink)) 
            {
                //Connect the view models logotype property to the start page's to make it editable
                // var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                // editHints.AddConnection(m => m.Layout.MenuTopPages, p => p.MenuTopPageLinks);
            }

            return View(model);
        }

    }
}