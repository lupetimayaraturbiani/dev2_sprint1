﻿
using Senai.Inlock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Context;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Repositories
{
    public class TipoUsuarioRepository: ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, TipoUsuario tipoAtualizado)
        {
            var tipoProcurado = BuscarPorId(id);

            if (tipoProcurado != null)
            {
                tipoProcurado.Titulo = tipoAtualizado.Titulo;
                ctx.TipoUsuario.Update(tipoProcurado);
                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
