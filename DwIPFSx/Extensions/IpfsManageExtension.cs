using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using DwIPFS.Extensions;

namespace DwIPFS.Manage
{
    public static class IpfsManageExtension
    {
        /// <summary>
        /// 显示当前节点的账本信息
        /// </summary>
        /// <param name="peerId"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BitswapLedgerResult>> BitswapLedgerAsync(this IpfsService ipfs, string peerId)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapLedger}?arg={peerId}", Method.GET);
            return ipfs.ExcuteAsync<BitswapLedgerResult>(request);
        }

        /// <summary>
        /// 触发reprovider
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<string>> BitswapReprovideAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapReprovide}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 展示bitswap代理的诊断信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BitswapStatResult>> BitswapStatAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapStat}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<BitswapStatResult>(request);
        }

        /// <summary>
        /// 显示wantlist中的当前块列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BitswapWantListResult>> BitswapWantListAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BitswapWantList}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<BitswapWantListResult>(request);
        }

        /// <summary>
        /// 显示或编辑引导列表
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapResult>> BootstrapAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Bootstrap}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapResult>(request);
        }

        /// <summary>
        /// 添加到引导列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapAddResult>> BootstrapAddAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapAdd}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapAddResult>(request);
        }

        /// <summary>
        /// 添加默认节点
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapAddDefaultResult>> BootstrapAddDefaultAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapAddDefault}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapAddDefaultResult>(request);
        }

        /// <summary>
        /// 展示系统目前连接的所有节点
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapListResult>> BootstrapListAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapList}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapListResult>(request);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapRmResult>> BootstrapRmAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapRm}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapRmResult>(request);
        }

        /// <summary>
        /// 删除所有节点
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<BootstrapRmAllResult>> BootstrapRmAllAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BootstrapRmAll}", Method.GET);
            return ipfs.ExcuteAsync<BootstrapRmAllResult>(request);
        }

        /// <summary>
        /// 列出所有可用命令
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<Command>> CommandsAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Commands}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<Command>(request);
        }

        /// <summary>
        /// 获取或设置配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<ConfigResult>> ConfigAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Config}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync<ConfigResult>(request);
        }

        /// <summary>
        /// 用$EDITOR打开配置文件
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<string>> ConfigEditAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigEdit}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 应用配置文件到配置
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<ConfigProfileApplyResult>> ConfigProfileApplyResultAsync(this IpfsService ipfs, string profile, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigProfileApply}?arg={profile}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync<ConfigProfileApplyResult>(request);
        }

        /// <summary>
        /// 替换配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> ConfigReplaceAsync(this IpfsService ipfs, string path)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigReplace}", Method.POST);
            request.AddFile("arg", path);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 替换配置
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> ConfigReplaceAsync(this IpfsService ipfs, byte[] content)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigReplace}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 显示配置
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<Dictionary<string, object>>> ConfigShowAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.ConfigShow}", Method.GET);
            return ipfs.ExcuteAsync<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// 在IPFS网络中获取一个DAG节点
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> DagGetAsync(this IpfsService ipfs, string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagGet}?arg={hash}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 添加一个DAG节点到IPFS
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<DagPutResult>> DagPutAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagPut}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", path);
            return ipfs.ExcuteAsync<DagPutResult>(request);
        }

        /// <summary>
        /// 添加一个DAG节点到IPFS
        /// </summary>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<DagPutResult>> DagPutAsync(this IpfsService ipfs, byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagPut}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ipfs.ExcuteAsync<DagPutResult>(request);
        }

        /// <summary>
        /// 解析IPLD块
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Task<IpfsResult<DagResolveResult>> DagResolveAsync(this IpfsService ipfs, string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DagResolve}?arg={hash}", Method.GET);
            return ipfs.ExcuteAsync<DagResolveResult>(request);
        }

        /// <summary>
        /// 查询和节点ID相关联的多地址的所有DHT信息
        /// </summary>
        /// <param name="peerId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<PeerInfo[]>> DhtFindpeerAsync(this IpfsService ipfs, string peerId, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtFindpeer}?arg={peerId}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<PeerInfo[]>> DhtFindprovsAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtFindprovs}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<PeerInfo[]>> DhtGetAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtGet}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<PeerInfo[]>> DhtProvideAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtProvide}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<PeerInfo[]>> DhtPutAsync(this IpfsService ipfs, string key, string value, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtPut}?arg={key}&arg={value}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<PeerInfo[]>> DhtQueryAsync(this IpfsService ipfs, string peerId, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DhtQuery}?arg={peerId}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync(request, content =>
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
        public static Task<IpfsResult<RunningCommandInfo[]>> DiagCmdsAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmds}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<RunningCommandInfo[]>(request);
        }

        /// <summary>
        /// 从日志中清除失效请求
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<string>> DiagCmdsClearAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmdsClear}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 设置在log中的失效请求保存多久
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> DiagSysAsync(this IpfsService ipfs, string time)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagCmdsSetTime}?arg={time}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 打印系统诊断信息
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<SysInfo>> DiagSysAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.DiagSys}", Method.GET);
            return ipfs.ExcuteAsync<SysInfo>(request);
        }

        /// <summary>
        /// 展示节点ID的信息
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<IdResult>> IdAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Id}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<IdResult>(request);
        }

        /// <summary>
        /// 生成一对新的键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<KeyGenResult>> KeyGenAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyGen}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync<KeyGenResult>(request);
        }

        /// <summary>
        /// 列出本地的键值对
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<KeyListResult>> KeyListAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyList}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<KeyListResult>(request);
        }

        /// <summary>
        /// 重命名键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<KeyRenameResult>> KeyRenameAsync(this IpfsService ipfs, string key, string newKey, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyRename}?arg={key}&arg={newKey}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync<KeyRenameResult>(request);
        }

        /// <summary>
        /// 删除键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<KeyRmResult>> KeyRmAsync(this IpfsService ipfs, string key, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.KeyRm}?arg={key}{parameters.BuildParameterString( false)}", Method.GET);
            return ipfs.ExcuteAsync<KeyRmResult>(request);
        }

        /// <summary>
        /// 改变日志等级
        /// </summary>
        /// <param name="ipfsPath"></param>
        /// <param name="ipnsPath"></param>
        /// <returns></returns>
        public static Task<IpfsResult<LogLevelResult>> LogLevelAsync(this IpfsService ipfs, string subsystem, string level)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.LogLevel}?arg={subsystem}&arg={level}", Method.GET);
            return ipfs.ExcuteAsync<LogLevelResult>(request);
        }

        /// <summary>
        /// 列出所有日志系统标识
        /// </summary>
        /// <returns></returns>
        public static  Task<IpfsResult<LogLsResult>> LogLsAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.LogLs}", Method.GET);
            return ipfs.ExcuteAsync<LogLsResult>(request);
        }

        /// <summary>
        /// 读取事件日志
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<string>> LogTailAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.LogTail}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }
    }
}
