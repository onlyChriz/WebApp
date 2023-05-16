using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.API.Interfaces;
using WebApp.API.Repository;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //ADDED
builder.Services.AddEndpointsApiExplorer(); //ADDED
builder.Services.AddSwaggerGen(); //ADDED
builder.Services.AddScoped<IBlogPostsRepository, BlogPostsRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WebAppDbConnectionString")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
<<<<<<< HEAD
    app.UseSwagger();
    app.UseSwaggerUI();
=======

    app.UseSwagger(); //ADDED
    app.UseSwaggerUI(); //ADDED
>>>>>>> main
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
<<<<<<< HEAD
app.MapControllers();
=======
app.MapControllers();//ADDED
>>>>>>> main

app.Run();
