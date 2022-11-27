namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 121-23-22-25 8");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrash_ReturnFalse()
        {
            bool actual = Book.IsIsbn("wwwIsBn 121-23-22-25 8sss");
            Assert.False(actual);
        }
    }
}