using BookStore.Application.Contracts;
using BookStore.Application.Contracts.Book;

namespace BookStore.Server.Controllers;

/// <summary>
///     Контроллер для CRUD-операций над авторами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class BookController(ICrudService<BookDto, BookCreateUpdateDto, int> crudService)
    : CrudControllerBase<BookDto, BookCreateUpdateDto, int>(crudService);