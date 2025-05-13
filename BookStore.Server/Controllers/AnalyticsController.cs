using BookStore.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers;

/// <summary>
///     Контроллер для выполнения аналитических запросов
/// </summary>
/// <param name="service">Служба для выполнения аналитических запросов</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service) : ControllerBase
{
    /// <summary>
    ///     Получение 5 наиболее продуктивных авторов по числу изданных страниц
    /// </summary>
    /// <returns>Список из кортежей (автор, число страниц)</returns>
    [HttpGet("Top5Authors")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<Tuple<string, int>>>> GetTop5Authors()
    {
        return Ok(await service.GetTop5AuthorsByPageCount());
    }

    /// <summary>
    ///     Получение последних 5 книг выборанного автора
    /// </summary>
    /// <param name="id">Идентификатор автора</param>
    /// <returns>Список из кортежей (книга, год выпуска)</returns>
    [HttpGet("Last5Books/{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<Tuple<string, int>>>> GetLast5Books(int id)
    {
        return Ok(await service.GetLast5AuthorsBook(id));
    }
}