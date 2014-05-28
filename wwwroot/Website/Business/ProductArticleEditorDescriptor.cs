using System;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using PhonyClubDenmark.Models.Pages;

namespace PhonyClubDenmark.Business
{
    [EditorDescriptorRegistration(TargetType = typeof(ContentArea), UIHint = "ProductArticles")]
    public class ProductArticleEditorDescriptor : EditorDescriptor
    {
        public ProductArticleEditorDescriptor()
        {
            // Setup the types that are allowed to be dragged and dropped into the content        
            // area; in this case only images are allowed to be added.        
            AllowedTypes = new Type[] { typeof(ProductArticlePage) };

            // Unfortunetly the ContentAreaEditorDescriptor is located in the CMS module        
            // and thus can not be inherited from; these settings are copied from that        
            // descriptor. These settings determine which editor and overlay should be        
            // used by this property in edit mode.        
            ClientEditingClass = "epi-cms.contentediting.editors.ContentAreaEditor"; 
            OverlayConfiguration.Add("customType", "epi-cms.widget.overlay.ContentArea");
        }
    }
}
