using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.Context;
using dio_project_net_api_tarefas.Dto;
using dio_project_net_api_tarefas.Models;
using dio_project_net_api_tarefas.Models.Erros;
using dio_project_net_api_tarefas.ModelViews;
using dio_project_net_api_tarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace dio_project_net_api_tarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        private TarefaService _service;
        public TarefasController(TarefaService service){
            _service = service;
        }

        [HttpGet()]
        public IActionResult Index(){
            var tarefas = _service.ListarTarefas();

            return StatusCode(200, tarefas);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] TarefaDto tarefadto){
            try{
                var tarefa = _service.Incluir(tarefadto);

                return StatusCode(201, tarefa);
            }
            catch(TarefaError e){
                return StatusCode(400, new ErrorView { Mensagem = e.Message});
            }

            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TarefaDto tarefadto, [FromRoute] int id)
        {
            try{
                var tarefaBanco = _service.Alterar(tarefadto, id);
                
                return StatusCode(200, tarefaBanco);
            }
            catch(TarefaError e){
                return StatusCode(400, new ErrorView { Mensagem = e.Message});
            }            
        }

        [HttpGet("{id}")]
        public IActionResult Show([FromRoute] int id){
            try{
                var tarefa = _service.BuscaPorId(id);
                return StatusCode(200, tarefa);
            }
            catch(TarefaError e){
                return StatusCode(404, new ErrorView{ Mensagem = e.Message});
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            try{
                _service.Deletar(id);

                return StatusCode(204);
            }
            catch(TarefaError e){
                return StatusCode(404, new ErrorView{ Mensagem = e.Message});
            }
        }        
    }
}