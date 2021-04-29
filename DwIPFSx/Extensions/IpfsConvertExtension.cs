using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using DwIPFS.Extensions;

namespace DwIPFS.Convert
{
    public static class IpfsConvertExtension
    {
        /// <summary>
        /// 转换CID为Base32版本
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static Task<IpfsResult<CidBase32Result>> CidBase32Async(this IpfsService ipfs, string cid)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidBase32}?arg={cid}", Method.GET);
            return ipfs.ExcuteAsync<CidBase32Result>(request);
        }

        /// <summary>
        /// 列出可用到多库编码
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<BaseEncoding[]>> CidBasesAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidBases}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<BaseEncoding[]>(request);
        }

        /// <summary>
        /// 列出可用到CID编码器
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<CidCodec[]>> CidCodecsAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidCodecs}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<CidCodec[]>(request);
        }

        /// <summary>
        /// 格式化CID
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<CidFormatResult>> CidFormatAsync(this IpfsService ipfs, string cid, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidFormat}?arg={cid}{parameters.BuildParameterString(false)}", Method.GET);
            return ipfs.ExcuteAsync<CidFormatResult>(request);
        }

        /// <summary>
        /// 列出可用哈希
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Task<IpfsResult<CidHash[]>> CidHashesAsync(this IpfsService ipfs, Dictionary<string, object> parameters = null)
        {
            RestRequest request = new RestRequest($"{IpfsMethod.CidHashes}?{parameters.BuildParameterString()}", Method.GET);
            return ipfs.ExcuteAsync<CidHash[]>(request);
        }
    }
}
