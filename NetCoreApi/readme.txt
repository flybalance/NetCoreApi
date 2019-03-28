知识点:
1、配置指定端口号 hosting.json
2、mongodb 简单使用
3、consule 服务注册
4、autofac Ioc容器 demo(构造函数注入)
5、swagger 接口文档使用demo
6、 默认返回的json数据，属性首字母为小写，此配置为更改属性为初始化定义的大小写状态
services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver())