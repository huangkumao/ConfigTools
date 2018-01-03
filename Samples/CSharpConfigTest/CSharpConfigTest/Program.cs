using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configs;
using Newtonsoft.Json;

namespace CSharpConfigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("Configs/CfgListSample.json");
            var listSample = JsonConvert.DeserializeObject<CfgListSample>(json);
            foreach (var data in listSample.mDataList)
            {
                Console.WriteLine(data.ListID);
            }

            json = File.ReadAllText("Configs/CfgMapSample.json");
            var MapSample = JsonConvert.DeserializeObject<CfgMapSample>(json);
            foreach (var data in MapSample.mDataMap)
            {
                Console.WriteLine(data.Key);
            }
        }
    }
}
