using System.IO;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Util;
using Lucene.Net.QueryParsers.Classic;
using Shop_API.Models.Product;


namespace Shop_API.Services
{
    public class SpecificationSearcher
    {
        private static readonly LuceneVersion _luceneVersion = LuceneVersion.LUCENE_48;
        private readonly Analyzer _analyzer = new StandardAnalyzer(_luceneVersion);
        private readonly Lucene.Net.Store.Directory _luceneIndexDirectory;


        public SpecificationSearcher()
        {
            var indexPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "LuceneIndex");
            _luceneIndexDirectory = FSDirectory.Open(indexPath);
        }

        public List<SearchResultDto> Search(string searchText)
        {
            var results = new List<SearchResultDto>();

            using var reader = DirectoryReader.Open(_luceneIndexDirectory);
            var searcher = new IndexSearcher(reader);

            var parser = new QueryParser(_luceneVersion, "Content", _analyzer);
            var query = parser.Parse(searchText);

            var hits = searcher.Search(query, 20).ScoreDocs;

            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                results.Add(new SearchResultDto
                {
                    Id = int.Parse(foundDoc.Get("Id")),
                    Content = foundDoc.Get("Content"),
                    Score = hit.Score
                });
            }

            return results.OrderByDescending(r => r.Score).ToList();
        }
    }
}