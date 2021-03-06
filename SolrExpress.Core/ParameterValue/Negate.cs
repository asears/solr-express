﻿using SolrExpress.Core.Helper;
using SolrExpress.Core.Query;
using System;

namespace SolrExpress.Core.ParameterValue
{
    /// <summary>
    /// Result negative form (NOT) value parameter
    /// </summary>
    public sealed class Negate : IQueryParameterValue
    {
        private readonly IQueryParameterValue _value;

        /// <summary>
        /// Create a negative form (NOT) from informed parameter value
        /// </summary>
        /// <param name="parameterValue">Paramater value used to created negative form</param>
        public Negate(IQueryParameterValue parameterValue)
        {
            ThrowHelper<ArgumentNullException>.If(parameterValue == null);

            this._value = parameterValue;
        }

        /// <summary>
        /// Execute parameter value generator
        /// </summary>
        /// <returns>Result generated value</returns>
        public string Execute() => $"-{_value.Execute()}";
    }
}