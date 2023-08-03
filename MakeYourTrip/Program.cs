using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;
using MakeYourTrip.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGenerate, TokenService>();
builder.Services.AddScoped<ICrud<User, UserDTO>, UserRepo>();
builder.Services.AddScoped<IPlaceMasterService, PlaceMasterService>();
builder.Services.AddScoped<ICrud<PlaceMaster, IdDTO>, PlaceMasterRepo>();
builder.Services.AddScoped<IHotelMasterService, HotelMasterService>();
builder.Services.AddScoped<ICrud<HotelMaster, IdDTO>, HotelMasterRepo>();
builder.Services.AddScoped<IPackageMasterService, PackageMasterService>();
builder.Services.AddScoped<ICrud<PackageMaster, IdDTO>, PackageMasterRepo>();
builder.Services.AddScoped<IRoomTypeMasterService, RoomTypeMasterService>();
builder.Services.AddScoped<ICrud<RoomTypeMaster, IdDTO>, RoomTypeMasterRepo>();
builder.Services.AddScoped<IRoomDetailsMasterService, RoomDetailsMasterService>();
builder.Services.AddScoped<ICrud<RoomDetailsMaster, IdDTO>, RoomDetailsMasterRepo>();
builder.Services.AddScoped<IVehicleMasterService, VehicleMasterService>();
builder.Services.AddScoped<ICrud<VehicleMaster, IdDTO>, VehicleMasterRepo>();
builder.Services.AddScoped<IVehicleDetailsMasterService, VehicleDetailsMasterService>();
builder.Services.AddScoped<ICrud<VehicleDetailsMaster, IdDTO>, VehicleDetailsMasterRepo>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICrud<Booking, IdDTO>, BookingRepo>();
builder.Services.AddScoped<IVehicleBookingService, VehicleBookingService>();
builder.Services.AddScoped<ICrud<VehicleBooking, IdDTO>, VehicleBookingRepo>();
builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
builder.Services.AddScoped<ICrud<RoomBooking, IdDTO>, RoomBookingRepo>();
builder.Services.AddScoped<IPackageDetailsMasterService, PackageDetailsMasterService>();
builder.Services.AddScoped<ICrud<PackageDetailsMaster, IdDTO>, PackageDetailsMasterRepo>();
builder.Services.AddScoped<IImageRepo<PackageMaster, PackageFormModel>, PackageMasterRepo>();
builder.Services.AddScoped<IImageRepo<PackageDetailsMaster, PlaceFormModel>, PackageDetailsMasterRepo>();
builder.Services.AddScoped<IImageRepo<VehicleDetailsMaster, VehicleFormModel>, VehicleDetailsMasterRepo>();
builder.Services.AddScoped<IImageRepo<HotelMaster, HotelFormModule>, HotelMasterRepo>();


















builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
});



builder.Services.AddDbContext<MakeYourTripContext>(
    optionsAction: options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "SQLConnection")));

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularCORS");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
