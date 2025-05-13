using AutoMapper;
using BookStore.Application.Contracts;
using BookStore.Application.Contracts.Author;
using BookStore.Domain.Model;
using BookStore.Domain.Services;

namespace BookStore.Application.Services;

/// <summary>
///     Сервис для работы с авторами книг
/// </summary>
/// <remarks>
///     Реализует CRUD операции и аналитику для авторов.
///     Использует AutoMapper для преобразования между DTO и доменными моделями.
/// </remarks>
/// <param name="repository">Репозиторий для работы с данными авторов</param>
/// <param name="mapper">Маппер для преобразования объектов</param>
public class AuthorCrudService(IAuthorRepository repository, IMapper mapper)
    : ICrudService<AuthorDto, AuthorCreateUpdateDto, int>, IAnalyticsService
{
    /// <summary>
    ///     Получает топ-5 авторов по количеству страниц
    /// </summary>
    /// <returns>Список кортежей (имя автора, количество страниц)</returns>
    public async Task<IList<Tuple<string, int>>> GetTop5AuthorsByPageCount()
    {
        return await repository.GetTop5AuthorsByPageCount();
    }

    /// <summary>
    ///     Получает последние 5 книг автора
    /// </summary>
    /// <param name="key">Идентификатор автора</param>
    /// <returns>Список кортежей (название книги, количество страниц)</returns>
    public async Task<IList<Tuple<string, int>>> GetLast5AuthorsBook(int key)
    {
        return await repository.GetLast5AuthorsBook(key);
    }

    /// <summary>
    ///     Создает нового автора
    /// </summary>
    /// <param name="newDto">Данные для создания автора</param>
    /// <returns>DTO созданного автора</returns>
    public async Task<AuthorDto> Create(AuthorCreateUpdateDto newDto)
    {
        Author? newAuthor = mapper.Map<Author>(newDto);
        Author? res = await repository.Add(newAuthor);
        return mapper.Map<AuthorDto>(res);
    }

    /// <summary>
    ///     Удаляет автора по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор автора</param>
    /// <returns>True если удаление успешно, иначе False</returns>
    public async Task<bool> Delete(int id)
    {
        return await repository.Delete(id);
    }

    /// <summary>
    ///     Получает автора по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор автора</param>
    /// <returns>DTO автора или null если не найден</returns>
    public async Task<AuthorDto?> GetById(int id)
    {
        Author? author = await repository.Get(id);
        return mapper.Map<AuthorDto>(author);
    }

    /// <summary>
    ///     Получает список всех авторов
    /// </summary>
    /// <returns>Список DTO авторов</returns>
    public async Task<IList<AuthorDto>> GetList()
    {
        return mapper.Map<List<AuthorDto>>(await repository.GetAll());
    }

    /// <summary>
    ///     Обновляет данные автора
    /// </summary>
    /// <param name="key">Идентификатор автора</param>
    /// <param name="newDto">Новые данные автора</param>
    /// <returns>DTO обновленного автора</returns>
    public async Task<AuthorDto> Update(int key, AuthorCreateUpdateDto newDto)
    {
        Author? newAuthor = mapper.Map<Author>(newDto);
        await repository.Update(newAuthor);
        return mapper.Map<AuthorDto>(newAuthor);
    }
}