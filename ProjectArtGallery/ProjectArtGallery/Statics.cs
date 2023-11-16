using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using IdentityRole = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;

namespace ProjectArtGallery
{
    public class Statics
    {
        public static void MapperConfiguration(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User,UserDTO>().ReverseMap();
                cfg.CreateMap<Registration,RegistrationDTO>().ReverseMap();
                cfg.CreateMap<Login,LoginDTO>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }


        public static void RegisterCustomServices(IServiceCollection services)
        {

            // Add Identity
            //services.AddIdentity<User, IdentityRole>();
            // Optional: Configure Identity options if needed
            services.Configure<IdentityOptions>(options =>
            {
                // Configure identity options here
            });

            // Optional: Configure password policies
            services.Configure<IdentityOptions>(options =>
            {
                // Configure password policies here
            });
        }

    }
}
