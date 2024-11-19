var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "AllDevelopers",
    pattern: "Developers/All",
    defaults: new { Controller = "Developers", Action = "Index" });
app.MapControllerRoute(
    name: "SpecificDeveloper",
    pattern: "Developers/{developerId:int}",
    defaults: new { Controller = "Developers", Action = "ShowDeveloper" });
app.MapControllerRoute(
    name: "AllGames",
    pattern: "Games/All",
    defaults: new { Controller = "Games", Action = "Index"});
app.MapControllerRoute(
    name: "SpecificGame",
    pattern: "Games/{gameId:int}",
    defaults: new { Controller = "Games", Action = "ShowGame" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
