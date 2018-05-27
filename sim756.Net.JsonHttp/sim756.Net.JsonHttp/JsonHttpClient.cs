﻿using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using sim756.Net.JsonHttp.Exceptions;

namespace sim756.Net.JsonHttp
{
    public class JsonHttpClient<T>
    {
        public string Url { get; set; }

        public JsonHttpClient()
        {

        }

        public JsonHttpClient(string url)
        {
            this.Url = url;
        }

        public static void Post()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets JSON string from the url.
        /// </summary>
        /// <param name="url">Optional, assign or left "null" to use Url property.</param>
        /// <returns>JSON in string.</returns>
        public string Get(string url = null)
        {
            return new WebClient().DownloadString(url);
        }

        /// <summary>
        /// Gets JSON from the Url Property (otherwise set on url parameter) and returns the deserialized object of type T.
        /// </summary>
        /// <param name="url">Optional, assign or left "null" to use Url property.</param>
        /// <param name="webClient">Customized WebClient or left "null" to use default.</param>
        /// <returns>Deserialized object of type T.</returns>
        public T Deserialize(string url = null, WebClient webClient = null)
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new EmptyUrlException();
            }
            if (webClient == null)
            {
                return JsonConvert.DeserializeObject<T>(new WebClient().DownloadString(Url));
            }
            return JsonConvert.DeserializeObject<T>(webClient.DownloadString(Url));

            //return default(T);
        }

        public static TDeserialize Deserialize<TDeserialize>(string url)
        {

            return default(TDeserialize);
        }
    }
}