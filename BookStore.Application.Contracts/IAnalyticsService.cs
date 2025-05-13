namespace BookStore.Application.Contracts;

/// <summary>
///     Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    ///     Метод для вывода 5 наиболее продуктивных авторов по числу написанных страниц
    /// </summary>
    /// <returns>Список кортежей с ФИО автора и числом страниц</returns>
    Task<IList<Tuple<string, int>>> GetTop5AuthorsByPageCount();

    /// <summary>
    ///     Метод для вывода последних 5 выпущенных автором работ
    /// </summary>
    /// <returns>Список кортежей с названием книги и годом выпуска</returns>
    Task<IList<Tuple<string, int>>> GetLast5AuthorsBook(int key);
}