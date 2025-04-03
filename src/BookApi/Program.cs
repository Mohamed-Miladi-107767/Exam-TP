using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajouter Entity Framework avec une base de données en mémoire
builder.Services.AddDbContext<BookDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activer Swagger pour tester l'API
app.UseSwagger();
app.UseSwaggerUI();

// Définition des routes API

// Récupérer tous les livres
app.MapGet("/books", async (BookDb db) => await db.Books.ToListAsync());

// Ajouter un nouveau livre
app.MapPost("/books", async (Book book, BookDb db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

// Marquer un livre comme "lu"
app.MapPut("/books/{id}", async (int id, BookDb db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();
    book.IsRead = true;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

// Classe pour le modèle de livre
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
}

// Classe pour la base de données avec Entity Framework Core
public class BookDb : DbContext
{
    public BookDb(DbContextOptions<BookDb> options) : base(options) { }
    public DbSet<Book> Books => Set<Book>();
}
