using System;

namespace DwIPFS.Convert
{
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
}
