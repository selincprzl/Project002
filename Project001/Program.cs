using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using Project002.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

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
            builder.Services.AddScoped<IFrontPageRepository, FrontRepo>();
            builder.Services.AddScoped<ISamuraiRepository, SamuraiRepo>();
            builder.Services.AddScoped<IWarRepository, WarRepo>();
            builder.Services.AddScoped<IClanRepository, ClanRepo>();
            builder.Services.AddScoped<IWeaponRepository, WeaponRepo>();
            builder.Services.AddScoped<IHorseRepository, HorseRepo>();
            builder.Services.AddScoped<IArmourRepository, ArmourRepo>();
           


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<Dbcontext>(obj => obj.UseSqlServer(conStr));
            builder.Services.AddDbContext<Dbcontext>(options => options.UseSqlServer(conStr));

            //builder.Services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);




            //cors thread problems
            builder.Services.AddCors(options =>
                    {
                        options.AddPolicy("coffee",
                                              policy =>
                                              {
                                                  policy.WithOrigins().AllowAnyOrigin()
                                                                      .AllowAnyMethod()
                                                                      .AllowAnyHeader();
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
    

