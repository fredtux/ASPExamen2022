using Examen2022.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>();

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
    name: "AddArticle",
    pattern: "Articles/Add",
    defaults: new {controller = "Articles", action="Add"}
    );

app.MapControllerRoute(
    name: "ShowArticle",
    pattern: "Articles/Show/{aid}",
    defaults: new { controller = "Articles", action = "Show" }
    );

app.MapControllerRoute(
    name: "IndexArticle",
    pattern: "Articles/Index",
    defaults: new { controller = "Articles", action = "Index" }
    );

app.MapControllerRoute(
    name: "EditArticle",
    pattern: "Articles/Edit/{aid}",
    defaults: new { controller = "Articles", action = "Edit" }
    );

app.MapControllerRoute(
    name: "DeleteArticle",
    pattern: "Articles/Delete/{aid}",
    defaults: new { controller = "Articles", action = "Delete" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
