using System;
using System.Collections.Generic;

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
}
