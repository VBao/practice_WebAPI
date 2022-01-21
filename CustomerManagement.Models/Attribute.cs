using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class Attribute
    {
        /* 
       [Key]
       [Required]
       [Column(TypeName ="int")]
       public int Id { get; set; }*/
        // public Setting AttributeMaster { get; set; }

        [Key]
        [Required]
        [MaxLength(2, ErrorMessage = "not longer than 2 character")]
        public string Code { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "not longer than 80 character")]
        public string Description { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "not longer than 40 character")]
        public string ShortName { get; set; }
        public string Parent { get; set; }

        [Required] [Column(TypeName = "date")] public DateTime EffectiveDate { get; set; }

        [Column(TypeName = "date")] public DateTime? ValidUntil { get; set; }
        [StringLength(5)] public String SettingId { get; set; }
        public Setting CustomerSetting { get; set; }
    }
}