using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dio_project_net_api_tarefas.Models
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        
        [Column(TypeName = "text")]
        public string Descricao { get; set; }
        
        public bool Concluida { get; set; }
        
    }
}