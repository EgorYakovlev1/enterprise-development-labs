using AutoMapper;
using BookStore.Application.Contracts.Author;
using BookStore.Application.Contracts.Book;
using BookStore.Application.Contracts.BookAuthor;
using BookStore.Domain.Model;

namespace BookStore.Application;

/// <summary>
///     Профиль AutoMapper для маппинга между доменными моделями и DTO
/// </summary>
/// <remarks>
///     Содержит маппинги для:
///     - Author и AuthorDto (включая CreateUpdateDto)
///     - Book и BookDto (включая CreateUpdateDto)
///     - BookAuthor и BookAuthorDto (включая CreateUpdateDto)
///     Используется для автоматического преобразования объектов между слоями приложения
/// </remarks>
public class AutoMapperProfile : Profile
{
    /// <summary>
    ///     Инициализирует новый экземпляр профиля AutoMapper
    /// </summary>
    /// <remarks>
    ///     В конструкторе настраиваются все необходимые маппинги между:
    ///     - Доменной моделью и DTO для чтения
    ///     - DTO для создания/обновления и доменной моделью
    /// </remarks>
    public AutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorCreateUpdateDto, Author>();

        CreateMap<Book, BookDto>();
        CreateMap<BookCreateUpdateDto, Book>();

        CreateMap<BookAuthor, BookAuthorDto>();
        CreateMap<BookAuthorCreateUpdateDto, BookAuthor>();
    }
}