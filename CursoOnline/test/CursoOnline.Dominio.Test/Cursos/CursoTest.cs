using CursoOnline.Dominio.Test._Util;
using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using Xunit;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest
    {
        //Eu, equanto administrador, quero criar e editar cursos para que sejam abertas matriculas para o mesmo.
        //Criterios de aceite
        //-Criar um curso com nome, carga horária, pulico alvo e valor do curso.
        //-As opções para publico alvo são: Estudante, Universitário, Empregado e Empreendedor.
        //-Todos os campos do curso são obrigatórios.

        [Fact]
        public void DeveCriarCurso()
        {
            //arrange
            //objeto anonimo
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorDoCurso = (double)950
            };

            //act
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorDoCurso);

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
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorDoCurso = (double)950
            };

            //Action e assert
           Assert.Throws<ArgumentException>(() => 
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorDoCurso))
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
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = cargaHoraria,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorDoCurso = (double)950
            };

            //Action e assert
           Assert.Throws<ArgumentException>(() => 
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorDoCurso))
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
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double) 80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorDoCurso = valor
            };

            //Action e assert
            Assert.Throws<ArgumentException>(() => 
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorDoCurso))
                .ComMensagem(mensagemEsperada);
        }
    }

    public enum PublicoAlvo
    {
        Estudante, 
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double ValorDoCurso { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valorDoCurso)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Invalido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horaria Invalida!");

            if (valorDoCurso < 1)
                throw new ArgumentException("Valor do Curso Invalido!");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorDoCurso = valorDoCurso;
        }
    }
}
