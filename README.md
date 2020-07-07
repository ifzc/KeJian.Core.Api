# KeJian.Core.Api

### ✨站点部署
> System：Linux - CentOS 7.7   
> DB：MySql  
> Api Host : kejianapi.filog.cn/swagger   
> Web Host : kejian.filog.cn (接口正在替换为新接口)  
> 测试账号：admin 123456  

> 有小伙伴要的表结构 [TableSql.sql](https://github.com/ifzc/KeJian.Core.Api/blob/master/TableSql.sql) 

### 🔥 简单两步即可运行项目
> Step 1 :   
> 在 KeJian.Core.Api 项目根目录中添加 `appsettings.Demo.json` 文件   
``` 
{
  "ConnectionStrings": {
    "DefaultConnection": "-- connection string --"
  },
  "JwtSecurityOption": {
    "SigningKey": "-- signing key --",
    "Issuer": "kejian.smilef.cn",
    "Audience": "kejianapi.smilef.cn"
  }
}
```
> 配置 ConnectionStrings   
> 例：`Database='kejian';Data Source=***;User ID=***;Password=***;CharSet=utf8;SslMode=None`   
> 关闭 SSL(HTTPS) 连接 `SslMode=None`    
> 配置 JwtSigningKey (需要 16 个字符以上，推荐 Guid)

> Step 2 :   
> 在程序包管理控制台选择 KeJian.Core.EntityFramework 项目执行更新数据库命令  
> 部分版本的 MySql 可能需要手动创建库名  

### 💡 CodeFirst 命令
> PM 模式 （程序包管理控制台）
```
PM> Add-Migration Initial              建立并初始化数据库
PM> Update-Database                    更新数据库
PM> Script-Migration                   生成 SQL 语句
```
> Cmd 模式
```
> dotnet ef migrations add Initial     建立并初始化数据库
> dotnet ef database update            更新数据库
```