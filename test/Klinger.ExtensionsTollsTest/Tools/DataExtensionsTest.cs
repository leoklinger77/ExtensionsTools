using Klinger.ExtensionsTools.Tools;
using Xunit;

namespace Klinger.ExtensionsTollsTest.Tools
{
    public class DataExtensionsTest
    {
        [Fact(DisplayName = "Data Informada esta dentro de um perido de ano informado")]
        [Trait("Tools", "DataExtensions")]        
        public void Data_DataLessThanYears_ShouldReturnFalse()
        {
            //Arrange
            var data = DateTime.Now.AddYears(-5);

            //Act
            var result = data.DateLessThanYear(10);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data Informada esta fora do periodo de ano informado")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DataLessThanYears_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now.AddYears(-11);

            //Act
            var result = data.DateLessThanYear(10);

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Data Informada esta dentro do periodo de mes informado")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateLessThanMonths_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now.AddMonths(-10);

            //Act
            var result = data.DateLessThanMonths(10);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data Informada esta fora do periodo de mes informado")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateLessThanMonths_ShouldReturnDalse()
        {
            //Arrange
            var data = DateTime.Now.AddMonths(-11);

            //Act
            var result = data.DateLessThanMonths(10);

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Data Informada esta dentro do periodo de dias informado")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateLessThanDays_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now.AddDays(-14);

            //Act
            var result = data.DateLessThanDays(15);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data Informada esta fora do periodo de dias informado")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateLessThanDays_ShouldReturnDalse()
        {
            //Arrange
            var data = DateTime.Now.AddDays(-22);

            //Act
            var result = data.DateLessThanDays(20);

            //Assert
            Assert.False(result);
        }





        [Fact(DisplayName = "Data é menor que Ano parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DataGreaterThanYears_ShouldReturnFalse()
        {
            //Arrange
            var data = DateTime.Now;

            //Act
            var result = data.DateGreaterThanYears();

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data é maior que Ano parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DataGreaterThanYears_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now.AddYears(2);

            //Act
            var result = data.DateGreaterThanYears(1);

            //Assert
            Assert.False(result);
        }




        [Fact(DisplayName = "Data é menor que mes parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateGreaterThanMonths_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now;

            //Act
            var result = data.DateGreaterThanMonths(10);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data é maior que mes parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateGreaterThanMonths_ShouldReturnFalse()
        {
            //Arrange
            var data = DateTime.Now.AddMonths(11);

            //Act
            var result = data.DateGreaterThanMonths(10);

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "Data é menor que dia parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateGreaterThanDays_MustRunSuccessfully()
        {
            //Arrange
            var data = DateTime.Now;

            //Act
            var result = data.DateGreaterThanDays(15);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Data é maior que dia parametro")]
        [Trait("Tools", "DataExtensions")]
        public void Data_DateGreaterThanDays_ShouldReturnFalse()
        {
            //Arrange
            var data = DateTime.Now.AddDays(22);

            //Act
            var result = data.DateGreaterThanDays(20);

            //Assert
            Assert.False(result);
        }



        [Fact(DisplayName = "verificando se é Maior de idade")]
        [Trait("Tools", "DataExtensions")]
        public void Date_IsUnderage_MustRunsuccessfully()
        {
            //Arrange
            var date = DateTime.Parse("1995-09-11");

            //Act
            var result = date.IsUnderage(18);

            //Assert
            Assert.True(!result);
        }

        [Fact(DisplayName = "verificando se é menor de idade")]
        [Trait("Tools", "DataExtensions")]
        public void Date_IsUnderage_ShouldReturnFalse()
        {
            //Arrange
            var date = DateTime.Parse("2015-09-11");

            //Act
            var result = date.IsUnderage(18);

            //Assert
            Assert.False(!result);
        }
    }
}
