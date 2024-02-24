using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_project_net_api_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace dio_project_net_api_tarefas.Context
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options){}

        public DbSet<Tarefa> Tarefas{ get; set; }
        
    }
}