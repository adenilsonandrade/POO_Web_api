using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto_API.Data.Repositories
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }

        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "DataBaseAP2.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVenda> ProdutosVendas { get; set; }
    }
}