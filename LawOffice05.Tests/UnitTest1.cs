using Xunit;

namespace LawOffice05.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("2", 2.ToString());            
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void Test2(int x, int y, int z)
        {
            Assert.Equal(z, x + y);
        }
    }
}