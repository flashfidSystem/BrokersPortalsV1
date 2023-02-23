using BrokersPortalsV1.Class;
using BrokersPortalsV1.Security.Filter;
using BrokersPortalsV1.Session;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionHandler>();
builder.Services.AddTransient<CustomAuthenticationFilter>();
builder.Services.AddScoped<ISessionHandler,SessionHandler>();
builder.Services.AddScoped<IUserPermission,UserPermissionTo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<CustomAuthenticationFilter>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".BrokersPortals.Session";
    options.IdleTimeout = TimeSpan.FromHours(120);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//else 
//{
//    app.UseExceptionHandler("/Account/Login");
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
