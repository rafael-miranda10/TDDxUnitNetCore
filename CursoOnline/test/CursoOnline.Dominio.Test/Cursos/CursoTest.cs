using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Test._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest : IDisposable
    {
        //Eu, equanto administrador, quero criar e editar cursos para que sejam abertas matriculas para o mesmo.
        //Criterios de aceite
        //-Criar um curso com nome, carga horária, pulico alvo e valor do curso.
        //-As opções para publico alvo são: Estudante, Universitário, Empregado e Empreendedor.
        //-Todos os campos do curso são obrigatórios.
        //- Curso deve ter uma descrição

        private readonly ITestOutputHelper _outputHelper;
        private readonly string _nomeDoCurso;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valorDoCurso;
        public readonly string _descricao;

        public CursoTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Construtor sendo executado...");

            var faker = new Faker();
            _nomeDoCurso = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(50,1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valorDoCurso = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("Disposeble sendo executado...");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            //arrange
            //objeto anonimo
            var cursoEsperado = new
            {
                Nome = _nomeDoCurso,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                ValorDoCurso = _valorDoCurso,
                Descricao = _descricao
            };

            //act
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorDoCurso);

            //assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            //arrange
            var mensagemEsperada = "Nome Invalido!";

            //Action e assert
           Assert.Throws<ArgumentException>(() => 
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQueUm(double cargaHoraria)
        {
            //arrange
            var mensagemEsperada = "Carga Horaria Invalida!";

            //Action e assert
           Assert.Throws<ArgumentException>(() => 
                CursoBuilder.Novo().ComCargaHoraria(cargaHoraria).Build())
                .ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQueUm(double valor)
        {
            //arrange
            var mensagemEsperada = "Valor do Curso Invalido!";

            //Action e assert
            Assert.Throws<ArgumentException>(() => 
                CursoBuilder.Novo().ComValorDoCurso(valor).Build())
                .ComMensagem(mensagemEsperada);
        }
    } 
}
