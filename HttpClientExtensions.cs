#if NETSTANDARD2_0
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TursoPlatformApi
{
    internal static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            return client.PatchAsync(new Uri(requestUri), content);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content)
        {
            return client.PatchAsync(requestUri, content, CancellationToken.None);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return client.PatchAsync(new Uri(requestUri), content, cancellationToken);
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = content
            };

            return client.SendAsync(request, cancellationToken);
        }
    }
}
#endif
