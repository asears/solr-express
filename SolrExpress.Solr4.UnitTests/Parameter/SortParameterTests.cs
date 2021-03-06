﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolrExpress.Solr4.Parameter;
using System;
using System.Collections.Generic;

namespace SolrExpress.Solr4.UnitTests.Parameter
{
    [TestClass]
    public class SortParameterTests
    {
        /// <summary>
        /// Where   Using a SortParameter instance
        /// When    Invoking the method "Execute"
        /// What    Create a valid string
        /// </summary>
        [TestMethod]
        public void SortParameter001()
        {
            // Arrange
            var container = new List<string>();
            var parameter = new SortParameter<TestDocument>(q => q.Id, true);

            // Act
            parameter.Execute(container);

            // Assert
            Assert.AreEqual(1, container.Count);
            Assert.AreEqual("sort=Id asc", container[0]);
        }

        /// <summary>
        /// Where   Using a SortParameter instance
        /// When    Create the instance with null
        /// What    Throws ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortParameter002()
        {
            // Arrange / Act / Assert
            new SortParameter<TestDocument>(null, true);
        }
    }
}
