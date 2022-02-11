using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataProtContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DataProtDB")));
//ͨ��SetDefaultKeyLifetime����Ĭ��ֵ90��
builder.Services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(10)).PersistKeysToDbContext<DataProtContext>();
var app = builder.Build();


app.MapGet("/encrypt/{str}", (IDataProtectionProvider provider, ILogger<Program> logger, string str) =>
{
    var protector = provider.CreateProtector("a.b.c");
    var sec = protector.Protect(str);
    logger.LogInformation(sec);
    return "���ܣ�" + sec;
});
app.MapGet("/decrypt/{sec}", (IDataProtectionProvider provider, ILogger<Program> logger, string sec) =>
{
    var protector = provider.CreateProtector("a.b.c");
    var str = protector.Unprotect(sec);
    logger.LogInformation(str);
    return "���ܣ�" + str;
});

app.Run();


class DataProtContext : DbContext, IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    public DataProtContext(DbContextOptions<DataProtContext> options)
          : base(options)
    {}
}