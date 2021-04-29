using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DwIPFS.Manage
{
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

    public class IdResult
    {
        public string[] Addresses { get; set; }
        public string AgentVersion { get; set; }
        public string ID { get; set; }
        public string ProtocolVersion { get; set; }
        public string PublicKey { get; set; }
    }

    public class KeyGenResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class KeyInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class KeyListResult
    {
        public KeyInfo[] Keys { get; set; }
    }

    public class KeyRenameResult
    {
        public string Id { get; set; }
        public string Now { get; set; }
        public bool Overwrite { get; set; }
        public string Was { get; set; }
    }

    public class KeyRmResult
    {
        public KeyInfo[] Keys { get; set; }
    }

    public class LogLevelResult
    {
        public string Message { get; set; }
    }

    public class LogLsResult
    {
        public string[] Strings { get; set; }
    }

    public class LinkInfo
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public ulong Size { get; set; }
        public string Target { get; set; }
        public int Type { get; set; }
    }
}
