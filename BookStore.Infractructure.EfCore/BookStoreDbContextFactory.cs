using BookStore.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Infractructure.EfCore;

public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    private const string _connectionString =
        "Server=localhost;Username=root;Password=new_p@ssw0rd;Database=bookstore;Port=3306;Pooling=true;";

    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        return new BookStoreDbContext(optionsBuilder.Options);
    }
}