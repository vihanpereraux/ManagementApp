using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppCW02.Shared.Entities
{
    public class ProjectEntity
    {
        [Key]
        public Guid projectId { get; set; }

        [Required]
        public string? projectName { get; set; }

        [Required]
        public string? projectDescription { get; set; }

        [Required]
        public string? projectStatus { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime projectStartedDate { get; set; }

        public CompanyEntity Company { get; set; }

        public ProjectEntity() { }
    }
}
