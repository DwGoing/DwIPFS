using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using DwIPFS.Extensions;

namespace DwIPFS
{
    public class IpfsService
    {
        public readonly string Url;
        private readonly RestClient _client;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway"></param>
        /// <param name="version"></param>
        public IpfsService(string gateway, string version)
        {
            Url = $"{gateway}api/{version}/";
            _client = new RestClient(Url);
        }

        /// <summary>
        /// 构造参数字符串
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string BuildParameterString(Dictionary<string, object> parameters)
        {
            string parameterString = "";
            if (parameters != null)
                foreach (var item in parameters)
                {
                    parameterString += $"{item.Key}={item.Value}";
                }
            return parameterString;
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Task<IpfsResult<T>> ExcuteAsync<T>(RestRequest request)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var response = await _client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        return new IpfsResult<T>(data: response.Content.ToObject<T>());
                    }
                    else
                    {
                        return new IpfsResult<T>((int)response.StatusCode, response.Content);
                    }
                }
                catch (Exception ex)
                {
                    return new IpfsResult<T>(ResultCode.CommonError, ex.Message);
                }
            });
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<AddResult>> AddAsync(string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Add}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", filePath);
            return ExcuteAsync<AddResult>(request);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<AddResult>> AddAsync(byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Add}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ExcuteAsync<AddResult>(request);
        }

        /// <summary>
        /// 查看内容
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> CatAsync(string hash, Dictionary<string, object> parameters = null)
        {
            string parameterString = BuildParameterString(parameters);
            if (!string.IsNullOrEmpty(parameterString))
                parameterString = "&" + parameterString;
            RestRequest request = new RestRequest($"{IpfsMethod.Cat}?arg={hash}{parameterString}", Method.POST);
            return ExcuteAsync<string>(request);
        }
    }
}
