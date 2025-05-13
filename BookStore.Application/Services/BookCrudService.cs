using AutoMapper;
using BookStore.Application.Contracts;
using BookStore.Application.Contracts.Book;
using BookStore.Domain.Model;
using BookStore.Domain.Services;

namespace BookStore.Application.Services;

/// <summary>
///     Служба слоя приложения для манипуляции над книгами
/// </summary>
/// <param name="repository">Доменная служба для книг</param>
/// <param name="mapper">Автомаппер</param>
public class BookCrudService(IRepository<Book, int> repository, IMapper mapper)
    : ICrudService<BookDto, BookCreateUpdateDto, int>
{
    public async Task<BookDto> Create(BookCreateUpdateDto newDto)
    {
        Book? newBook = mapper.Map<Book>(newDto);
        newBook.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        Book? res = await repository.Add(newBook);
        return mapper.Map<BookDto>(res);
    }

    public async Task<bool> Delete(int id)
    {
        return await repository.Delete(id);
    }

    public async Task<BookDto?> GetById(int id)
    {
        Book? book = await repository.Get(id);
        return mapper.Map<BookDto>(book);
    }

    public async Task<IList<BookDto>> GetList()
    {
        return mapper.Map<List<BookDto>>(await repository.GetAll());
    }

    public async Task<BookDto> Update(int key, BookCreateUpdateDto newDto)
    {
        Book? newBook = mapper.Map<Book>(newDto);
        await repository.Update(newBook);
        return mapper.Map<BookDto>(newBook);
    }
}