using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.Context;
using dio_project_net_api_tarefas.Dto;
using dio_project_net_api_tarefas.Models;
using dio_project_net_api_tarefas.Models.Erros;
using dio_project_net_api_tarefas.Services.Interfaces;

namespace dio_project_net_api_tarefas.Services
{
    public class TarefaService : ITarefaService
    {
        public TarefaService(TarefasContext context){
            _context = context;
        }

        private TarefasContext _context;

        public List<Tarefa> ListarTarefas(int page){
            if(page < 1) page = 1;
            
            int limit = 10;
            int offset = (page - 1) * limit;
            return _context.Tarefas.Skip(offset).Take(limit).ToList();
        }

        public Tarefa Incluir(TarefaDto tarefaDto){
            
            if(string.IsNullOrEmpty(tarefaDto.Titulo))
                throw new TarefaError("O titulo da tarefa nao pode ser vazio");

            var tarefa = new Tarefa{
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Concluida = tarefaDto.Concluida
            };

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return tarefa;
        }

        public Tarefa Alterar(TarefaDto tarefa, int id){
            var tarefaBanco = _context.Tarefas.Find(id);

            if(string.IsNullOrEmpty(tarefa.Titulo))
                throw new TarefaError("O titulo da tarefa nao pode ser vazio");

            if(tarefaBanco == null){
                throw new TarefaError("Tarefa nao encontrada");
            }
            
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Concluida = tarefa.Concluida;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return tarefaBanco;
        }

        public Tarefa BuscaPorId(int id){
            var tarefaBanco = _context.Tarefas.Find(id);

            if(tarefaBanco == null){
                throw new TarefaError("Tarefa nao encontrada");
            }

            return tarefaBanco;
        }

        public void Deletar(int id){
            var tarefaBanco = _context.Tarefas.Find(id);

            if(tarefaBanco == null){
                throw new TarefaError("Tarefa nao encontrada");
            }

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
        }
        
    }
}