using Contacts_List.Domain.Entities;
using Contacts_List.Infrastructure;
using Contacts_List.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(
       options =>
       {
           options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsListConnection"));
       });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(new string[] { "http://localhost:8080", "test" });
    });
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                   };
               }
               );

builder.Services.AddInfrastructure();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Context>();

    var connection = db.Database.GetDbConnection();
    var databaseName = connection.Database;

    using (var masterConnection = new SqlConnection(connection.ConnectionString.Replace(databaseName, "master")))
    {
        masterConnection.Open();
        using (var command = masterConnection.CreateCommand())
        {
            command.CommandText = $"IF DB_ID('{databaseName}') IS NULL CREATE DATABASE [{databaseName}]";
            command.ExecuteNonQuery();
        }
    }

    db.Database.Migrate();

    // --- Seed Categories ---
    if (!db.Category.Any())
    {
        var categories = new List<Category>
        {
            new() { Name = "Rodzina" },
            new() { Name = "Przyjaciele" },
            new() { Name = "Praca" },
            new() { Name = "Inne" }
        };
        db.Category.AddRange(categories);
        db.SaveChanges();
    }

    // --- Seed Contacts ---
    if (!db.Contacts.Any())
    {
        var random = new Random();
        var categories = db.Category.ToList();

        var contacts = new List<Contact>();

        for (int i = 0; i < 20; i++)
        {
            var category = categories[random.Next(categories.Count)];
            contacts.Add(new Contact
            {
                FirstName = $"Jan{i}",
                LastName = $"Kowalski{i}",
                Email = $"user{i}@example.com",
                PhoneNumber = $"123-456-78{i:D2}",
                DateOfBirth = DateTime.Now.AddYears(-random.Next(18, 50)).AddDays(random.Next(0, 365)),
                CategoryId = category.CategoryId,
                IsDeleted = false
            });
        }

        db.Contacts.AddRange(contacts);
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
