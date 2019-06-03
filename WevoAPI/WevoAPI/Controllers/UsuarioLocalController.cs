using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WevoAPI.DbModels;
using WevoAPI.Models;

namespace WevoAPI.Controllers
{
    [Route("api/usuarioLocal")]
    [ApiController]
    public class UsuarioLocalController : ControllerBase
    {
        static readonly IUsuarioRepositorio repositorio = new UsuarioRepositorioLocal();

        [HttpPost]
        [Route("addUsuario")]
        public IActionResult PostUsuario(Usuario u)
        {
            try
            {
                repositorio.AddUsuario(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateUsuario")]
        public IActionResult PutUsuario(Usuario u)
        {
            try
            {
                repositorio.Update(u);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUsuario/{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                repositorio.DeleteUsuario(id);
                return Ok("Removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getUsuarios")]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = repositorio.GetUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getUsuario/{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                var usuarios = repositorio.GetUsuarioById(id);

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}