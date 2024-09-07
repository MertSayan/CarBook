
using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Abouts.Handlers.Read;
using CarBook.Application.Features.Abouts.Handlers.Write;
using CarBook.Application.Features.Banners.Handlers.Read;
using CarBook.Application.Features.Banners.Handlers.Write;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

namespace CarBook.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<CarBookContext>();
            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); 


            builder.Services.AddScoped<GetAboutQueryHandler>();
            builder.Services.AddScoped<GetAboutByIdQueryHandler>();
            builder.Services.AddScoped<CreateAboutCommendHandler>();
            builder.Services.AddScoped<UpdateAboutCommandHandler>();
            builder.Services.AddScoped<RemoveAboutCommandHandler>();

            builder.Services.AddScoped<GetBannerByIdQueryHandler>();
            builder.Services.AddScoped<GetBannerQueryHandler>();
            builder.Services.AddScoped<CreateBannerCommandHandler>();
            builder.Services.AddScoped<UpdateBannerCommandHandler>();
            builder.Services.AddScoped<RemoveBannerCommandHandler>();

            //builder.Services.AddScoped(typeof(BaseHandler<>));


            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
