using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Chtoto.Service;
using Chtoto.Domain.Enteties.Repositories.Abstract;
using Chtoto.Domain.Enteties.Repositories.EntityFramework;
using Chtoto.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//��������� MVC
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

//��������� �������� ����������� ��� AdminArea
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//�������� ��
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

//��������� identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//��������� ����
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

//connect config
builder.Configuration.Bind("Project", new Config());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())

{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//���������� ������� �������������
app.UseRouting();

//��������� ��������� ������ (js, css � ��)
app.UseStaticFiles();

//���������� �������������� � �����������
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();

//����������� ������ ���������
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();