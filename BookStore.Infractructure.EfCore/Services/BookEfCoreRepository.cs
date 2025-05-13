using BookStore.Domain.Model;
using BookStore.Domain.Services;
using BookStore.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.Infractructure.EfCore.Services;

public class BookEfCoreRepository(BookStoreDbContext context) : IRepository<Book, int>
{
    private readonly DbSet<Book> _books = context.Books;

    public async Task<Book> Add(Book entity)
    {
        EntityEntry<Book>? result = await _books.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int key)
    {
        Book? entity = await _books.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
        {
            return false;
        }

        _books.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Book?> Get(int key)
    {
        return await _books.FirstOrDefaultAsync(e => e.Id == key);
    }

    public async Task<IList<Book>> GetAll()
    {
        return await _books.ToListAsync();
    }

    public async Task<Book> Update(Book entity)
    {
        _books.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}