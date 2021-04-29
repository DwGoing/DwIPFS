using System;
using System.Collections.Generic;

namespace DwIPFS.FileSystem
{
    public class AddResult
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public int Size { get; set; }
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

    public class LinkInfo
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public ulong Size { get; set; }
        public string Target { get; set; }
        public int Type { get; set; }
    }

    public class FileObject
    {
        public string Hash { get; set; }
        public LinkInfo[] Links { get; set; }
    }

    public class LsResult
    {
        public FileObject[] Objects { get; set; }
    }

    public class MountResult
    {
        public bool FuseAllowOther { get; set; }
        public string IPFS { get; set; }
        public string IPNS { get; set; }
    }
}
