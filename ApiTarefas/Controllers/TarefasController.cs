using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.Context;
using dio_project_net_api_tarefas.Models;
using dio_project_net_api_tarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace dio_project_net_api_tarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        private TarefasContext _context;
        public TarefasController(TarefasContext context){
            _context = context;
        }

        [HttpGet()]
        public IActionResult Index(){
            var tarefas = _context.Tarefas.ToList();

            return StatusCode(200, tarefas);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Tarefa tarefa){

            if(string.IsNullOrEmpty(tarefa.Titulo))
                return StatusCode(404, new ErrorView{ Mensagem = "O titulo é obrigatório"});

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return StatusCode(201, tarefa);            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Tarefa tarefa, [FromRoute] int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if(tarefaBanco == null)
                return StatusCode(404, new ErrorView{ Mensagem = $"A tarefa não foi encontrada pelo id {id}"});

            if(string.IsNullOrEmpty(tarefa.Titulo))
                return StatusCode(404, new ErrorView{ Mensagem = "O titulo é obrigatório"});

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Concluida = tarefa.Concluida;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return StatusCode(200, tarefaBanco);
        }

        [HttpGet("{id}")]
        public IActionResult Show([FromRoute] int id){
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
                return StatusCode(404, new ErrorView{ Mensagem = $"A tarefa não foi encontrada pelo id {id}"});

            return StatusCode(200, tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
                return StatusCode(404, new ErrorView{ Mensagem = $"A tarefa não foi encontrada pelo id {id}"});

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return StatusCode(204);
        }
        
    }
}