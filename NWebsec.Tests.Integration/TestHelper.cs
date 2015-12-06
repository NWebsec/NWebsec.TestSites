// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;

namespace NWebsec.Tests.Integration
{
    public class TestHelper
    {
        internal Uri GetUri(string baseUri, string path, string query="")
        {
            var absoluteUri = new UriBuilder(baseUri);

            if (absoluteUri.Path.Equals("/")) absoluteUri.Path = path;
            else absoluteUri.Path += path;

            absoluteUri.Query = query;

            return absoluteUri.Uri;
        }

        internal Uri GetHttpsUri(string baseUri, string path, string query = "")
        {
            var absoluteUri = new UriBuilder(baseUri);
            absoluteUri.Scheme = "https";
            absoluteUri.Port = 4444;

            if (absoluteUri.Path.Equals("/")) absoluteUri.Path = path;
            else absoluteUri.Path += path;

            absoluteUri.Query = query;
            return absoluteUri.Uri;
        }
    }
}
