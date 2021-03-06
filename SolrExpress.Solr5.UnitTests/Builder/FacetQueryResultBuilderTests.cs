﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SolrExpress.Solr5.Builder;

namespace SolrExpress.Solr5.UnitTests.Builder
{
    [TestClass]
    public class FacetQueryResultBuilderTests
    {
        /// <summary>
        /// Where   Using a FacetQueryResultBuilder instance
        /// When    Invoking the method "Execute" using a valid JSON
        /// What    Parse to informed concret classes
        /// </summary>
        [TestMethod]
        public void FacetQueryResultBuilder001()
        {
            // Arrange
            var jObject = JObject.Parse(@"
            {
                ""facets"": {
                    ""count"": 100,
                    ""facetQuery"": {
                      ""count"": 10
                    }
                }
            }");

            var parameter = new FacetQueryResultBuilder<TestDocument>();

            // Act
            parameter.Execute(jObject);

            // Assert
            Assert.AreEqual(1, parameter.Data.Count);
            Assert.IsTrue(parameter.Data.ContainsKey("facetQuery"));
            Assert.AreEqual(10, parameter.Data["facetQuery"]);
        }
    }
}
