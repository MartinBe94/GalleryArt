var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Statics.MapperConfiguration(builder.Services);
Statics.RegisterCustomServices(builder.Services);


builder.Services.AddDbContext<ArtGalleryContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("ProjectArtGalleryConnection")));


//string connString = builder.Configuration.GetConnectionString(
//    builder.Environment.IsDevelopment() ? "PosterWallLocalConnection" : "PosterWallConnection");

//builder.Services.AddDbContext<ArtGalleryContext>(
//    opt => opt.UseMySql(
//        connString, ServerVersion.AutoDetect(connString)));

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
