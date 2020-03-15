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
        /// <param name="isFirst"></param>
        /// <returns></returns>
        private string BuildParameterString(Dictionary<string, object> parameters, bool isFirst = true)
        {
            string parameterString = "";
            if (parameters != null)
                foreach (var item in parameters)
                {
                    parameterString += $"{item.Key}={item.Value}";
                }
            if (!string.IsNullOrEmpty(parameterString) && !isFirst)
                parameterString = "&" + parameterString;
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
        /// 执行请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="resultHandle"></param>
        /// <returns></returns>
        private Task<IpfsResult<T>> ExcuteAsync<T>(RestRequest request, Func<string, T> resultHandle)
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
            RestRequest request = new RestRequest($"{IpfsMethod.BlockRm}?arg={hash}{BuildParameterString(parameters, false)}", Method.GET);
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
            RestRequest request = new RestRequest($"{IpfsMethod.Cat}?arg={hash}{BuildParameterString(parameters, false)}", Method.GET);
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
            RestRequest request = new RestRequest($"{IpfsMethod.CidFormat}?arg={cid}{BuildParameterString(parameters, false)}", Method.GET);
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
            RestRequest request = new RestRequest($"{IpfsMethod.Config}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<ConfigResult>(request);
        }

        /// <summary>
        /// 用$EDITOR打开配置文件
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<string>> ConfigEditAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigEdit}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 应用配置文件到配置
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<ConfigProfileApplyResult>> ConfigProfileApplyResultAsync(string profile, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigProfileApply}?arg={profile}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<ConfigProfileApplyResult>(request);
        }

        /// <summary>
        /// 替换配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> ConfigReplaceAsync(string path)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigReplace}", Method.POST);
            request.AddFile("arg", path);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 替换配置
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> ConfigReplaceAsync(byte[] content)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigReplace}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 显示配置
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<Dictionary<string, object>>> ConfigShowAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigShow}", Method.GET);
            return ExcuteAsync<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// 在IPFS网络中获取一个DAG节点
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> DagGetAsync(string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagGet}?arg={hash}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 添加一个DAG节点到IPFS
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<DagPutResult>> DagPutAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagPut}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", path);
            return ExcuteAsync<DagPutResult>(request);
        }

        /// <summary>
        /// 添加一个DAG节点到IPFS
        /// </summary>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<DagPutResult>> DagPutAsync(byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagPut}?{BuildParameterString(parameters)}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ExcuteAsync<DagPutResult>(request);
        }

        /// <summary>
        /// 解析ipId块
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<IpfsResult<DagResolveResult>> DagResolveAsync(string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagResolve}?arg={hash}", Method.GET);
            return ExcuteAsync<DagResolveResult>(request);
        }

        /// <summary>
        /// 查询和节点ID相关联的多地址的所有DHT信息
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtFindpeerAsync(string peerId, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtFindpeer}?arg={peerId}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 在DHT网络中找到有指定关键字的节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtFindprovsAsync(string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtFindprovs}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 给定一个键，在DHT表中查询最佳值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtGetAsync(string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtGet}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 向网络宣布正在提供给定的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtProvideAsync(string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtProvide}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 往DHT中写入一个键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtPutAsync(string key, string value, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtPut}?arg={key}&arg={value}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 查找指定节点的最近的节点
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<PeerInfo[]>> DhtQueryAsync(string peerId, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtQuery}?arg={peerId}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request, content =>
            {
                string[] strs = content.Split("\n");
                PeerInfo[] peerInfos = new PeerInfo[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    peerInfos[i] = strs[i].ToObject<PeerInfo>();
                }
                return peerInfos;
            });
        }

        /// <summary>
        /// 列出所有在节点上运行的命令
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<RunningCommandInfo[]>> DiagCmdsAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmds}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<RunningCommandInfo[]>(request);
        }

        /// <summary>
        /// 从日志中清除失效请求
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<string>> DiagCmdsClearAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmdsClear}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 设置在log中的失效请求保存多久
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> DiagSysAsync(string time)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmdsSetTime}?arg={time}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 打印系统诊断信息
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<SysInfo>> DiagSysAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagSys}", Method.GET);
            return ExcuteAsync<SysInfo>(request);
        }

        /// <summary>
        /// 解析DNS链接
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<DnsResult>> DnsAsync(string domainName, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Dns}?arg={domainName}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<DnsResult>(request);
        }

        /// <summary>
        /// 列出Unix文件系统对象的目录内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<IpfsResult<FileLsResult>> FileLsAsync(string path)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FileLs}?arg={path}", Method.GET);
            return ExcuteAsync<FileLsResult>(request);
        }

        /// <summary>
        /// 给定path改变根节点的cid版本或者hash方式
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesChcidAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesChcid}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 复制文件到mfs
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FileLsAsync(string source, string destination)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesCp}?arg={source}&arg={destination}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 将给定路径的数据刷新到磁盘
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<FilesFlushResult>> FilesFlushAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesFlush}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<FilesFlushResult>(request);
        }

        /// <summary>
        /// 列出本地可变命名空间中的目录
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<FilesLsResult>> FilesLsAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesLs}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<FilesLsResult>(request);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesMkdirAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesMkdir}?arg={path}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FileMvAsync(string source, string destination)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesMv}?arg={source}&arg={destination}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 读取给定mfs中的文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesReadAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesRead}?arg={path}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesRmAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesRm}?arg={path}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 用于展示文件/目录的状态
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<FilesStatResult>> FilesStatAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesStat}?arg={path}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<FilesStatResult>(request);
        }

        /// <summary>
        /// 写入给定文件系统中的可变文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesWriteAsync(string path, string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesWrite}?arg={path}{BuildParameterString(parameters, false)}", Method.POST);
            request.AddFile("arg", filePath);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 写入给定文件系统中的可变文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> FilesWriteAsync(string path, byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesWrite}?arg={path}{BuildParameterString(parameters, false)}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 列出filestore和标准块存储中的块
        /// </summary>
        /// <returns></returns>
        public Task<IpfsResult<FilestoreDupsResult>> FilestoreDupsAsync()
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreDups}", Method.GET);
            return ExcuteAsync<FilestoreDupsResult>(request);
        }

        /// <summary>
        /// 列出filestore中的对象列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<FilestoreLsResult>> FilestoreLsAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreLs}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<FilestoreLsResult>(request);
        }

        /// <summary>
        /// 验证filestore中的对象
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<FilestoreVerifyResult>> FilestoreVerifyAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreVerify}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<FilestoreVerifyResult>(request);
        }

        /// <summary>
        /// 下载IPFS对象
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<string>> GetAsync(string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Get}?arg={path}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync(request);
        }

        /// <summary>
        /// 展示节点ID的信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<IdResult>> IdAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Id}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<IdResult>(request);
        }

        /// <summary>
        /// 生成一对新的键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<KeyGenResult>> KeyGenAsync(string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyGen}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<KeyGenResult>(request);
        }

        /// <summary>
        /// 列出本地的键值对
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<KeyListResult>> KeyListAsync(Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyList}?{BuildParameterString(parameters)}", Method.GET);
            return ExcuteAsync<KeyListResult>(request);
        }

        /// <summary>
        /// 重命名键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<KeyRenameResult>> KeyRenameAsync(string key, string newKey, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyRename}?arg={key}&arg={newKey}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<KeyRenameResult>(request);
        }

        /// <summary>
        /// 删除键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IpfsResult<KeyRmResult>> KeyRmAsync(string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyRm}?arg={key}{BuildParameterString(parameters, false)}", Method.GET);
            return ExcuteAsync<KeyRmResult>(request);
        }
    }
}
