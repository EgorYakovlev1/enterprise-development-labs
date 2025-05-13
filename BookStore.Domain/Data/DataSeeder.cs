using BookStore.Domain.Model;

namespace BookStore.Domain.Data;

/// <summary>
///     Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    ///     Коллекция изданий, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Book> Books =
    [
        new()
        {
            Id = 1,
            Title = "Чистый код. Создание, анализ и рефакторинг",
            Year = 2008,
            PageCount = 464
        },
        new()
        {
            Id = 2,
            Title = "Чистая архитектура. Искусство разработки программного обеспечения",
            Year = 2017,
            PageCount = 352
        },
        new()
        {
            Id = 3,
            Title = "Чистый Agile. Основы гибкости",
            Year = 2023,
            PageCount = 272
        },
        new()
        {
            Id = 4,
            Title = "Идеальная работа. Программирование без прикрас",
            Year = 2023,
            PageCount = 384
        },
        new()
        {
            Id = 5,
            Title = "Идеальный программист. Как стать профессионалом разработки ПО",
            Year = 2011,
            PageCount = 224
        },
        new()
        {
            Id = 6,
            Title = "Совершенный код. Мастер-класс",
            Year = 2005,
            PageCount = 896
        },
        new()
        {
            Id = 7,
            Title = "Профессиональная разработка программного обеспечения",
            Year = 2006,
            PageCount = 234
        },
        new()
        {
            Id = 8,
            Title = "Остаться в живых. Руководство для менеджера программных проектов",
            Year = 2006,
            PageCount = 240
        }
    ];

    /// <summary>
    ///     Коллекция авторов, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Author> Authors =
    [
        new()
        {
            Id = 1,
            FirstName = "Роберт",
            LastName = "Мартин"
        },
        new()
        {
            Id = 2,
            FirstName = "Стив",
            LastName = "Макконнелл"
        },
        new()
        {
            Id = 3,
            FirstName = "Джон",
            LastName = "Карр"
        }
    ];

    /// <summary>
    ///     Коллекция свзей авторов и изданий, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<BookAuthor> BookAuthors =
    [
        new()
        {
            Id = 1,
            BookId = 1,
            AuthorId = 1
        },
        new()
        {
            Id = 2,
            BookId = 2,
            AuthorId = 1
        },
        new()
        {
            Id = 3,
            BookId = 3,
            AuthorId = 1
        },
        new()
        {
            Id = 4,
            BookId = 4,
            AuthorId = 1
        },
        new()
        {
            Id = 5,
            BookId = 5,
            AuthorId = 1
        },
        new()
        {
            Id = 6,
            BookId = 6,
            AuthorId = 2
        },
        new()
        {
            Id = 7,
            BookId = 7,
            AuthorId = 2
        },
        new()
        {
            Id = 8,
            BookId = 8,
            AuthorId = 2
        }
    ];
}