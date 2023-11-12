using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj  = new
             {
                Data=  DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };
            return Ok(obj);

        }
        [HttpGet("Apresentar/{Nome}")]
        public IActionResult Apresentar(string Nome)
        {
           
          var Mensagem = $"Ola {Nome}, Seja Bem-Vindo!!! "; 
           
           
            return Ok(Mensagem);

        }
    }
}