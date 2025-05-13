using BookStore.Domain.Data;
using BookStore.Domain.Model;

namespace BookStore.Domain.Services.InMemory;

/// <summary>
///     Имплементация репозитория для книг, которая хранит коллекцию в оперативной памяти
/// </summary>
public class BookInMemoryRepository : IRepository<Book, int>
{
    private readonly List<Book> _books;

    /// <summary>
    ///     Конструктор репозитория
    /// </summary>
    public BookInMemoryRepository()
    {
        _books = DataSeeder.Books;
    }

    /// <inheritdoc />
    public Task<Book> Add(Book entity)
    {
        try
        {
            _books.Add(entity);
        }
        catch
        {
            return null!;
        }

        return Task.FromResult(entity);
    }

    /// <inheritdoc />
    public async Task<bool> Delete(int key)
    {
        try
        {
            Book? book = await Get(key);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <inheritdoc />
    public Task<Book?> Get(int key)
    {
        return Task.FromResult(_books.FirstOrDefault(item => item.Id == key));
    }

    /// <inheritdoc />
    public Task<IList<Book>> GetAll()
    {
        return Task.FromResult((IList<Book>)_books);
    }

    /// <inheritdoc />
    public async Task<Book> Update(Book entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }

        return entity;
    }
}