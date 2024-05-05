using eProdaja.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< Updated upstream
//builder.Services.AddTransient<IProizvodiService, ProizvodiService>();
builder.Services.AddTransient<IProizvodiService, DummyProizvodiService>();
=======
builder.Services.AddTransient<IProizvodiService, ProizvodiService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IVrsteProizvodaService, VrsteProizvodaService>();

>>>>>>> Stashed changes


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
