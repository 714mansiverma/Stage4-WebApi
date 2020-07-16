using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCheck.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ItemPrice { get; set; }
        [Required]
        public string Active { get; set; }
        public DateTime? DOL { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string FreeDelivery { get; set; }
    }
}
