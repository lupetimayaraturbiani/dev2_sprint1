﻿using senai.filme.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace senai.filme.webapi.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Listar todos os gêneros
        /// </summary>
        /// <returns></returns>
        List<GeneroDomain> Listar();

        /// <summary>
        /// Cadastraum novo gênero
        /// </summary>
        /// <param name="genero">um gênero</param>
        bool Cadastrar(string Nome);
        void Atualizar(string Nome, int IdGenero);
        void Deletar(int IdGenero);

        GeneroDomain BuscarPorId(int Id);
    }
}
