﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core.Parameter;
using SolrExpress.Core.Query;

namespace SolrExpress.Solr5.Parameter
{
    public sealed class OffsetParameter : IOffsetParameter, IParameter<JObject>
    {
        private readonly int _value;

        /// <summary>
        /// Create a offset parameter
        /// </summary>
        /// <param name="value">Value of the parameter limit</param>
        public OffsetParameter(int value)
        {
            this._value = value;
        }

        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = false;

        /// <summary>
        /// Execute the creation of the parameter "offset"
        /// </summary>
        /// <param name="jObject">JSON object with parameters to request to SOLR</param>
        public void Execute(JObject jObject)
        {
            jObject["offset"] = new JValue(_value);
        }
    }
}
