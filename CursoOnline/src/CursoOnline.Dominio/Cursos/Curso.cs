using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double ValorDoCurso { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valorDoCurso)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Invalido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horaria Invalida!");

            if (valorDoCurso < 1)
                throw new ArgumentException("Valor do Curso Invalido!");

            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorDoCurso = valorDoCurso;
        }
    }
}
