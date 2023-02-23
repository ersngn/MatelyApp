using Mately.Core.Configs;
using Mately.Core.Mapper;
using Mately.Core.Services.Uri;
using Mately.Services.Match.API.ServiceRegistration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Automapper
builder.Services.AddAutoMapper(typeof(MatchMapperProfile));
#endregion

builder.Services.AddHttpContextAccessor();
builder.Services.AddServiceDependencies(builder.Configuration);

builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoConfig>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<IMongoConfig>(sp => sp.GetRequiredService<IOptions<MongoConfig>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();