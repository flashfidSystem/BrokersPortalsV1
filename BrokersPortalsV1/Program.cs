using BrokersPortalsV1.Class;
using BrokersPortalsV1.Security.Filter;
using BrokersPortalsV1.Session;
using Microsoft.Net.Http.Headers;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionHandler>(); 
builder.Services.AddTransient<CustomAuthenticationFilter>();
builder.Services.AddScoped<ISessionHandler, SessionHandler>();
//builder.Services.AddScoped<IUserPermission, UserPermissionTo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CustomAuthenticationFilter>();
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient(name:"BrokersPortal", configureClient: client =>
//{
//    client.BaseAddress =new Uri("https://localhost:7244");
//    client.DefaultRequestHeaders.Add("ContentType", "application/json");
//    var byteArray = System.Text.Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321"); 
//    client.DefaultRequestHeaders.Authorization= new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

//});
//builder.Services.AddHttpClient("BrokersPortal", httpClient =>
//{
//    httpClient.BaseAddress = new Uri("https://localhost:7244/");

//    using Microsoft.Net.Http.Headers;
//    The GitHub API requires two headers.
//    httpClient.DefaultRequestHeaders.Add(
//        HeaderNames.Accept, "ContentType\", \"application/json");
//    var byteArray = System.Text.Encoding.UTF8.GetBytes("Brokers.Portal.Frontend:bp4321");
//    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

//});
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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
