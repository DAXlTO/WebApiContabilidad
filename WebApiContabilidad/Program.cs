using Microsoft.EntityFrameworkCore;
using WebApiContabilidad.Contexts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(setupAction =>
    setupAction.AddPolicy("MyPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    ));


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings")));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();