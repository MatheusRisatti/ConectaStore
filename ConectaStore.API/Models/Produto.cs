using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConectaStore.API.Models;

    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(3000)]
        public string Descricao { get; set; }
        [Required]
        public int Qtde { get; set; } = 0;
        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal ValorCusto { get; set; }
        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal ValorVenda { get; set; }
        [NotMapped]
        public decimal MargemLucro => ValorVenda - ValorCusto;

        public decimal Destaque { get; set; }

        [StringLength(300)]
        public string Foto { get; set; }
        
        }
