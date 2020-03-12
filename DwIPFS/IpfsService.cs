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
        private Task<IpfsResult<string>> ExcuteAsync(RestRequest request)
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
        /// 显示当前节点的账本信息
        /// </summary>
        /// <param name="peerId"></param>
        /// <returns></returns>
        public Task<IpfsResult<BitswapLedgerResult>> BitswapLedgerAsync(string peerId)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapLedger}?arg={peerId}", Method.GET);
            return ExcuteAsync<BitswapLedgerResult>(request);
        }

        /// <summary>
        /// 触发reprovider
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<string>> BitswapReprovideAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapReprovide}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 展示bitswap代理的诊断信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BitswapStatResult>> BitswapStatAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapStat}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<BitswapStatResult>(request);
        }

        /// <summary>
        /// 显示wantlist中的当前块列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BitswapWantListResult>> BitswapWantListAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapWantList}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<BitswapWantListResult>(request);
        }

        /// <summary>
        /// 获取原始IPFS块
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> BlockGetAsync(string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockGet}?arg={hash}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 将输入存储为IPFS块
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BlockPutResult>> BlockPutAsync(string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockPut}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", filePath);
            return ExcuteAsync<BlockPutResult>(request);
        }

        /// <summary>
        /// 将输入存储为IPFS块
        /// </summary>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BlockPutResult>> BlockPutAsync(byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockPut}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ExcuteAsync<BlockPutResult>(request);
        }

        /// <summary>
        /// 移除IPFS块
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BlockRmResult>> BlockRmAsync(string hash, Dictionary<string, object> parameters = null)
        {
            string parameterString = BuildParameterString(parameters);
            if (!string.IsNullOrEmpty(parameterString))
                parameterString = "&" + parameterString;
            RestRequest request = new RestRequest($"{IpfsMethod.BlockRm}?arg={hash}{parameterString}", Method.GET);
            return ExcuteAsync<BlockRmResult>(request);
        }

        /// <summary>
        /// 打印原始块的信息.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<IpfsResult<BlockStatResult>> BlockStatAsync(string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockStat}?arg={hash}", Method.GET);
            return ExcuteAsync<BlockStatResult>(request);
        }

        /// <summary>
        /// 显示或编辑引导列表
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapResult>> BootstrapAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Bootstrap}", Method.GET);
            return ExcuteAsync<BootstrapResult>(request);
        }

        /// <summary>
        /// 添加到引导列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapAddResult>> BootstrapAddAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapAdd}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<BootstrapAddResult>(request);
        }

        /// <summary>
        /// 添加默认节点
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapAddDefaultResult>> BootstrapAddDefaultAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapAddDefault}", Method.GET);
            return ExcuteAsync<BootstrapAddDefaultResult>(request);
        }

        /// <summary>
        /// 展示系统目前连接的所有节点
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapListResult>> BootstrapListAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapList}", Method.GET);
            return ExcuteAsync<BootstrapListResult>(request);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapRmResult>> BootstrapRmAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapRm}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<BootstrapRmResult>(request);
        }

        /// <summary>
        /// 删除所有节点
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<BootstrapRmAllResult>> BootstrapRmAllAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapRmAll}", Method.GET);
            return ExcuteAsync<BootstrapRmAllResult>(request);
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
            RestRequest request = new RestRequest($"{IpfsMethod.Cat}?arg={hash}{parameterString}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 转换CID为Base32版本
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Task<IpfsResult<CidBase32Result>> CidBase32Async(string cid)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidBase32}?arg={cid}", Method.GET);
            return ExcuteAsync<CidBase32Result>(request);
        }

        /// <summary>
        /// 列出可用到多库编码
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<BaseEncoding[]>> CidBasesAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidBases}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<BaseEncoding[]>(request);
        }

        /// <summary>
        /// 列出可用到CID编码器
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<CidCodec[]>> CidCodecsAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidCodecs}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<CidCodec[]>(request);
        }

        /// <summary>
        /// 格式化CID
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<CidFormatResult>> CidFormatAsync(string cid, Dictionary<string, object> parameters = null)
        {
            string parameterString = BuildParameterString(parameters);
            if (!string.IsNullOrEmpty(parameterString))
                parameterString = "&" + parameterString;
            RestRequest request = new RestRequest($"{IpfsMethod.CidFormat}?arg={cid}{parameterString}", Method.GET);
            return ExcuteAsync<CidFormatResult>(request);
        }

        /// <summary>
        /// 列出可用哈希
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<CidHash[]>> CidHashesAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidHashes}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<CidHash[]>(request);
        }

        /// <summary>
        /// 列出所有可用命令
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<Command>> CommandsAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Commands}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<Command>(request);
        }

        /// <summary>
        /// 获取或设置配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<ConfigResult>> ConfigAsync(string key, Dictionary<string, object> parameters = null)
        {
            string parameterString = BuildParameterString(parameters);
            if (!string.IsNullOrEmpty(parameterString))
                parameterString = "&" + parameterString;
            RestRequest request = new RestRequest($"{IpfsMethod.Config}?arg={key}{parameterString}", Method.GET);
            return ExcuteAsync<ConfigResult>(request);
        }

        /// <summary>
        /// 打开配置文件
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<string>> ConfigEditAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigEdit}", Method.GET);
            return ExcuteAsync<string>(request);
        }
    }
}
