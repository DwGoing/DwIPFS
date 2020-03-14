using System;

namespace DwIPFS
{
    public class IpfsMethod
    {
        public const string Add = "add";
        public const string BitswapLedger = "bitswap/ledger";
        public const string BitswapReprovide = "bitswap/reprovide";
        public const string BitswapStat = "bitswap/stat";
        public const string BitswapWantList = "bitswap/wantlist";
        public const string BlockGet = "block/get";
        public const string BlockPut = "block/put";
        public const string BlockRm = "block/rm";
        public const string BlockStat = "block/stat";
        public const string Bootstrap = "bootstrap";
        public const string BootstrapAdd = "bootstrap/add";
        public const string BootstrapAddDefault = "bootstrap/add/default";
        public const string BootstrapList = "bootstrap/list";
        public const string BootstrapRm = "bootstrap/rm";
        public const string BootstrapRmAll = "bootstrap/rm/all";
        public const string Cat = "cat";
        public const string CidBase32 = "cid/base32";
        public const string CidBases = "cid/bases";
        public const string CidCodecs = "cid/codecs";
        public const string CidFormat = "cid/format";
        public const string CidHashes = "cid/hashes";
        public const string Commands = "commands";
        public const string Config = "config";
        public const string ConfigEdit = "config/edit";
        public const string ConfigProfileApply = "config/profile/apply";
        public const string ConfigReplace = "config/replace";
        public const string ConfigShow = "config/show";
        public const string DagGet = "dag/get";
        public const string DagPut = "dag/put";
        public const string DagResolve = "dag/resolve";
        public const string DhtFindpeer = "dht/findpeer";
        public const string DhtFindprovs = "dht/findprovs";
        public const string DhtGet = "dht/get";
        public const string DhtProvide = "dht/provide";
        public const string DhtPut = "dht/put";
        public const string DhtQuery = "dht/query";
        public const string DiagCmds = "diag/cmds";
        public const string DiagCmdsClear = "diag/cmds/clear";
        public const string DiagCmdsSetTime = "diag/cmds/set-time";
        public const string DiagSys = "diag/sys";
        public const string Dns = "dns";
        public const string FileLs = "file/ls";
        public const string FilesChcid = "files/chcid";
        public const string FilesCp = "files/cp";
        public const string FilesFlush = "files/flush";
        public const string FilesLs = "files/ls";
        public const string FilesMkdir = "files/mkdir";
        public const string FilesMv = "files/mv";
        public const string FilesRead = "files/read";
        public const string FilesRm = "files/rm";
        public const string FilesStat = "files/stat";
        public const string FilesWrite = "files/write";
        public const string FilestoreDups = "filestore/dups";
        public const string FilestoreLs = "filestore/ls";
        public const string FilestoreVerify = "filestore/verify";
    }
}
