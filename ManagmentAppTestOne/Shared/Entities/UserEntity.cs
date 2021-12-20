using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserOccupation { get; set; }  

        [Required]
        public string UserCapacity { get; set; }    
        
        [Required]
        public string UserEmail { get; set; }   

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }    
    }
}
