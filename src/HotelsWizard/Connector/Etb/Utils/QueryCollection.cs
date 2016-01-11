using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.Collections;

namespace HotelsWizard.Connector.Etb.Utils
{
    public class QueryCollection : IReadableStringCollection
    {
        public static readonly IReadableStringCollection Empty = new QueryCollection(new Dictionary<string, StringValues>(0));

        /// <summary>
        /// Create a new wrapper
        /// </summary>
        /// <param name="store"></param>
        public QueryCollection(IDictionary<string, StringValues> store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            Store = store;
        }

        /// <summary>
        /// Create a new wrapper from existing collection
        /// </summary>
        /// <param name="collection"></param>
        public QueryCollection(IReadableStringCollection collection) : this()
        {
            foreach (var item in collection)
            {
                Store.Add(item.Key, item.Value);
            }
        }

        public QueryCollection()
        {
            Store = new Dictionary<string, StringValues>();
        }

        private IDictionary<string, StringValues> Store { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get { return Store.Count; }
        }

        /// <summary>
        /// Gets a collection containing the keys.
        /// </summary>
        public ICollection<string> Keys
        {
            get { return Store.Keys; }
        }


        /// <summary>
        /// Get the associated value from the collection.  Multiple values will be merged.
        /// Returns StringValues.Empty if the key is not present.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public StringValues this[string key]
        {
            get
            {
                StringValues value;
                if (Store.TryGetValue(key, out value))
                {
                    return value;
                }
                return StringValues.Empty;
            }
            set
            {
                Store[key] = value;
            }
        }

        public void Add(string key, StringValues value)
        {
            Store.Add(key, value);
        }

        /// <summary>
        /// Determines whether the collection contains an element with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return Store.ContainsKey(key);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var first = true;
            foreach (var item in Store)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append("&");
                }
                builder.Append(WebUtility.UrlEncode(item.Key));
                builder.Append("=");
                builder.Append(WebUtility.UrlEncode(item.Value));
            }


            return builder.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
        {
            return Store.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
