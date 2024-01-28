using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serveSLhub.Entities
{
    public class PersonDetails
    {
        [Key]
        
        public int PersonId { get; set; }


        [ForeignKey("GN_Division")]
        public int DivisionID { get; set; }
        public string FullName { get; set; }
        public string Name_with_initials {  get; set; }

        public string Email { get; set; }

        public string Date_of_Birth { get; set; }

        public string Occupation {  get; set; }

        public string Married_Status {  get; set; }

        public string Address { get; set; }

        public string Phone_number {  get; set; }
        public string NIC { get; set; }
        public string Religion {  get; set; }
        public string Office_Address { get; set; }
        public string Date_of_Residence { get; set; }

        
        
        public virtual GN_Division GN_Division { get; set; }
        public virtual Family_Members FamilyMembers { get; set; }
    }
}
