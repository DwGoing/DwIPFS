using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace DwIPFS
{
    public sealed class IPFS
    {
        public readonly IRestClient RequestClient;
        public readonly string Version;

        public IPFS(IRestClient client)
        {
            RequestClient = client;
        }

        public IPFS(string gateway, string version = "v0")
        {
            RequestClient = new RestClient(Path.Combine(gateway, "api", version));
            RequestClient.Authenticator = new SimpleAuthenticator("Username", "", "Password", "");
        }

        public IPFS(string gateway, string username, string password, string version = "v0")
        {
            RequestClient = new RestClient(Path.Combine(gateway, "api", version));
            RequestClient.Authenticator = new SimpleAuthenticator("Username", username, "Password", password);
        }

        public async Task<T> SendRequestAsync<T>(IRestRequest request)
        {
            var response = await RequestClient.ExecuteAsync<T>(request);
            if (!response.IsSuccessful) throw response.ErrorException;
            return response.Data;
        }
    }
}
