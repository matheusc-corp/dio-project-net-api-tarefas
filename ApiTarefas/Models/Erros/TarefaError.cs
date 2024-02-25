using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_project_net_api_tarefas.Models.Erros
{
    public class TarefaError : Exception
    {
        public TarefaError(string? message) : base(message)
        {
        }
    }
}