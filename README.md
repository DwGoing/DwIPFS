# DwIPFS

#### IPFS的.Net Core封装接口

### 0x1 Nuget包引用

```c#
PM> Install-Package DwIPFS
或
> dotnet add package DwIPFS
```

### 0x2 基本使用

```c#
// 初始化服务
IpfsService ipfs = new IpfsService("http://192.168.10.200:5001/", "v0");
// 需要保存的内容
var bytes = Encoding.UTF8.GetBytes("Hello IPFS");
// 上传到链
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