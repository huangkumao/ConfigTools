var Handler = laya.utils.Handler;
var Loader = laya.net.Loader;
// 程序入口
var GameMain = /** @class */ (function () {
    function GameMain() {
        Laya.init(600, 400);
        Laya.loader.load([
            { url: "cfg/CfgListSample.json", type: Loader.JSON },
            { url: "cfg/CfgMapSample.json", type: Loader.JSON }
        ], Handler.create(this, this.Onloaded), null, null, 0, true, null);
    }
    GameMain.prototype.Onloaded = function () {
        //测试List格式
        var cfgListSample = Loader.getRes("cfg/CfgListSample.json");
        for (var _i = 0, _a = cfgListSample.mDataList; _i < _a.length; _i++) {
            var data = _a[_i];
            console.debug("----------------------");
            console.debug(data.ListID.toString());
            console.debug(data.name);
            console.debug(data.booldata.toString());
            for (var _b = 0, _c = data.floatdata; _b < _c.length; _b++) {
                var f = _c[_b];
                console.debug(f.toString());
            }
            console.debug("----------------------");
        }
        //测试Map格式
        var cfgMapSample = Loader.getRes("cfg/CfgMapSample.json");
        for (var key in cfgMapSample.mDataMap) {
            var element = cfgMapSample.mDataMap[key];
            console.debug("----------------------");
            console.debug(element.id.toString());
            console.debug(element.name);
            console.debug(element.booldata.toString());
            for (var _d = 0, _e = element.floatdata; _d < _e.length; _d++) {
                var f = _e[_d];
                console.debug(f.toString());
            }
            console.debug("----------------------");
        }
    };
    return GameMain;
}());
new GameMain();
//# sourceMappingURL=LayaSample.js.map