using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using DwIPFS.Extensions;

namespace DwIPFS.FileSystem
{
    public static class IpfsFileSystemExtension
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<AddResult>> AddAsync(this IpfsService ipfs, string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Add}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", filePath);
            return ipfs.ExcuteAsync<AddResult>(request);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<AddResult>> AddAsync(this IpfsService ipfs, byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Add}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ipfs.ExcuteAsync<AddResult>(request);
        }

        /// <summary>
        /// 获取原始IPFS块
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> BlockGetAsync(this IpfsService ipfs, string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockGet}?arg={hash}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 将输入存储为IPFS块
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BlockPutResult>> BlockPutAsync(this IpfsService ipfs, string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockPut}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", filePath);
            return ipfs.ExcuteAsync<BlockPutResult>(request);
        }

        /// <summary>
        /// 将输入存储为IPFS块
        /// </summary>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BlockPutResult>> BlockPutAsync(this IpfsService ipfs, byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockPut}?{parameters.BuildParameterString()}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ipfs.ExcuteAsync<BlockPutResult>(request);
        }

        /// <summary>
        /// 移除IPFS块
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BlockRmResult>> BlockRmAsync(this IpfsService ipfs, string hash, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockRm}?arg={hash}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync<BlockRmResult>(request);
        }

        /// <summary>
        /// 打印原始块的信息.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BlockStatResult>> BlockStatAsync(this IpfsService ipfs, string hash)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.BlockStat}?arg={hash}", Method.GET);
            return ipfs.ExcuteAsync<BlockStatResult>(request);
        }

        /// <summary>
        /// 查看内容
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> CatAsync(this IpfsService ipfs, string hash, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Cat}?arg={hash}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 解析DNS链接
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<DnsResult>> DnsAsync(this IpfsService ipfs, string domainName, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Dns}?arg={domainName}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync<DnsResult>(request);
        }

        /// <summary>
        /// 列出Unix文件系统对象的目录内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FileLsResult>> FileLsAsync(this IpfsService ipfs, string path)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FileLs}?arg={path}", Method.GET);
            return ipfs.ExcuteAsync<FileLsResult>(request);
        }

        /// <summary>
        /// 给定path改变根节点的cid版本或者hash方式
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesChcidAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesChcid}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 复制文件到mfs
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FileLsAsync(this IpfsService ipfs, string source, string destination)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesCp}?arg={source}&arg={destination}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 将给定路径的数据刷新到磁盘
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FilesFlushResult>> FilesFlushAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesFlush}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<FilesFlushResult>(request);
        }

        /// <summary>
        /// 列出本地可变命名空间中的目录
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FilesLsResult>> FilesLsAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesLs}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<FilesLsResult>(request);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesMkdirAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesMkdir}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FileMvAsync(this IpfsService ipfs, string source, string destination)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesMv}?arg={source}&arg={destination}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 读取给定mfs中的文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesReadAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesRead}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesRmAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesRm}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 用于展示文件/目录的状态
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FilesStatResult>> FilesStatAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesStat}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync<FilesStatResult>(request);
        }

        /// <summary>
        /// 写入给定文件系统中的可变文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesWriteAsync(this IpfsService ipfs, string path, string filePath, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesWrite}?arg={path}{parameters.BuildParameterString(false)}", Method.POST);
            request.AddFile("arg", filePath);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 写入给定文件系统中的可变文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> FilesWriteAsync(this IpfsService ipfs, string path, byte[] content, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilesWrite}?arg={path}{parameters.BuildParameterString(false)}", Method.POST);
            request.AddFile("arg", content, StringExtension.GenerateRandomString(16));
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 列出filestore和标准块存储中的块
        /// </summary>
        /// <returns></returns>
        public static Task<IpfsResult<FilestoreDupsResult>> FilestoreDupsAsync(this IpfsService ipfs)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreDups}", Method.GET);
            return ipfs.ExcuteAsync<FilestoreDupsResult>(request);
        }

        /// <summary>
        /// 列出filestore中的对象列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FilestoreLsResult>> FilestoreLsAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreLs}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<FilestoreLsResult>(request);
        }

        /// <summary>
        /// 验证filestore中的对象
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<FilestoreVerifyResult>> FilestoreVerifyAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.FilestoreVerify}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<FilestoreVerifyResult>(request);
        }

        /// <summary>
        /// 下载IPFS对象
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<string>> GetAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Get}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync(request);
        }

        /// <summary>
        /// 列出Unix系统对象下的目录内容
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<LsResult>> LsAsync(this IpfsService ipfs, string path, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Ls}?arg={path}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync<LsResult>(request);
        }

        /// <summary>
        /// 将IPFS挂载到文件系统(只读)
        /// </summary>
        /// <param name="ipfsPath"></param>
        /// <param name="ipnsPath"></param>
        /// <returns></returns>
        public static Task<IpfsResult<MountResult>> MountAsync(this IpfsService ipfs, string ipfsPath, string ipnsPath)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.Mount}?arg={ipfsPath}&arg={ipnsPath}", Method.GET);
            return ipfs.ExcuteAsync<MountResult>(request);
        }
    }
}
