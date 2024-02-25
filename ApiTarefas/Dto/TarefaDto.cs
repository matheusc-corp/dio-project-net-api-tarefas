using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_project_net_api_tarefas.Dto
{
    public record TarefaDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}