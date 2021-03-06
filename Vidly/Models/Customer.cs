using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please enter name of the customer")]
        [StringLength(225)]
        public string Name { get; set; }
        public bool IsSubcribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
       [ForeignKey("MembershipType")]
       [Display(Name ="Membership Type")]
        public int MembershipType_Id { get; set; }


        //[Display(Name="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

    }
}