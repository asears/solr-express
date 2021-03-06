﻿using SolrExpress.Core.Attribute;
using SolrExpress.Core.Entity;

namespace SolrExpress.Solr4.UnitTests
{
    public class TestDocumentWithAttribute : IDocument
    {
        [SolrField("Indexed", Indexed = true)]
        public string Indexed { get; set; }

        [SolrField("NotIndexed", Indexed = false)]
        public string NotIndexed { get; set; }

        [SolrField("Stored", Stored = true)]
        public string Stored { get; set; }

        [SolrField("NotStored", Stored = false)]
        public string NotStored { get; set; }
    }
}
