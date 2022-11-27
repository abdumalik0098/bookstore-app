using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 29382-34482","R. Martin", "Clean Code"),
            new Book(2, "ISBN 83742-38272","R. Martin", "Clean Architucture"),
            new Book(3, "ISBN 29932-09928", "M. Fowler", "Refactoring")
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitle(string title)
        {
            return books.Where(book => book.Title.Contains(title))
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query)
                                    || book.Author.Contains(query))
                        .ToArray();
        }
    }
}