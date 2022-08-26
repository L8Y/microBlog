using mb_lib;
using mb_lib.Interface;
using mb_lib.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IRegister, RegisterServices>();
builder.Services.AddScoped<IPost, PostServices>();
builder.Services.AddScoped<IComments, CommentsServices>();
builder.Services.AddDbContext<bloggingContext>(option => option.UseSqlServer("Data Source=DESKTOP-DNK5RHH\\SQLEXPRESS;Initial Catalog=blogging;Integrated Security=True"));
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
