using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace serveSLhub.Entities
{
    public class Users : IdentityUser
    {
    
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string? address { get; set; }


        public string? officeAddress { get; set; }


        public string? mobileNumber { get; set; }


        public string? dateofBirth { get; set; }
        public string? joinedDate { get; set; }

        
    }
}
