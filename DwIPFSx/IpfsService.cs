using System;
using System.Threading.Tasks;
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
        /// 执行请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> ExcuteAsync(RestRequest request)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var response = await _client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        return new IpfsResult<string>(data: response.Content);
                    }
                    else
                    {
                        return new IpfsResult<string>((int)response.StatusCode, response.Content);
                    }
                }
                catch (Exception ex)
                {
                    return new IpfsResult<string>(ResultCode.CommonError, ex.Message);
                }
            });
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<IpfsResult<T>> ExcuteAsync<T>(RestRequest request)
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
        /// 执行请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="resultHandle"></param>
        /// <returns></returns>
        public Task<IpfsResult<T>> ExcuteAsync<T>(RestRequest request, Func<string, T> resultHandle)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var response = await _client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        return new IpfsResult<T>(data: resultHandle(response.Content));
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
    }
}
