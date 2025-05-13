using BookStore.Domain.Model;

namespace BookStore.Domain.Services;

/// <summary>
///     Наследник обобщенного интерфейса для авторов с дополнительной функциональностью
/// </summary>
public interface IAuthorRepository : IRepository<Author, int>
{
    /// <summary>
    ///     Метод для вывода 5 наиболее продуктивных авторов по числу написанных страниц
    /// </summary>
    /// <returns>Список кортежей с ФИО автора и числом страниц</returns>
    Task<IList<Tuple<string, int>>> GetTop5AuthorsByPageCount();

    /// <summary>
    ///     Метод для вывода последних 5 выпущенных автором работ
    /// </summary>
    /// <returns></returns>
    Task<IList<Tuple<string, int>>> GetLast5AuthorsBook(int key);
}