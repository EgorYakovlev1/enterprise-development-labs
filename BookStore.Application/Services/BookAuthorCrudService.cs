using AutoMapper;
using BookStore.Application.Contracts;
using BookStore.Application.Contracts.BookAuthor;
using BookStore.Domain.Model;
using BookStore.Domain.Services;

namespace BookStore.Application.Services;

/// <summary>
///     Служба слоя приложения для манипуляции над связью авторов и книг
/// </summary>
/// <param name="repository">Доменная служба для связей</param>
/// <param name="bookRepository">Доменная служба для книг</param>
/// <param name="authorRepository">Доменная служба для авторов</param>
/// <param name="mapper">Автомаппер</param>
public class BookAuthorCrudService(IRepository<BookAuthor, int> repository, IMapper mapper)
    : ICrudService<BookAuthorDto, BookAuthorCreateUpdateDto, int>
{
    public async Task<BookAuthorDto> Create(BookAuthorCreateUpdateDto newDto)
    {
        BookAuthor? newBookAuthor = mapper.Map<BookAuthor>(newDto);
        BookAuthor? res = await repository.Add(newBookAuthor);
        return mapper.Map<BookAuthorDto>(res);
    }

    public async Task<bool> Delete(int id)
    {
        return await repository.Delete(id);
    }


    public async Task<BookAuthorDto?> GetById(int id)
    {
        BookAuthor? bookAuthor = await repository.Get(id);
        return mapper.Map<BookAuthorDto>(bookAuthor);
    }

    public async Task<IList<BookAuthorDto>> GetList()
    {
        return mapper.Map<List<BookAuthorDto>>(await repository.GetAll());
    }

    public async Task<BookAuthorDto> Update(int key, BookAuthorCreateUpdateDto newDto)
    {
        BookAuthor? newBookAuthor = mapper.Map<BookAuthor>(newDto);
        BookAuthor? res = await repository.Update(newBookAuthor);
        return mapper.Map<BookAuthorDto>(res);
    }
}