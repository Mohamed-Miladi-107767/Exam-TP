using BookApi.Data;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapGet("/books", async (BookDb db) => {
    throw new NotImplementedException("This is a test exception.");
});

app.MapPost("/books", async (Book book, BookDb db) => {
    throw new NotImplementedException("This is a test exception.");
});

app.MapPut("/books/{id}", async (int id, BookDb db) => {
    throw new NotImplementedException("This is a test exception.");
});

app.Run();
