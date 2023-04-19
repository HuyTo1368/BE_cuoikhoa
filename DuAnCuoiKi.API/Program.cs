using DuAnCuoiKi.DL.AuthDL;
using DuAnCuoiKi.DL;
using DuAnCuoiKi.BL.Auth;
using DuAnCuoiKi.BL.UserBL;
using DuAnCuoiKi.DL.UserDL;
using DuAnCuoiKi.DL.Posts;
using DuAnCuoiKi.BL.APosts;
using DuAnCuoiKi.DL.Comment;
using DuAnCuoiKi.BL.Comment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DuAnCuoiKi.Common.DTO;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().AllowCredentials().Build());
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ConfigJWT.ISSUER,
            ValidAudience = ConfigJWT.AUDIENCE,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigJWT.SECRECTKEY))
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginBL, LoginBL>();
builder.Services.AddScoped<ILoginDL, LoginDL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDL, UserDL>();
builder.Services.AddScoped<IPostsDL, PostsDL>();
builder.Services.AddScoped<IPostBL, PostBL>();
builder.Services.AddScoped<ICommentDL, CommentDL>();
builder.Services.AddScoped<ICommentBL, CommentBL>();




DataContext.MySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
