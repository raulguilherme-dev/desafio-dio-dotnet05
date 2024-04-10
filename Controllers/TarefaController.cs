using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Desafio04.Context;
using Desafio04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio04.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;
        private readonly ILogger<TarefaController> _logger;

        public TarefaController(TarefaContext context, ILogger<TarefaController> logger) {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetTarefaById(int id) {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTarefa(int id, Tarefa tarefa) {
            var tarefaBanco = _context.Tarefas.Find(id);
            if (tarefaBanco == null) {
                return NotFound();
            }

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTarefa(int id) {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("obeterTodos")]
        public IActionResult GetAllTarefas() {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }

        [HttpGet("obeterPorTitulo")]
        public IActionResult GetTarefaByTitulo(string titulo) {
            var tarefa = _context.Tarefas.Where(t => t.Titulo == titulo).ToList();
            if (tarefa.Count == 0) {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("obterPorData")]
        public IActionResult GetTarefaByData(DateTime date) {
            var tarefa = _context.Tarefas.Where(t => t.Data == date).ToList();
            if (tarefa.Count == 0) {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("obterPorStatus")]
        public IActionResult GetTarefaByStatus(EnumStatusTarefa status) {
            var tarefa = _context.Tarefas.Where(t => t.Status == status).ToList();
            if (tarefa.Count == 0) {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult CreateTarefa(Tarefa tarefa) {
    
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }
    }
}