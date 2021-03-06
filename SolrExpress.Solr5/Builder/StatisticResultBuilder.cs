﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core.Builder;
using SolrExpress.Core.Entity;
using SolrExpress.Core.Exception;
using SolrExpress.Core.Query;
using System;

namespace SolrExpress.Solr5.Builder
{
    /// <summary>
    /// Statistic data builder
    /// </summary>
    public sealed class StatisticResultBuilder<TDocument> : IStatisticResultBuilder<TDocument>, IConvertJsonObject
        where TDocument : IDocument
    {
        /// <summary>
        /// Execute the statistic parse of the json
        /// </summary>
        /// <param name="jsonObject">JSON object used in the parse</param>
        public void Execute(JObject jsonObject)
        {
            if (jsonObject["response"]?["numFound"] != null && jsonObject["responseHeader"]?["QTime"] != null)
            {
                var qTime = jsonObject["responseHeader"]["QTime"].ToObject<int>();
                var documentCount = jsonObject["response"]["numFound"].ToObject<long>();

                this.Data = new Statistic
                {
                    DocumentCount = documentCount,
                    IsEmpty = documentCount.Equals(0),
                    ElapsedTime = new TimeSpan(0, 0, 0, 0, qTime)
                };

                return;
            }

            throw new UnexpectedJsonFormatException(jsonObject.ToString());
        }

        /// <summary>
        /// Facet data
        /// </summary>
        public Statistic Data { get; set; }
    }
}
