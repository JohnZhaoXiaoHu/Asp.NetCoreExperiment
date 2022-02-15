using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
    options.InstanceName = "DistributedRedis_";
});

//builder.Services.AddMemoryCache(opt =>
//{

//    // opt.SizeLimit = 40;

//});

var app = builder.Build();


//app.MapGet("/get/{id}", (IMemoryCache memoryCache, string id) =>
//{
//    var result = memoryCache.TryGetValue(id, out string timeStr);
//    if (result)
//    {
//        return $"��ȡ�ɹ���{timeStr}";
//    }
//    return "��ȡʧ��";
//});
//app.MapGet("/set/{id}", (IMemoryCache memoryCache, string id) =>
//{
// var time = memoryCache.Set<string>(id, $"{id}�� {DateTime.Now}", TimeSpan.FromSeconds(50));
//var time = memoryCache.Set<string>(id, $"{id}�� {DateTime.Now}", new MemoryCacheEntryOptions
//{
//    Size = 10,        

//});

//var time = memoryCache.Set<string>(id, $"{id}�� {DateTime.Now}", new MemoryCacheEntryOptions
//{
//    //3���ڲ����ʹ���
//    SlidingExpiration = TimeSpan.FromSeconds(3),
//    //�������3����һֱ�з��ʣ���30�����
//    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),

//});




//  return $"���õ�ʱ��Ϊ��{time}";
//});
app.MapGet("/disget/{id}", async (IDistributedCache distributedCache, string id) =>
 {

     var result = await distributedCache.GetStringAsync(id);
     return $"��ȡ�ɹ���{result}";

 });
app.MapGet("/disset/{id}", async (IDistributedCache distributedCache, string id) =>
{
    var time = $"{id}�� {DateTime.Now}";
    await distributedCache.SetStringAsync(id, time, new DistributedCacheEntryOptions
    {
        SlidingExpiration = TimeSpan.FromSeconds(5),
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)

    });

    return $"���õ�ʱ��Ϊ��{time}";
});
app.Run();
