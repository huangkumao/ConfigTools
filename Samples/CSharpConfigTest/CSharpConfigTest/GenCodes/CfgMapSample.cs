/*
* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools
*/
using System.Collections.Generic;

namespace Configs
{
    public class CfgMapSample
    {
        public Dictionary<string, MapSampleData> mDataMap;
    }

    public class MapSampleData
    {
        //表的ID,有此ID会生成Map结构,ID大小写无关
        public int id;
        //服务器数据
        public int serverdata;
        //浮点数据
        public List<float> floatdata;
        //整型数组
        public List<int> intarray;
        //字符串数组
        public List<string> stringlist;
        //bool值
        public bool booldata;
    }
}
