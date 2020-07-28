using Xunit;

namespace CursoOnline.Dominio.Test
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "DeveVariavel1SerIgualVariavel2")]
        public void DeveVariavel1SerIgualVariavel2()
        {
            //arrange
            var variavel1 = 1;
            var variavel2 = 2;

            //act
            variavel2 = variavel1;

            //assert
            Assert.Equal(variavel1,variavel2);
        }
    }
}
