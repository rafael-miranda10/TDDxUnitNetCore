using Bogus;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.Dominio.Test._Builders
{
    public class CursoBuilder
    {
        private string _nomeDoCurso;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valorDoCurso;
        private string _descricao;

        public static CursoBuilder Novo()
        {
            var fake = new Faker();
            return new CursoBuilder()
            {
                _nomeDoCurso = fake.Random.Word(),
                _descricao = fake.Lorem.Paragraph(),
                _cargaHoraria = fake.Random.Double(50, 1000),
                _publicoAlvo = (PublicoAlvo) 1,
                _valorDoCurso = fake.Random.Double(100, 1000)
            };
        }

        public CursoBuilder ComNome(string nome)
        {
            _nomeDoCurso = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }
        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValorDoCurso(double valorCurso)
        {
            _valorDoCurso = valorCurso;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nomeDoCurso, _descricao, _cargaHoraria, _publicoAlvo,_valorDoCurso);
        }
    }
}
