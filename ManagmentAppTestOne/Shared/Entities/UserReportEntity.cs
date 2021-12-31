using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Shared.Entities
{
    public class UserReportEntity
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
