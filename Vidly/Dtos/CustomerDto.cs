using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
        public bool IsSubcribedToNewsLetter { get; set; }

        public int MembershipType_Id { get; set; }


        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}