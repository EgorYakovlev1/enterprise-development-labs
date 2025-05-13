using BookStore.Application.Contracts;
using BookStore.Application.Contracts.BookAuthor;

namespace BookStore.Server.Controllers;

/// <summary>
///     Контроллер для CRUD-операций над авторами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class BookAuthorController(ICrudService<BookAuthorDto, BookAuthorCreateUpdateDto, int> crudService)
    : CrudControllerBase<BookAuthorDto, BookAuthorCreateUpdateDto, int>(crudService);