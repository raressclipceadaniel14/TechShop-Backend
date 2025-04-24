using System.IO;
using System.Text;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Util;
using Shop_API.Models.Product;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

namespace Shop_API.Services
{
    public class SpecificationIndexer
    {
        private static readonly LuceneVersion _luceneVersion = LuceneVersion.LUCENE_48;

        private readonly string _indexPath; 
        private readonly Lucene.Net.Store.Directory _luceneIndexDirectory;

        private readonly Analyzer _analyzer;

        public SpecificationIndexer()
        {
            _indexPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "LuceneIndex");
            _luceneIndexDirectory = FSDirectory.Open(_indexPath);
            _analyzer = new StandardAnalyzer(_luceneVersion);
        }

        public void IndexSpecifications(List<SpecificationModel> specifications)
        {
            var indexConfig = new IndexWriterConfig(_luceneVersion, _analyzer);
            using var writer = new IndexWriter(_luceneIndexDirectory, indexConfig);

            // Clear previous index (optional)
            writer.DeleteAll();

            foreach (var spec in specifications)
            {
                var doc = new Document
                {
                    new StringField("Id", spec.Id.ToString(), Field.Store.YES),
                    new TextField("Content", spec.Content ?? string.Empty, Field.Store.YES)
                };

                writer.AddDocument(doc);
            }

            writer.Flush(true, true);
        }

        public void IndexSpecificationFromPdf(string pdfFilePath, int id)
        {
            using var pdf = PdfDocument.Open(pdfFilePath);
            var contentBuilder = new StringBuilder();

            foreach (Page page in pdf.GetPages())
            {
                contentBuilder.AppendLine(page.Text);
            }

            string content = contentBuilder.ToString();

            var indexConfig = new IndexWriterConfig(_luceneVersion, _analyzer);
            using var writer = new IndexWriter(_luceneIndexDirectory, indexConfig);

            var doc = new Document
            {
                new StringField("Id", id.ToString(), Field.Store.YES),
                new TextField("Content", content, Field.Store.YES)
            };

            writer.AddDocument(doc);
            writer.Flush(triggerMerge: false, applyAllDeletes: false);
        }
    }
}