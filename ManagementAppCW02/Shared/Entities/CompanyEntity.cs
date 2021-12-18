using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppCW02.Shared.Entities
{
    public class CompanyEntity
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string? companyName { get; set; }

        [Required]
        public string? companyType { get; set; }

        [Required]
        public int numOfEmployees { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime establishedDate { get; set; }

        public CompanyEntity() { }

    }
}
