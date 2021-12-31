using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class TicketEntity
    {   
        [Key]
        public Guid TicketId { get; set; }

        [Required]
        public string TicketTitle { get; set; }

        [Required]
        public string TicketDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime TicketStartedDate { get; set; }

        [Required]
        public string TicketState { get; set; }

        //Foreign key for Project
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; }

        //Foreign key for User
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }   

    }
}
