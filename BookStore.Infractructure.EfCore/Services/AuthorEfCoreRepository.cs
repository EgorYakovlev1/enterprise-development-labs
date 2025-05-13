using BookStore.Domain.Model;
using BookStore.Domain.Services;
using BookStore.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.Infractructure.EfCore.Services;

public class AuthorEfCoreRepository(BookStoreDbContext context) : IAuthorRepository
{
    private readonly DbSet<Author> _authors = context.Authors;

    public async Task<Author> Add(Author entity)
    {
        EntityEntry<Author>? result = await _authors.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int key)
    {
        Author? entity = await _authors.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
        {
            return false;
        }

        _authors.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Author?> Get(int key)
    {
        return await _authors.FirstOrDefaultAsync(e => e.Id == key);
    }


    public async Task<IList<Author>> GetAll()
    {
        return await _authors.ToListAsync();
    }

    public async Task<Author> Update(Author entity)
    {
        _authors.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }

    public async Task<IList<Tuple<string, int>>> GetLast5AuthorsBook(int key)
    {
        Author? author = await context.Authors.FirstOrDefaultAsync(e => e.Id == key);
        var books = new List<Book>();
        if (author != null && author.BookAuthors != null)
        {
            foreach (var ba in author.BookAuthors)
            {
                if (ba != null && ba.Book != null)
                {
                    books.Add(ba.Book);
                }
            }
        }

        return books.ToArray()
            .OrderByDescending(book => book.Year)
            .Take(5)
            .Select(book => new Tuple<string, int>(book.ToString(), book.Year ?? 0))
            .ToList();
    }

    public async Task<IList<Tuple<string, int>>> GetTop5AuthorsByPageCount()
    {
        return (await _authors.ToArrayAsync())
            .OrderByDescending(author => author.GetPageCount())
            .Take(5)
            .Select(author => new Tuple<string, int>(author.ToString(), author.GetPageCount() ?? 0))
            .ToList();
    }
}