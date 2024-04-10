using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio04.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio04.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}