# ConfigTools
把Excel配置表导出成Json格式, 可供服务器,客户端(Unity,Laya)使用

# 特性
1: 支持生成两种代码 C#和TypeScript.

2: 支持多种字段类型设定(int,float,string,bool,intarray,floatarray,stringarray).

3: 支持指定字段导出类型(all,client,server).

4: 自动根据表ID来生成Map或者List数据结构.

5: 可视化UI操作.


# 表结构示例
|表ID,大小写无关,不存在则会生成List结构|文字描述|服务器数据|浮点数据|整型数组|字符串数组|bool值|
|-------| --------| ------- | ------ | ------- | -------| ------- | 
|id|name|serverdata|floatdata|intarray|stringlist|booldata|
|int	|string	|int	|float+	|int+|	string+	|bool|
|all	|client|	server	|all|	all|	all	|all|
|1|	这是id1|	1|	1.1|	1|	s1|	0|
|2|	这是id2|	2|	2.1;2.2|	1;2|	s1;s2	|1|
|3|	这是id3|	3|	3.1;3.2;3.3|	1;2;3|	s1;s2;s3	|0|

![Image text](https://github.com/huangkumao/ConfigTools/blob/master/ConfigTools.png)
