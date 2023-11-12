using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context= context;
        }
        [HttpPost("CriarContato")]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
            
        }
        [HttpGet("{id}")]
        public IActionResult ObterporId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
                return NotFound();
            return Ok(contato);

        }
        [HttpPut("{Atualizar}")]
        public IActionResult Atualizar(int Id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(Id);
            if(contatoBanco == null)
                return NotFound();
            
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone= contato.Telefone;
            contatoBanco.Ativo=contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            return Ok(contatoBanco);
        }
        [HttpGet("ObterporNome")]
        public IActionResult ObterporNome (string Nome)
        {
            var Contatos = _context.Contatos.Where(x => x.Nome.Contains(Nome));
            return Ok(Contatos);
        }
        
        
        
        [HttpDelete("{Id}")]
        public IActionResult Deletar (int Id){
            var contatoBanco =_context.Contatos.Find(Id);
            if (contatoBanco == null)
                return NotFound();
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();

        }
    }
}