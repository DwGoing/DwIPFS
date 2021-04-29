using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using DwIPFS;

namespace CommandTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var ipfs = new IPFS("https://1rk7uzC6tSaCehV6TjEMB8ZQFTv:7c2a64ece1aa5fe02a510f00d957fc6e@filecoin.infura.io", "jianghy1209@163.com", "ayou1209");
                await ipfs.AddAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "1.txt"), new Dictionary<string, object>(){
                    {"progress","true"}
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}
