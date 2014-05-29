using System;
using System.Linq;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using PhonyClubDenmark.Website.Models;


namespace PhonyClubDenmark.Website.Business.Initialization
{
    /// <summary>
    /// http://world.episerver.com/Forum/Developer-forum/EPiServer-7-Preview/Thread-Container/2012/10/Tabs-and-sort-index/
    /// </summary>
    [InitializableModule]
    public class OrderFormEditTabs : IInitializableModule
    {
        /// <summary>
        /// 
        /// SystemTabNames.Content = SortIndex 10
        /// SystemTabNames.Scheduling = SortIndex 20
        /// SystemTabNames.Settings = SortIndex 30
        /// SystemTabNames.Shortcut = SortIndex 40
        /// SystemTabNames.Categories = SortIndex 50
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(InitializationEngine context)
        {
            RegisterTabs();
        }

        public void Uninitialize(InitializationEngine context)
        {
            // throw new NotImplementedException();
        }

        public void Preload(string[] parameters)
        {
            // throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        private void RegisterTabs()
        {
            var tabDefinitionRepository = ServiceLocator.Current.GetInstance<ITabDefinitionRepository>();

            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                {
                    Name = SystemTabNames.Content,
                    DisplayName = ResourcesModels.Information,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 10
                });

            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                {
                    Name = SystemTabNames.Settings,
                    DisplayName = ResourcesModels.Advanced,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 30
                });

            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                {
                    Name = SystemTabNames.Categories,
                    DisplayName = ResourcesModels.Categories,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 50
                });

            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                {
                    Name = Constants.GroupNames.Labels,
                    DisplayName = ResourcesModels.GroupNames_Labels,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 70
                });

            AddTabToList(tabDefinitionRepository,
               new TabDefinition
                   {
                       Name = Constants.GroupNames.Specialized,
                       DisplayName = ResourcesModels.GroupNames_Specialized,
                       RequiredAccess = AccessLevel.Edit,
                       SortIndex = 100
                   });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Constants.GroupNames.SiteSettings,
                   DisplayName = ResourcesModels.Advanced,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 200
               });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
                   {
                       Name = Constants.GroupNames.Default,
                       DisplayName = ResourcesModels.GroupNames_Default,
                       RequiredAccess = AccessLevel.Edit,
                       SortIndex = 300
                   });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Constants.GroupNames.Header,
                   DisplayName = ResourcesModels.GroupNames_Header,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 400
               });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Constants.GroupNames.Footer,
                   DisplayName = ResourcesModels.GroupNames_Footer,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 500
               });
            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                    {
                        Name = Constants.GroupNames.MetaData,
                        DisplayName = ResourcesModels.GroupNames_Metadata,
                        RequiredAccess = AccessLevel.Edit,
                        SortIndex = 600
                    });
        }

        private void AddTabToList(ITabDefinitionRepository tabDefinitionRepository, TabDefinition definition)
        {

            TabDefinition existingTab = GetExistingTabDefinition(tabDefinitionRepository, definition);
            if (existingTab != null)
            {
                definition.ID = existingTab.ID;
            }
            tabDefinitionRepository.Save(definition);
        }

        private static TabDefinition GetExistingTabDefinition(ITabDefinitionRepository tabDefinitionRepository, TabDefinition definition)
        {

            return tabDefinitionRepository.List()
                                          .FirstOrDefault(
                                          t =>
                                          t.Name.Equals(definition.Name, StringComparison.InvariantCultureIgnoreCase));

        }
    }
}