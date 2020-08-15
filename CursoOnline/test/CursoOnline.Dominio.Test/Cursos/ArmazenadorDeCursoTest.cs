using Bogus;
using CursoOnline.Dominio.Cursos;
using Moq;
using Xunit;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private CursoDto _cursoDto;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = fake.Random.Word(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(50, 1000),
                PublicoAlvo = 1,
                ValorDoCurso = fake.Random.Double(100, 1000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            //cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
            //cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(
            //    c => c.Nome == cursoDto.Nome &&
            //    c.Descricao == cursoDto.Descricao
            //    )), Times.AtLeast(2));
            //cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(
            //   c => c.Nome == cursoDto.Nome &&
            //   c.Descricao == cursoDto.Descricao
            //   )), Times.Never);
            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(
               c => c.Nome == _cursoDto.Nome &&
               c.Descricao == _cursoDto.Descricao
               )));
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
    }

    public class ArmazenadorDeCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.ValorDoCurso);

            _cursoRepositorio.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public int PublicoAlvo { get; set; }
        public double ValorDoCurso { get; set; }
    }
}
