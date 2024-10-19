using CarBook.Application.Features.CQRS.Abouts.Handlers.Read;
using CarBook.Application.Features.CQRS.Abouts.Handlers.Write;
using CarBook.Application.Features.CQRS.Banners.Handlers.Read;
using CarBook.Application.Features.CQRS.Banners.Handlers.Write;
using CarBook.Application.Features.CQRS.Brands.Handlers.Read;
using CarBook.Application.Features.CQRS.Brands.Handlers.Write;
using CarBook.Application.Features.CQRS.Cars.Handlers.Read;
using CarBook.Application.Features.CQRS.Cars.Handlers.Write;
using CarBook.Application.Features.CQRS.Categories.Handlers.Read;
using CarBook.Application.Features.CQRS.Categories.Handlers.Write;
using CarBook.Application.Features.CQRS.Contacts.Handlers.Read;
using CarBook.Application.Features.CQRS.Contacts.Handlers.Write;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Application.Servicess;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.StatisticsRepositories;
using CarBook.Persistence.Repositories.TagCloudRepositories;

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
            builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository)); 
            builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository)); 
            builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository)); 
            builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository)); 
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>)); 
            builder.Services.AddScoped(typeof(IStatisticsRepository),typeof(StatisticsRepository)); 
            builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository)); 


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

            builder.Services.AddScoped<GetBrandByIdQueryHandler>();
            builder.Services.AddScoped<GetBrandQueryHandler>();
            builder.Services.AddScoped<CreateBrandCommendHandler>();
            builder.Services.AddScoped<UpdateBrandCommendHandler>();
            builder.Services.AddScoped<RemoveBrandCommendHandler>();

            builder.Services.AddScoped<GetCarByIdQueryHandler>();
            builder.Services.AddScoped<GetCarQueryHandler>();
            builder.Services.AddScoped<CreateCarCommandHandler>();
            builder.Services.AddScoped<UpdateCarCommandHandler>();
            builder.Services.AddScoped<RemoveCarCommendHandler>();
            builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
            builder.Services.AddScoped<GetCarWithBrandQueryHandler>();

            

            builder.Services.AddScoped<GetContactByIdQueryHandler>();
            builder.Services.AddScoped<GetContactQueryHandler>();
            builder.Services.AddScoped<CreateContactCommandHandler>();
            builder.Services.AddScoped<UpdateContactCommandHandler>();
            builder.Services.AddScoped<RemoveContactCommandHandler>();


			builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
			builder.Services.AddScoped<GetCategoryQueryHandler>();
			builder.Services.AddScoped<CreateCategoryCommandHandler>();
			builder.Services.AddScoped<UpdateCategoryCommandHandler>();
			builder.Services.AddScoped<RemoveCategoryCommandHandler>();


			builder.Services.AddSaveApplicationService(builder.Configuration);





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
