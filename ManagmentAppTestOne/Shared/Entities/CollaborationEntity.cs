using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class CollaborationEntity
    {
        [Key]
        public Guid CollaborationId { get; set; }

        //Foreign key and reference for User
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        //Foreign key and reference for Project
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
