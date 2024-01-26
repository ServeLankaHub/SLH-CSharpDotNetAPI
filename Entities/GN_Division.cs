using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serveSLhub.Entities
{
    public class GN_Division
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int DivisionID {  get; set; }

        public string DivisionName { get; set; }    

        // Foreign key property
        [ForeignKey("Users")]
        public string UserId { get; set; }

        public Users Users { get; set; }

        public List<PersonDetails> PersonDetails { get; set; }


    }
}
