var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("MyHttpClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7118");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Genel hata sayfasý
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();  // Geliþtirme ortamýnda hata sayfasý
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Error handling route (404 sayfasý)
app.MapFallbackToController("NotFound", "Error");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
