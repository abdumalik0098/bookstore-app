using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] {new Book(1, "", "", "")});
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] {new Book(1, "", "", "")});

            var bookService = new BookService(bookRepositoryStub.Object);
            var IsValid = "ISBN 32321-22332";
            var actual = bookService.GetAllByQuery(IsValid);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] {new Book(1, "", "", "")});
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] {new Book(1, "", "", "")});

            var bookService = new BookService(bookRepositoryStub.Object);
            var InvalidIsbn = "32321-22332";
            var actual = bookService.GetAllByQuery(InvalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
    }
}
