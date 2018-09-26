using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Medirec.MessageHandler
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string _apiToken = "736db36f-7d1e-463c-bcec-15f9b1ca77f6";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validKey = false;

            bool checkApiExists = request.Headers.TryGetValues("MedKey", out IEnumerable<string> requestHeader);

            if (checkApiExists)
            {
                if (requestHeader.FirstOrDefault().Equals(_apiToken))
                {
                    validKey = true;
                }
            }
            if (!validKey)
                return request.CreateResponse(HttpStatusCode.Forbidden, "Please contact with Medirec Team");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}