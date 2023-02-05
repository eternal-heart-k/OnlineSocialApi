using Microsoft.EntityFrameworkCore;
using OnlineSocial.Application.Interface;
using OnlineSocial.Application.Service;
using OnlineSocial.Foundation;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using OnlineSocial.UserProfile.Service;
using OnlineSocial.UserProfile.Infrastructure.DbContexts;
using OnlineSocial.UserProfile.Interface.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DbContext Options
builder.Services.AddDbContext<UserDbContext>(op => {
    string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    op.UseMySql(connectionString, serverVersion);
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    // 注入Service程序集
    Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name);//可以是其他程序集
    builder.RegisterAssemblyTypes(assembly)
    .AsImplementedInterfaces()
    .InstancePerDependency();
});
/*#region 注册数据库

builder.Services.AddTransient<UserDbContext>();

#endregion*/

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserQuery, UserQuery>();

//builder.Services.AddDataService();

// 设置允许所有来源跨域
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    {
        builder.AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowCredentials();
    });
});
//配置小写路由
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 设置允许所有来源跨域
app.UseCors("all");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(op =>
    {
        //展示执行时间ms
        op.DisplayRequestDuration();
        //改变URL
        op.EnableDeepLinking();
    });
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
