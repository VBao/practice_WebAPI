using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class Setting
    {
        [Key]
        [Required]
        [MaxLength(5, ErrorMessage = "not longer than 5 character")]
        public string AttributeId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "not longer than 30 character")]
        public string AttributeName { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "not longer than 40 character")]
        public string Description { get; set; }
        public bool IsDistributorAttribute { get; set; }
        public bool IsCustomerAttribute { get; set; }
        public bool Used { get; set; }
        public ICollection<Attribute> CustomerMaintenances { get; set; }
    }
}