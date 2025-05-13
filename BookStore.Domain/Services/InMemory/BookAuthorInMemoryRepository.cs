using BookStore.Domain.Data;
using BookStore.Domain.Model;

namespace BookStore.Domain.Services.InMemory;

/// <summary>
///     Имплементация репозитория для связующей сущности книг и авторов, которая хранит коллекцию в оперативной памяти
/// </summary>
public class BookAuthorInMemoryRepository : IRepository<BookAuthor, int>
{
    private readonly List<BookAuthor> _bookAuthors;

    /// <summary>
    ///     Конструктор репозитория
    /// </summary>
    public BookAuthorInMemoryRepository()
    {
        _bookAuthors = DataSeeder.BookAuthors;
    }

    /// <inheritdoc />
    public Task<BookAuthor> Add(BookAuthor entity)
    {
        try
        {
            _bookAuthors.Add(entity);
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
            BookAuthor? bookAuthor = await Get(key);
            if (bookAuthor != null)
            {
                _bookAuthors.Remove(bookAuthor);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <inheritdoc />
    public Task<BookAuthor?> Get(int key)
    {
        return Task.FromResult(_bookAuthors.FirstOrDefault(item => item.Id == key));
    }

    /// <inheritdoc />
    public Task<IList<BookAuthor>> GetAll()
    {
        return Task.FromResult((IList<BookAuthor>)_bookAuthors);
    }

    /// <inheritdoc />
    public async Task<BookAuthor> Update(BookAuthor entity)
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