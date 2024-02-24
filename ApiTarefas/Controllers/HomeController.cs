using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace dio_project_net_api_tarefas.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {

        [HttpGet()]
        public HomeView Index(){
            return new HomeView{
                Mensagem = "Bem vindo a API de tarefas",
                Documentacao = "/swagger"
            };
        }
        
    }
}