using AutoMapper;
using Common.DTOs;
using Data.Entities;
using Data.Interface;
using Data.Models;
using Data.Service;
using System.IO;

namespace ArtGallery
{
    public class Statics
    {
        public static void MapperConfiguration(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtImage, ArtImageDTO>().ReverseMap();
            cfg.CreateMap<Login, LoginDTO>().ReverseMap();
            cfg.CreateMap<SignUp, SignUpDTO>().ReverseMap();
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddScoped<IDbService, DbService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("https://localhost:44487")
                                      .AllowAnyHeader()
                                      .AllowCredentials()
                      .WithExposedHeaders("Header1", "Header2"));
            });
        }
    }
}
