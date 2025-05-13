using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Model;

/// <summary>
///     Автор
/// </summary>
public class Author
{
    /// <summary>
    ///     Идентификатор автора
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Имя автора
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Фамилия автора
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Отчество автора
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Биография автора
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    ///     Список работ
    /// </summary>
    public virtual List<BookAuthor>? BookAuthors { get; set; }

    /// <summary>
    ///     Число работ
    /// </summary>
    public int? BookCount => BookAuthors?.Count;

    /// <summary>
    ///     Метод для подсчета общего числа написанных автором страниц
    /// </summary>
    /// <returns>Сумма написанных автором страниц</returns>
    public int? GetPageCount()
    {
        var sum = 0;
        if (BookAuthors?.Count > 0)
        {
            foreach (BookAuthor? ba in BookAuthors)
            {
                if (ba != null && ba.Book != null)
                {
                    sum += ba.Book.PageCount ?? 0;
                }
            }
        }

        return sum;
    }

    /// <summary>
    ///     Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Имя автора</returns>
    public override string ToString()
    {
        return string.IsNullOrEmpty(Patronymic)
            ? $"{FirstName} {LastName}"
            : $"{LastName} {FirstName} {Patronymic}";
    }
}