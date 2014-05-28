using System.Collections.Generic;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using System.Linq;
using PhonyClubDenmark.Models.Pages;

namespace PhonyClubDenmark.Business
{
   public class SearchService
    {
        private readonly SearchHandler _searchHandler;
        private readonly IContentLoader _contentLoader;
        private readonly ContentSearchHandler _contentSearchHandler;

        public SearchService(SearchHandler searchHandler, IContentLoader contentLoader, ContentSearchHandler contentSearchHandler)
        {
            _searchHandler = searchHandler;
            _contentLoader = contentLoader;
            _contentSearchHandler = contentSearchHandler;
        }

        public virtual bool IsActive
        {
            get { return SearchSettings.Config.Active; }
        }

        public IEnumerable<IContent> SearchIContentData<T>(string keywords) where T : IContentData
        {
            // We'll combine several queries and all must match
            var query = new GroupQuery(LuceneOperator.AND);

            // Only search for content of type T
            query.QueryExpressions.Add(new ContentQuery<T>());

            query.QueryExpressions.Add(new FieldQuery(keywords));

            // Only search for content the current user has permission to read
            var accessQuery = new AccessControlListQuery();
            accessQuery.AddAclForUser(PrincipalInfo.Current, HttpContext.Current);
            query.QueryExpressions.Add(accessQuery);

            // Perform search
            var results = _searchHandler.GetSearchResults(query, 1, int.MaxValue);

            //return new List<T>();

            // Convert search result to pages
            foreach (var item in results.IndexResponseItems)
            {
                yield return _contentSearchHandler.GetContent<IContent>(item);
            };
        }

        public virtual SearchResults Search(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch, int maxResults)
        {
            var query = CreateQuery(searchText, searchRoots, context, languageBranch);
            return _searchHandler.GetSearchResults(query, 1, maxResults);
        }

        private IQueryExpression CreateQuery(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch)
        {
            //Main query which groups other queries. Each query added
            //must match in order for a page or file to be returned.
            var query = new GroupQuery(LuceneOperator.AND);

            //Add free text query to the main query
            query.QueryExpressions.Add(new FieldQuery(searchText));

            //Search for pages using the provided language
            var pageTypeQuery = new GroupQuery(LuceneOperator.AND);
            pageTypeQuery.QueryExpressions.Add(new ContentQuery<SitePageData>());
            //pageTypeQuery.QueryExpressions.Add(new ContentQuery<BlockData>());
            //pageTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));

            var blockTypeQuery = new GroupQuery(LuceneOperator.OR);
            blockTypeQuery.QueryExpressions.Add(new ContentQuery<BlockData>());
            blockTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));
            
            //Search for media without languages
            var contentTypeQuery = new GroupQuery(LuceneOperator.OR);
            contentTypeQuery.QueryExpressions.Add(new ContentQuery<SitePageData>());
            contentTypeQuery.QueryExpressions.Add(pageTypeQuery);
            contentTypeQuery.QueryExpressions.Add(blockTypeQuery);
            query.QueryExpressions.Add(contentTypeQuery);

            //Create and add query which groups type conditions using OR
            var typeQueries = new GroupQuery(LuceneOperator.OR);
            query.QueryExpressions.Add(typeQueries);
            
            foreach (var root in searchRoots)
            {
                var contentRootQuery = new VirtualPathQuery();
                contentRootQuery.AddContentNodes(root, _contentLoader);
                typeQueries.QueryExpressions.Add(contentRootQuery);
            }

            var accessRightsQuery = new AccessControlListQuery();
            accessRightsQuery.AddAclForUser(PrincipalInfo.Current, context);
            query.QueryExpressions.Add(accessRightsQuery);

            return query;
        }
    }
}