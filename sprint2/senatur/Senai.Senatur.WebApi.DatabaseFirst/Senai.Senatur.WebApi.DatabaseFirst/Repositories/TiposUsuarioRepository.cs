﻿using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }


    }
}
