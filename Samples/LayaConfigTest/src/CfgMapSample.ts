/*
* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools
*/
namespace Configs
{
    export class CfgMapSample
    {
        public mDataMap:{ [key:string] :MapSampleData };
    }

    export class MapSampleData
    {
        //表的ID,有此ID会生成Map结构,ID大小写无关
        public id:number;
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
