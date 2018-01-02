import Handler = laya.utils.Handler;
import Loader = laya.net.Loader;

// 程序入口
class GameMain
{
    constructor()
    {
        Laya.init(600,400);
        Laya.loader.load(
            [
                { url: "cfg/CfgListSample.json", type: Loader.JSON },
                { url: "cfg/CfgMapSample.json", type: Loader.JSON }
            ], Handler.create(this, this.Onloaded), null, null, 0, true, null);
    }

    public Onloaded():void
    {
        //测试List格式
        var cfgListSample = <Configs.CfgListSample>Loader.getRes("cfg/CfgListSample.json");
        for (let data of cfgListSample.mDataList) 
        {
            console.debug("----------------------");
            console.debug(data.ListID.toString());
            console.debug(data.name);
            console.debug(data.booldata.toString());
            for(let f of data.floatdata)
                console.debug(f.toString());
            console.debug("----------------------");
        }

        //测试Map格式
        var cfgMapSample = <Configs.CfgMapSample>Loader.getRes("cfg/CfgMapSample.json");
        for (var key in cfgMapSample.mDataMap) 
        {    
            var element = cfgMapSample.mDataMap[key];
            console.debug("----------------------");
            console.debug(element.id.toString());
            console.debug(element.name);
            console.debug(element.booldata.toString());
            for(let f of element.floatdata)
                console.debug(f.toString());
            console.debug("----------------------");
        }
    }
}
new GameMain();