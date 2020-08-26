﻿using System;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDto.Nome);
            if (cursoJaSalvo != null)
                throw new ArgumentException("Nome do curso já consta no banco de dados");

            if(!Enum.TryParse<PublicoAlvo>(cursoDto.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Publico Alvo Invalido");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.ValorDoCurso);

            _cursoRepositorio.Adicionar(curso);
        }
    }

}
