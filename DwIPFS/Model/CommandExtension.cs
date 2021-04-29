using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace DwIPFS
{
    public static class CommandExtension
    {
        public static Task<AddResult> AddAsync(this IPFS ipfs, string file, Dictionary<string, object> arguments = null)
        {
            var url = "/add";
            if (arguments != null) url += "?" + string.Join('&', arguments.Select(item => $"{item.Key}={item.Value}"));
            var request = new RestRequest(url, Method.POST);
            request.AddFile("arg", file);
            return ipfs.SendRequestAsync<AddResult>(request);
        }
    }
}