﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class ProjectEntity
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [Required]
        public string ProjectStatus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ProjectStartedDate { get; set; }

        //Foreign key for Company
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

        //Referencing the parent table for Collaboration Entity
        public ICollection<CollaborationEntity> Collaborations { get; set; }

        //Referencing the parent table for Ticket Entity
        public ICollection<TicketEntity> Tickets { get; set; }  
    }
}
