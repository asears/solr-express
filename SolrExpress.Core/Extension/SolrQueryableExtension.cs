﻿using SolrExpress.Core.Entity;
using SolrExpress.Core.Enumerator;
using SolrExpress.Core.ParameterValue;
using SolrExpress.Core.Query;
using System;
using System.Linq.Expressions;

namespace SolrExpress.Core.Extension
{
    public static class SolrQueryableExtension
    {

        /// <summary>
        /// Create a facet field parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="sortType">Sort type of the result of the facet</param>
        public static SolrQueryable<TDocument> FacetField<TDocument>(this SolrQueryable<TDocument> queryable, Expression<Func<TDocument, object>> expression, SolrFacetSortType? sortType = null)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetFacetFieldParameter(expression, sortType));
        }

        /// <summary>
        /// Create a facet query parameter
        /// </summary>
        /// <param name="aliasName">Name of the alias added in the query</param>
        /// <param name="query">Query used to make the facet</param>
        /// <param name="sortType">Sort type of the result of the facet</param>
        public static SolrQueryable<TDocument> FacetQuery<TDocument>(this SolrQueryable<TDocument> queryable, string aliasName, IQueryParameterValue query, SolrFacetSortType? sortType = null)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetFacetQueryParameter(aliasName, query, sortType));
        }

        /// <summary>
        /// Create a facet range parameter
        /// </summary>
        /// <param name="aliasName">Name of the alias added in the query</param>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="gap">Size of each range bucket to make the facet</param>
        /// <param name="start">Lower bound to make the facet</param>
        /// <param name="end">Upper bound to make the facet</param>
        /// <param name="sortType">Sort type of the result of the facet</param>
        public static SolrQueryable<TDocument> FacetRange<TDocument>(this SolrQueryable<TDocument> queryable, string aliasName, Expression<Func<TDocument, object>> expression, string gap = null, string start = null, string end = null, SolrFacetSortType? sortType = null)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetFacetRangeParameter(aliasName, expression, gap, start, end, sortType));
        }

        /// <summary>
        /// Create a fields parameter
        /// </summary>
        /// <param name="expressions">Expression used to find the property name</param>
        public static SolrQueryable<TDocument> Fields<TDocument>(this SolrQueryable<TDocument> queryable, params Expression<Func<TDocument, object>>[] expressions)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetFieldsParameter(expressions));
        }

        /// <summary>
        /// Create a filter parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="value">Value of the filter</param>
        public static SolrQueryable<TDocument> Filter<TDocument>(this SolrQueryable<TDocument> queryable, Expression<Func<TDocument, object>> expression, string value)
            where TDocument : IDocument
        {
            var paramaterValue = new Single<TDocument>(expression, value);
            return queryable.Parameter(queryable.ParamaterFactory.GetFilterParameter(paramaterValue));
        }

        /// <summary>
        /// Create a filter parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="from">From value in a range filter</param>
        /// <param name="to">To value in a range filter</param>
        public static SolrQueryable<TDocument> Filter<TDocument, TValue>(this SolrQueryable<TDocument> queryable, Expression<Func<TDocument, object>> expression, TValue? from, TValue? to)
            where TDocument : IDocument
            where TValue : struct
        {
            var value = new Range<TDocument, TValue>(expression, from, to);
            return queryable.Parameter(queryable.ParamaterFactory.GetFilterParameter(value));
        }

        /// <summary>
        /// Create a limit parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public static SolrQueryable<TDocument> Limit<TDocument>(this SolrQueryable<TDocument> queryable, int value)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetLimitParameter(value));
        }

        /// <summary>
        /// Create a offset parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public static SolrQueryable<TDocument> Offset<TDocument>(this SolrQueryable<TDocument> queryable, int value)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetOffsetParameter(value));
        }

        /// <summary>
        /// Create a query parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public static SolrQueryable<TDocument> Query<TDocument>(this SolrQueryable<TDocument> queryable, IQueryParameterValue value)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetQueryParameter(value));
        }

        /// <summary>
        /// Create a query parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public static SolrQueryable<TDocument> Query<TDocument>(this SolrQueryable<TDocument> queryable, string value)
            where TDocument : IDocument
        {
            var freeValue = new Any(value);
            return queryable.Parameter(queryable.ParamaterFactory.GetQueryParameter(freeValue));
        }

        /// <summary>
        /// Create a query parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="value">Value of the query</param>
        public static SolrQueryable<TDocument> Query<TDocument>(this SolrQueryable<TDocument> queryable, Expression<Func<TDocument, object>> expression, string value)
            where TDocument : IDocument
        {
            var paramaterValue = new Single<TDocument>(expression, value);
            return queryable.Parameter(queryable.ParamaterFactory.GetQueryParameter(paramaterValue));
        }

        /// <summary>
        /// Create a sort parameter
        /// </summary>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="ascendent">True to ascendent order, otherwise false</param>
        public static SolrQueryable<TDocument> Sort<TDocument>(this SolrQueryable<TDocument> queryable, Expression<Func<TDocument, object>> expression, bool ascendent)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetSortParameter(expression, ascendent));
        }

        /// <summary>
        /// Create a facet limit parameter
        /// </summary>
        /// <param name="value">Parameter to include in the query</param>
        public static SolrQueryable<TDocument> FacetLimit<TDocument>(this SolrQueryable<TDocument> queryable, int value)
            where TDocument : IDocument
        {
            return queryable.Parameter(queryable.ParamaterFactory.GetFacetLimitParameter(value));
        }
    }
}
