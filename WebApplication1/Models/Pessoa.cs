using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        public string Sobrenome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeMae { get; set; }
    }
}