using AutoDispatcher.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Базовый контроллер для CRUD-операций над сущностями
/// </summary>
/// <typeparam name="TDto">Dto для просмотра сущности</typeparam>
/// <typeparam name="TCreateUpdateDto">Dto для апдейта сущности</typeparam>
/// <typeparam name="TKey">Тип праймари ключа сущности</typeparam>
/// <param name="crudService">Служба, имплементирующая дженерик интерфейс ICrudService</param>
[Route("api/[controller]")]
[ApiController]
public abstract class CrudControllerBase<TDto, TCreateUpdateDto, TKey>(ICrudService<TDto, TCreateUpdateDto, TKey> crudService) : ControllerBase
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Добавление новой записи
    /// </summary>
    /// <param name="newDto">Новые данные</param>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Create(TCreateUpdateDto newDto)
    {
        try
        {
            var res = await crudService.Create(newDto);
            return res != null ? Ok(res) : StatusCode(400);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Изменение имеющихся данных
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="newDto">Измененные данные</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Edit(TKey id, TCreateUpdateDto newDto)
    {
        try
        {
            var res = await crudService.Update(id, newDto);
            return res != null ? Ok(res) : StatusCode(400);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Удаление данных
    /// </summary>
    /// <param name="id">Идентификатор</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(TKey id)
    {
        try
        {
            var res = await crudService.Delete(id);
            return res ? Ok() : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение списка всех данных
    /// </summary>
    /// <returns>Список всех данных</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<TDto>>> GetAll()
    {
        try
        {
            var res = await crudService.GetList();
            return Ok(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получение данных по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Данные</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Get(TKey id)
    {
        try
        {
            var res = await crudService.GetById(id);
            return res != null ? Ok(res) : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

}
