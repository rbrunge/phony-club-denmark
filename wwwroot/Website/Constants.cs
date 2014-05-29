namespace PhonyClubDenmark.Website
{
    /// <summary>
    /// Class to hold system-wide constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Names used when grouping properties.
        /// EPiServer uses SystemTabNames, where the following are specified:
        /// - SystemTabNames.Content    (string: Information)
        /// - SystemTabNames.PageHeader (string: EPiServerCMS_SettingsPanel)
        /// - SystemTabNames.Settings   (string: Advanced)
        /// 
        /// For translations use the resource-file: \Models\ResourcesModels.resx 
        /// </summary>
        public static class GroupNames
        {
            public const string SiteSettings = "GroupNames_SiteSettings";
            public const string MetaData = "GroupNames_Metadata";
            public const string Specialized = "GroupNames_Specialized";
            public const string Default = "GroupNames_Default";
            public const string Header = "GroupNames_Header";
            public const string Footer = "GroupNames_Footer";
            public const string Labels = "GroupNames_Labels";
        }
    }
}