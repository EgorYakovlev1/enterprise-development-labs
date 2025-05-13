using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Model;

/// <summary>
///     Издание
/// </summary>
public class Book
{
    /// <summary>
    ///     Идентификатор издания
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Название издания
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Аннотация
    /// </summary>
    public string? Annotation { get; set; }

    /// <summary>
    ///     Число страниц
    /// </summary>
    public int? PageCount { get; set; }

    /// <summary>
    ///     Год издания
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    ///     Издательство
    /// </summary>
    public string? Publisher { get; set; }

    /// <summary>
    ///     ISBN
    /// </summary>
    public string? Isbn { get; set; }

    /// <summary>
    ///     Список авторов
    /// </summary>
    public virtual List<BookAuthor>? BookAuthors { get; set; }

    /// <summary>
    ///     Число авторов
    /// </summary>
    public int? AuthorCount => BookAuthors?.Count;

    /// <summary>
    ///     Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Название книги</returns>
    public override string ToString()
    {
        return Title ?? "<Без названия>";
    }
}