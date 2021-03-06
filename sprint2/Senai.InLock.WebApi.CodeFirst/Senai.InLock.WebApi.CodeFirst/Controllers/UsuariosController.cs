﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.CodeFirst.Interfaces;
using Senai.Inlock.WebApi.DatabaseFirst.Repositories;
using Senai.InLock.WebApi.CodeFirst.Domains;

namespace Senai.Inlock.WebApi.CodeFirst.Controllers
{
    [Route("api/[controller]")]

    [Produces("application/json")]

    [ApiController]
    public class UsuariosController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public List<Usuarios> Get()
        {
            return _usuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            if (novoUsuario != null)
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }

            return BadRequest("Os campos não foram preenchidos corretamente");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuarios usuarioAtualizado)
        {
            if (usuarioAtualizado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest("Não foi possível atualizar o usuário");
                }
            }

            return NotFound("Usuário não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);
                return Ok($"O usuário {id} foi deletado com sucesso!");
            }

            return NotFound("Usuário não encontrado");
        }
    }
}