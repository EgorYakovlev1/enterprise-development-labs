using BookStore.Application.Contracts;
using BookStore.Application.Contracts.Author;

namespace BookStore.Server.Controllers;

/// <summary>
///     Контроллер для CRUD-операций над авторами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class AuthorController(ICrudService<AuthorDto, AuthorCreateUpdateDto, int> crudService)
    : CrudControllerBase<AuthorDto, AuthorCreateUpdateDto, int>(crudService);