using System.Linq;
using System.Security.Cryptography.X509Certificates;
using figo;
using Hackathon.FigoApi.Interfaces;

namespace Hackathon.FigoApi.Providers
{
    public class FigoSessionProvider : IFigoSessionProvider
    {
        private readonly string[] _validCertificates = new string[]
        {
            "38AE4A326F16EA1581338BB0D8E4A635E727F107",
            "DBE2E9158FC9903084FE36CAA61138D85A205D93"
        };

        public FigoSession GetFigoSession()
        {
            FigoSession session = new FigoSession
            {
                AccessToken = "ASHWLIkouP2O6_bgA2wWReRhletgWKHYjLqDaqb0LFfamim9RjexTo22ujRIP_cjLiRiSyQXyt2kM1eXU2XLFZQ0Hro15HikJQT_eNeT_9XQ",
                // the same as default one here, but can be modified for testing purposes
                ApiEndpoint = "https://api.figo.me",
                OnRequestInitialize = (request) =>
                {
                    // figo.net is portable, not all of the platforms have a support for ServerCertificateValidationCallback
                    // that's why check certificate on the client side 
                    request.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => {
                        X509Certificate x509Certificate = cert;
                        return _validCertificates.Contains(x509Certificate.GetCertHashString());
                    };
                }
            };

            return session;
        }
    }
}
