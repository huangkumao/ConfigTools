/*
* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools
*/
using System.Collections.Generic;

namespace Configs
{
    public class CfgListSample
    {
        public List<ListSampleData> mDataList;
    }

    public class ListSampleData
    {
        //第一个字段不是ID将会以List形式数据
        public int ListID;
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
