using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: "Policy1",
    //        builder =>
    //        {
    //            builder
    //            .WithOrigins("http://localhost:5280")               
    //            .AllowAnyMethod()
    //            .AllowAnyHeader()
    //            ;
    //        });

    //options.AddPolicy(name: "Policy2",
    //            builder =>
    //            {
    //                builder
    //                .WithOrigins("http://localhost:5280")
    //                .WithMethods("PUT")
    //                ;
    //            });
    //options.AddPolicy(name: "Policy3",
    //        builder =>
    //        {
    //            builder.WithOrigins("http://localhost:5280")
    //            .WithHeaders("x-cors-header")
    //            .AllowAnyMethod()
    //            ;
    //        });
    options.AddPolicy(name: "Policy4",
            builder =>
            {
                builder.WithOrigins("http://localhost:5280")
                //.AllowCredentials()
                .AllowAnyMethod()
                ;
            });
});

var app = builder.Build();

app.UseCors();

//app.MapGet("/test1", () => "get�Ľ��");
//app.MapPost("/test1", () => "post�Ľ��");
//app.MapDelete("/test1", [DisableCors]() => "delete�Ľ��");
//app.MapPut("/test1", () => "put�Ľ��");
//app.Map("/test1", () =>
//{
//   return "mapȫ��";
//});

//app.MapGet("/test2", [EnableCors("Policy2")] () => "get�Ľ��");
//app.MapPost("/test2", [EnableCors("Policy2")] () => "post�Ľ��");
//app.MapDelete("/test2", [EnableCors("Policy2")] () => "delete�Ľ��");
//app.MapPut("/test2", [EnableCors("Policy2")] () => "put�Ľ��");
//app.Map("/test2", [EnableCors("Policy2")] () => "mapȫ��");

//app.MapGet("/test3", [EnableCors("Policy3")] () => "get�Ľ��");
//app.MapPost("/test3", [EnableCors("Policy3")] () => "post�Ľ��");
//app.MapDelete("/test3", [EnableCors("Policy3")] () => "delete�Ľ��");
//app.MapPut("/test3", [EnableCors("Policy3")] () => "put�Ľ��");
//app.Map("/test3", [EnableCors("Policy3")] () => "mapȫ��");

app.MapGet("/test4", [EnableCors("Policy4")] () => "get�Ľ��");
app.MapPost("/test4", [EnableCors("Policy4")] () => "post�Ľ��");
app.MapDelete("/test4", [EnableCors("Policy4")] () => "delete�Ľ��");
app.MapPut("/test4", [EnableCors("Policy4")] () => "put�Ľ��");
app.Map("/test4", [EnableCors("Policy4")] () => "mapȫ��");
app.Run();

