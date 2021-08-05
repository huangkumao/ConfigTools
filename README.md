# ConfigTools
把Excel配置表导出成Json格式, 可供服务器,客户端(Unity,Laya)使用

# Update
1: 增加了压缩Json选项

2: 增加了导出批注功能

3: 修复了一个UTF8的bug

# 特性
1: 支持生成两种代码 C#和TypeScript.

2: 支持多种字段类型设定(int,float,string,bool,intarray,floatarray,stringarray).

3: 支持指定字段导出类型(all,client,server).

4: 自动根据表ID来生成Map或者List数据结构.

5: 可视化UI操作.

6: 可以非常方便的修改和扩展功能以符合自己的实际项目需求.


# 表结构示例
|表ID大小写无关,没有生成List,有生成Map|文字描述|服务器数据|浮点数据|整型数组|字符串数组|bool值|
|-------| --------| ------- | ------ | ------- | -------| ------- |
|id|name|serverdata|floatdata|intarray|stringlist|booldata|
|int	|string	|int	|float+	|int+|	string+	|bool|
|all	|client|	server	|all|	all|	all	|all|
|1|	这是id1|	1|	1.1|	1|	s1|	0|
|2|	这是id2|	2|	2.1;2.2|	1;2|	s1;s2	|1|
|3|	这是id3|	3|	3.1;3.2;3.3|	1;2;3|	s1;s2;s3	|0|

//两种格式Sample 具体Excel格式可以根据这两个文件

https://github.com/huangkumao/ConfigTools/blob/master/Samples/Configs/ListSample.xlsx

https://github.com/huangkumao/ConfigTools/blob/master/Samples/Configs/MapSample.xlsx


![Image text](https://github.com/huangkumao/ConfigTools/blob/master/ConfigTools.png)


## 推荐项目
- [JEngine](https://github.com/JasonXuDeveloper/JEngine) - JEngine是针对Unity开发者设计的开箱即用的框架，封装了强大的功能，小白也能快速上手，轻松制作可以热更新的游戏
