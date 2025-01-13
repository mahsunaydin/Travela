using Travela.BusinessLayer.Abstract;
using Travela.BusinessLayer.Concrete;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.EntityFramework;
using Travela1.WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // burayý tag helper için ekledim ??

// Add services to the container.

builder.Services.AddDbContext<TravelaContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IDestinationDal, EfDestinationDal>();
builder.Services.AddScoped<IDestinationService, DestinationManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IAboutFeaturesDal, EfAboutFeaturesDal>();
builder.Services.AddScoped<IAboutFeaturesService, AboutFeaturesManager>();

builder.Services.AddScoped<ICarouselDal, EfCarouselDal>();
builder.Services.AddScoped<ICarouselService, CarouselManager>();

builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IGuideDal, EfGuideDal>();
builder.Services.AddScoped<IGuideService, GuideManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IPageHeaderDetailDal, EfPageHeaderDetailDal>();
builder.Services.AddScoped<IPageHeaderDetailService, PageHeaderDetailManager>();

//builder.Services.AddControllers(); mahsun
builder.Services.AddControllersWithViews();
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
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
