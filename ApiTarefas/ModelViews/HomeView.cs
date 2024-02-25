using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_project_net_api_tarefas.ModelViews
{
    public struct HomeView
    {
        public required string Mensagem { get; set; }
        public required string Documentacao { get; set; }
    }
}