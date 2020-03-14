using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DwIPFS
{
    public class AddResult
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public int Size { get; set; }
    }

    public class BitswapLedgerResult
    {
        public string Peer { get; set; }
        public int Value { get; set; }
        public int Sent { get; set; }
        public int Recv { get; set; }
        public int Exchanged { get; set; }
    }

    public class BitswapStatResult
    {
        public int ProvideBufLen { get; set; }
        public string[] Wantlist { get; set; }
        public string[] Peers { get; set; }
        public int BlocksReceived { get; set; }
        public int DataReceived { get; set; }
        public int BlocksSent { get; set; }
        public int DataSent { get; set; }
        public int DupBlksReceived { get; set; }
        public int DupDataReceived { get; set; }
        public int MessagesReceived { get; set; }
    }

    public class BitswapWantListResult
    {
        public KeyValuePair<string, string>[] Keys { get; set; }
    }

    public class BlockPutResult
    {
        public string Key { get; set; }
        public int Size { get; set; }
    }

    public class BlockRmResult
    {
        public string Error { get; set; }
        public string Hash { get; set; }
    }

    public class BlockStatResult
    {
        public string Key { get; set; }
        public int Size { get; set; }
    }

    public class BootstrapResult
    {
        public string[] Peers { get; set; }
    }

    public class BootstrapAddResult
    {
        public string[] Peers { get; set; }
    }

    public class BootstrapAddDefaultResult
    {
        public string[] Peers { get; set; }
    }

    public class BootstrapListResult
    {
        public string[] Peers { get; set; }
    }

    public class BootstrapRmResult
    {
        public string[] Peers { get; set; }
    }

    public class BootstrapRmAllResult
    {
        public string[] Peers { get; set; }
    }

    public class CidBase32Result
    {
        public string CidStr { get; set; }
        public string ErrorMsg { get; set; }
        public string Formatted { get; set; }
    }

    public class BaseEncoding
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class CidCodec
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class CidFormatResult
    {
        public string CidStr { get; set; }
        public string ErrorMsg { get; set; }
        public string Formatted { get; set; }
    }

    public class CidHash
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class CommandOption
    {
        public string[] Names { get; set; }
    }

    public class Command
    {
        public string Name { get; set; }
        public CommandOption[] Options { get; set; }
        public Command[] Subcommands { get; set; }
    }

    public class ConfigResult
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public class ConfigProfileApplyResult
    {
        public Dictionary<string, object> NewCfg { get; set; }
        public Dictionary<string, object> OldCfg { get; set; }
    }

    public class DagPutResult
    {
        public Dictionary<string, string> Cid { get; set; }
    }

    public class DagResolveResult
    {
        public Dictionary<string, string> Cid { get; set; }
        public string RemPath { get; set; }
    }

    public class PeerResponse
    {
        public string[] Addrs { get; set; }
        public string ID { get; set; }
    }

    public class PeerInfo
    {
        public string Extra { get; set; }
        public string ID { get; set; }
        public PeerResponse[] Responses { get; set; }
        public int Type { get; set; }
    }

    public class RunningCommandInfo
    {
        public bool Active { get; set; }
        public string[] Args { get; set; }
        public string Command { get; set; }
        public DateTime EndTime { get; set; }
        public int ID { get; set; }
        public Dictionary<string, object> Options { get; set; }
        public DateTime StartTime { get; set; }
    }

    public class SysInfo
    {
        public Dictionary<string, object> DiskInfo { get; set; }
        public Dictionary<string, object> Environment { get; set; }
        [JsonProperty("ipfs_commit")]
        public string IpfsCommit { get; set; }
        [JsonProperty("ipfs_version")]
        public string IpfsVersion { get; set; }
        public Dictionary<string, object> Memory { get; set; }
        public Dictionary<string, object> Net { get; set; }
        public Dictionary<string, object> RunTime { get; set; }
    }

    public class DnsResult
    {
        public string Path { get; set; }
    }

    public class FileLsResult
    {
        public Dictionary<string, string> Arguments { get; set; }
        public Dictionary<string, object> Objects { get; set; }
    }

    public class FilesFlushResult
    {
        public string Cid { get; set; }
    }

    public class Entry
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public int Type { get; set; }
    }

    public class FilesLsResult
    {
        public Entry[] Entries { get; set; }
    }

    public class FilesStatResult
    {
        public int Blocks { get; set; }
        public ulong CumulativeSize { get; set; }
        public string Hash { get; set; }
        public bool Local { get; set; }
        public ulong Size { get; set; }
        public ulong SizeLocal { get; set; }
        public string Type { get; set; }
        public bool WithLocality { get; set; }
    }

    public class FilestoreDupsResult
    {
        public string Err { get; set; }
        public string Ref { get; set; }
    }

    public class FilestoreLsResult
    {
        public string ErrorMsg { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, string> Key { get; set; }
        public ulong Offset { get; set; }
        public ulong Size { get; set; }
        public int Status { get; set; }
    }

    public class FilestoreVerifyResult
    {
        public string ErrorMsg { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, string> Key { get; set; }
        public ulong Offset { get; set; }
        public ulong Size { get; set; }
        public int Status { get; set; }
    }
}
