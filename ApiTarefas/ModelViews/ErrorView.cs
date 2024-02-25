using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace dio_project_net_api_tarefas.ModelViews
{
    public struct ErrorView
    {
        public required string Mensagem { get; set; }
    }
}