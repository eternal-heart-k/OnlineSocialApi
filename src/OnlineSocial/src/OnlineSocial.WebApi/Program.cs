using Microsoft.EntityFrameworkCore;
using OnlineSocial.Application.Interface;
using OnlineSocial.Application.Service;
using OnlineSocial.Foundation;
using OnlineSocial.User.Infrastructure.DbContexts;
using OnlineSocial.User.Service;
using OnlineSocial.User.Interface.Query;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;

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
    // ע��Service����
    Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name);//��������������
    builder.RegisterAssemblyTypes(assembly)
    .AsImplementedInterfaces()
    .InstancePerDependency();
});
/*#region ע�����ݿ�

builder.Services.AddTransient<UserDbContext>();

#endregion*/

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserQuery, UserQuery>();

//builder.Services.AddDataService();

// ��������������Դ����
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
//����Сд·��
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ��������������Դ����
app.UseCors("all");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(op =>
    {
        //չʾִ��ʱ��ms
        op.DisplayRequestDuration();
        //�ı�URL
        op.EnableDeepLinking();
    });
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
