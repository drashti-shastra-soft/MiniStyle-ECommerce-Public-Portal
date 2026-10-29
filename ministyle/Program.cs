using ministyle.Domain;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;
using ministyle.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IOrderLineService, OrderLineService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSizeChartService, ProductSizeChartService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.Configure<ministyle.Domain.AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddHttpClient();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Add route for the area
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Authentication}/{action=Index}/{id?}"
);

// Add route for the area
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
