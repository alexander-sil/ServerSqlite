using Server.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
#warning Программист, перед первой сборкой измени строку соединения и отправь миграцию на БД!

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<Repos.IEntryRepository, Repos.EntryRepository>();

        builder.Services.AddDbContext<EntryDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlite("Data Source=Data.db;Cache=Shared");
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

