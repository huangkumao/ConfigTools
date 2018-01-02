/*
* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools
*/
namespace Configs
{
    export class CfgListSample
    {
        public mDataList:ListSampleData[];
    }

    export class ListSampleData
    {
        //第一个字段不是ID将会以List形式数据
        public ListID:number;
        //文字描述
        public name:string;
        //浮点数据
        public floatdata:number[];
        //整型数组
        public intarray:number[];
        //字符串数组
        public stringlist:string[];
        //bool值
        public booldata:boolean;
    }
}
