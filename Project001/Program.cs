using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;

namespace Project001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region add features
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            string conStr = @"Server=DESKTOP-D528M49; Database=Project002; Trusted_Connection=true";

            //DI (Dependency Injection) - activation
            builder.Services.AddScoped<ISamuraiRepository, SamuraiRepo>();
            builder.Services.AddScoped<IWarRepository, WarRepo>();
            builder.Services.AddScoped<IClanRepository, ClanRepo>();
            builder.Services.AddScoped<IWeaponRepository, WeaponRepo>();
            builder.Services.AddScoped<IHorseRepository, HorseRepo>();
            builder.Services.AddScoped<IClothingRepository, ClothingRepo>();
            builder.Services.AddScoped<IArmourRepository, ArmourRepo>();
            builder.Services.AddScoped<IRankRepository, RankRepo>();
            builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepo>();

            builder.Services.AddDbContext<Dbcontext>(obj => obj.UseSqlServer(conStr));

            //cors thread problems
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("coffee",
                                      policy =>
                                      {
                                          policy.WithOrigins().AllowAnyOrigin()
                                                              .AllowAnyMethod()
                                                              .AllowAnyMethod();
                                      });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("coffee");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion add features
        }
    }
}