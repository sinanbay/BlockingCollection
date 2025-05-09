using WebApplicationBlockingCollection.Queue.Base;
using WebApplicationBlockingCollection.Queue.JobQueue;
using WebApplicationBlockingCollection.Queue.Processor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IXJobQueue, XJobQueue>();
builder.Services.AddSingleton<IYJobQueue, YJobQueue>();
builder.Services.AddScoped<IXJobProcessor<long>, XJobProcessor>();
/*
key ile de kullanýmý mevcut.
services.AddKeyedSingleton<IJobQueue<Job>, JobQueue<Job>>("X");
services.AddKeyedSingleton<IJobQueue<Job>, JobQueue<Job>>("Y");
 */

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
