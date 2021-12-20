using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class CompanyEntity
    {
        [Key]
        public Guid CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyDescription { get; set; }

        [Required]
        public int NumOfEmployees { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EstablishedDate { get; set; }

        public ICollection<ProjectEntity> Projects { get; set; }
    }
}
