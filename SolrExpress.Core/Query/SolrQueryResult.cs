﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core.Builder;
using SolrExpress.Core.Entity;
using SolrExpress.Core.Exception;
using SolrExpress.Core.Helper;
using System;

namespace SolrExpress.Core.Query
{
    /// <summary>
    /// SOLR query result with fluent API
    /// </summary>
    public class SolrQueryResult<TDocument>
        where TDocument : IDocument
    {
        private readonly string _jsonPlainText;
        private JObject _jsonObject;

        /// <summary>
        /// Factory used to resolve builder creation in Linq facilities
        /// </summary>
        protected internal IBuilderFactory<TDocument> BuilderFactory { get; private set; }

        /// <summary>
        /// Default constructor of the class
        /// </summary>
        /// <param name="builderFactory">Factory used to resolve builder creation in Linq facilities</param>
        /// <param name="json">Result of the SOLR</param>
        public SolrQueryResult(IBuilderFactory<TDocument> builderFactory, string json)
        {
            ThrowHelper<ArgumentNullException>.If(builderFactory == null);
            ThrowHelper<ArgumentNullException>.If(string.IsNullOrWhiteSpace(json));

            this.BuilderFactory = builderFactory;
            this._jsonPlainText = json;
        }

        /// <summary>
        /// Get a instance of the informed type with parsed json resulted from the search
        /// </summary>
        /// <typeparam name="T">Concrete class that implements the IResultBuilder interface</typeparam>
        /// <returns>Instance of T ready to be used</returns>
        public T Get<T>(T builder)
            where T : IResultBuilder
        {
            if (builder is IConvertJsonObject)
            {
                this._jsonObject = this._jsonObject ?? JObject.Parse(this._jsonPlainText);

                ((IConvertJsonObject)builder).Execute(this._jsonObject);
            }
            else if (builder is IConvertJsonPlainText)
            {
                ((IConvertJsonPlainText)builder).Execute(this._jsonPlainText);
            }
            else
            {
                throw new UnknownResolveResultBuilderException(builder.GetType().Name);
            }

            return builder;
        }
    }
}
