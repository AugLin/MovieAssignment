using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchases
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime PurchaseTime { get; set; }

        [Required]
        [Column(TypeName = "UNIQUEIDENTIFIER ")]
        public string? PurchaseNumber { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(5,2) ")]
        public decimal TotalPrice { get; set; }
    }
}
