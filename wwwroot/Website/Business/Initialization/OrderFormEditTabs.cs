using System;
using System.Linq;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using PhonyClubDenmark.Models;

namespace PhonyClubDenmark.Business.Initialization
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
                    DisplayName = ResourceModelProperties.Information,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 2
                });


            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                {
                    Name = Global.GroupNames.Labels,
                    DisplayName = ResourceModelProperties.GroupNames_Labels,
                    RequiredAccess = AccessLevel.Edit,
                    SortIndex = 2
                });

            AddTabToList(tabDefinitionRepository,
               new TabDefinition
                   {
                       Name = Global.GroupNames.Specialized,
                       DisplayName = ResourceModelProperties.GroupNames_Specialized,
                       RequiredAccess = AccessLevel.Edit, 
                       SortIndex = 100
                   });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Global.GroupNames.SiteSettings,
                   DisplayName = ResourceModelProperties.Advanced,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 200
               });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
                   {
                       Name = Global.GroupNames.Default,
                       DisplayName = ResourceModelProperties.GroupNames_Default,
                       RequiredAccess = AccessLevel.Edit, 
                       SortIndex = 300
                   });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Global.GroupNames.Header,
                   DisplayName = ResourceModelProperties.GroupNames_Header,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 400
               });
            AddTabToList(tabDefinitionRepository,
               new TabDefinition
               {
                   Name = Global.GroupNames.Footer,
                   DisplayName = ResourceModelProperties.GroupNames_Footer,
                   RequiredAccess = AccessLevel.Edit,
                   SortIndex = 500
               });
            AddTabToList(tabDefinitionRepository,
                new TabDefinition
                    {
                        Name = Global.GroupNames.MetaData,
                        DisplayName = ResourceModelProperties.GroupNames_Metadata,
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