using ConectaStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaStore.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias  { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedCategoria(modelBuilder);
        SeedProduto(modelBuilder);
    }
    
    private static void SeedCategoria(ModelBuilder builder)
    {
        List<Categoria> categorias = [
            new() { Id = 1, Nome = "Smartphones", Cor = "rgba(0,0,0,1)" },  
            new() { Id = 2, Nome = "Notebooks", Cor = "rgba(0,0,0,1)" },  
            new() { Id = 3, Nome = "Smartwatches", Cor = "rgba(0,0,0,1)" },  
            new() { Id = 4, Nome = "Fones de Ouvido", Cor = "rgba(0,0,0,1)" },
            new() { Id = 5, Nome = "Tablets", Cor = "rgba(0,0,0,1)" },
            new() { Id = 6, Nome = "Monitores", Cor = "rgba(0,0,0,1)" },
            new() { Id = 7, Nome = "Periféricos", Cor = "rgba(0,0,0,1)" },
            new() { Id = 8, Nome = "Acessórios", Cor = "rgba(0,0,0,1)" }
        ];
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProduto(ModelBuilder builder)
    {
        List<Produto> produtos = [
            // Smartphones (CategoriaId = 1)
            new() {
                Id = 1, CategoriaId = 1, Nome = "Iphone 17 Pro",
                Descricao = "Iphone 17 Pro, 256Gb, 12Gb RAM",
                ValorCusto = 6500.00m, ValorVenda = 8999.00m, Qtde = 5, Destaque = true, Foto = null
            },
            new() {
                Id = 2, CategoriaId = 1, Nome = "Samsung Galaxy S24 Ultra",
                Descricao = "Galaxy S24 Ultra, 512Gb, 12Gb RAM, Titanium",
                ValorCusto = 5800.00m, ValorVenda = 7999.00m, Qtde = 8, Destaque = true, Foto = null
            },

            // Notebooks (CategoriaId = 2)
            new() {
                Id = 3, CategoriaId = 2, Nome = "MacBook Pro 14\"",
                Descricao = "MacBook Pro 14 polegadas, Chip M3 Pro, 18GB RAM, 512GB SSD",
                ValorCusto = 11000.00m, ValorVenda = 15499.00m, Qtde = 3, Destaque = true, Foto = null
            },
            new() {
                Id = 4, CategoriaId = 2, Nome = "Dell XPS 15",
                Descricao = "Dell XPS 15, Intel Core i9 13ª Ger, 32GB RAM, 1TB NVMe, RTX 4070",
                ValorCusto = 9500.00m, ValorVenda = 13200.00m, Qtde = 4, Destaque = false, Foto = null
            },

            // Smartwatches (CategoriaId = 3)
            new() {
                Id = 5, CategoriaId = 3, Nome = "Apple Watch Ultra 2",
                Descricao = "Apple Watch Ultra 2, Caixa de Titânio 49mm, GPS + Cellular",
                ValorCusto = 4200.00m, ValorVenda = 5999.00m, Qtde = 6, Destaque = true, Foto = null
            },
            new() {
                Id = 6, CategoriaId = 3, Nome = "Galaxy Watch 6 Classic",
                Descricao = "Galaxy Watch 6 Classic 47mm, LTE, Prata",
                ValorCusto = 1500.00m, ValorVenda = 2199.00m, Qtde = 10, Destaque = false, Foto = null
            },

            // Fones de Ouvido (CategoriaId = 4)
            new() {
                Id = 7, CategoriaId = 4, Nome = "AirPods Pro (2ª Geração)",
                Descricao = "AirPods Pro com Estojo de Recarga MagSafe (USB-C)",
                ValorCusto = 1200.00m, ValorVenda = 1899.00m, Qtde = 15, Destaque = true, Foto = null
            },
            new() {
                Id = 8, CategoriaId = 4, Nome = "Sony WH-1000XM5",
                Descricao = "Headphone Sony WH-1000XM5 Noise Cancelling, Preto",
                ValorCusto = 1800.00m, ValorVenda = 2599.00m, Qtde = 7, Destaque = true, Foto = null
            },

            // Tablets (CategoriaId = 5)
            new() {
                Id = 9, CategoriaId = 5, Nome = "iPad Pro 11\"",
                Descricao = "iPad Pro 11 polegadas, Chip M4, Wi-Fi, 256GB",
                ValorCusto = 6000.00m, ValorVenda = 8499.00m, Qtde = 5, Destaque = false, Foto = null
            },
            new() {
                Id = 10, CategoriaId = 5, Nome = "Galaxy Tab S9 Ultra",
                Descricao = "Samsung Galaxy Tab S9 Ultra 14.6\", 512GB, com S Pen",
                ValorCusto = 5500.00m, ValorVenda = 7999.00m, Qtde = 4, Destaque = false, Foto = null
            },

            // Monitores (CategoriaId = 6)
            new() {
                Id = 11, CategoriaId = 6, Nome = "Monitor LG UltraGear 27\"",
                Descricao = "Monitor Gamer LG UltraGear 27\" IPS, 144Hz, 1ms, G-Sync",
                ValorCusto = 1100.00m, ValorVenda = 1599.00m, Qtde = 12, Destaque = false, Foto = null
            },
            new() {
                Id = 12, CategoriaId = 6, Nome = "Monitor Dell UltraSharp 32\"",
                Descricao = "Monitor Dell UltraSharp 32\" 4K USB-C Hub",
                ValorCusto = 3800.00m, ValorVenda = 5200.00m, Qtde = 3, Destaque = true, Foto = null
            },

            // Periféricos (CategoriaId = 7)
            new() {
                Id = 13, CategoriaId = 7, Nome = "Logitech MX Master 3S",
                Descricao = "Mouse Sem Fio Logitech MX Master 3S, Sensor 8K DPI",
                ValorCusto = 450.00m, ValorVenda = 699.00m, Qtde = 20, Destaque = false, Foto = null
            },
            new() {
                Id = 14, CategoriaId = 7, Nome = "Teclado Keychron K2",
                Descricao = "Teclado Mecânico Sem Fio Keychron K2, Switches Gateron Brown",
                ValorCusto = 550.00m, ValorVenda = 850.00m, Qtde = 15, Destaque = false, Foto = null
            },

            // Acessórios (CategoriaId = 8)
            new() {
                Id = 15, CategoriaId = 8, Nome = "Carregador Anker 735",
                Descricao = "Carregador Anker 735 (Nano II 65W), 3 Portas",
                ValorCusto = 200.00m, ValorVenda = 350.00m, Qtde = 30, Destaque = false, Foto = null
            },
            new() {
                Id = 16, CategoriaId = 8, Nome = "Powerbank Baseus 20000mAh",
                Descricao = "Carregador Portátil Baseus 20000mAh 65W PD",
                ValorCusto = 280.00m, ValorVenda = 450.00m, Qtde = 25, Destaque = false, Foto = null
            }
        ];
        builder.Entity<Produto>().HasData(produtos);
    }
}