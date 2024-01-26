using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serveSLhub.Models.Authentication.Register
{
    public class GramaNiladhariReg
    {
      
        [Required(ErrorMessage ="Grama Niladhari ID is required.")]
        public int GN_ID {  get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string? firstName {  get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string? lastName { get; set; }

        
       
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set;}

        [Required(ErrorMessage = "Address is required.")]
        public string? address { get; set; }

        [Required(ErrorMessage = "Office Address is required.")]
        public string? officeAddress { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        public string? mobileNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public string? dateofBirth { get; set; }

        [Required(ErrorMessage = "Joined Date is required.")]
        public string? joinedDate { get; set; }

        [DataType(DataType.Password)]
        public string? password { get; set; }

       

    }
}
