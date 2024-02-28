using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.Dto;
using dio_project_net_api_tarefas.Models;

namespace dio_project_net_api_tarefas.Services.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> ListarTarefas(int page);
        
        Tarefa BuscaPorId(int id);
        
        Tarefa Incluir(TarefaDto tarefa);

        Tarefa Alterar(TarefaDto tarefa, int id);

        void Deletar(int id);
    }
}