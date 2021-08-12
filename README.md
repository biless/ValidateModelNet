# 简介
ValidateModel是为了解决模型验证后可以方便的让前端定位到提交的字段中哪个字段出现问题。可以尽量避免采用弹出框的形式提示错误！

# 使用
在 Startup.cs 中添加如下代码
```csharp
services.AddControllersWithViews(config => config.Filters.Add(typeof(ValidateModelAttribute)));

services.AddValidateMode(dic =>
{
    dic.Add("en", new Dictionary<string, string>
    {
        { "中文错误", "Error" },
    });
},"Accept-Language");
```
##### 使用前注意

使用前需要屏蔽aspnet core的系统处理函数添加如下代码即可屏蔽
```csharp
services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
```

# 自定义错误返回
可以定义错误返回的格式代码如下
```csharp
services.AddValidateModeResultMap(errors => new ResultError
{
    Error = errors.FirstOrDefault().FieldError
});
```

# 支持类型
 - [x] 基础类型 如:int,string,double等
 - [x] List
 - [x] Array


