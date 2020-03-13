# DwIPFS

#### IPFS的.Net Core封装接口

### 0x1 Nuget包引用

```c#
PM> Install-Package DwIPFS
或
> dotnet add package DwIPFS
```

### 0x2 环境配置

```c#
1.部署IPFS节点
  参考：https://docs.ipfs.io/guides/guides/install/
```

### 0x3 基本使用

```c#
// 初始化服务
IpfsService ipfs = new IpfsService("http://节点IP:5001/", "版本号");
// 需要保存的内容
var bytes = Encoding.UTF8.GetBytes("Hello IPFS");
// 上传到链
// 待节点广播消息后
// 可通过https://ipfs.io/ipfs/QmVXBKtQTF6SCNE1YQEEUQUKNBG48uR1uKKXPpzLtEy6xM来查看内容
var res = await ipfs.AddAsync(bytes);
if (res.Code == ResultCode.Ok)
{
		Console.WriteLine(res.Data.ToJson()); // QmVXBKtQTF6SCNE1YQEEUQUKNBG48uR1uKKXPpzLtEy6xM
}
else
{
		Console.WriteLine(res.Message);
}
// 查询链上信息
var res = await ipfs.CatAsync("QmVXBKtQTF6SCNE1YQEEUQUKNBG48uR1uKKXPpzLtEy6xM");
if (res.Code == ResultCode.Ok)
{
		Console.WriteLine(res.Data.ToJson()); // Hello IPFS
}
else
{
		Console.WriteLine(res.Message);
}
```