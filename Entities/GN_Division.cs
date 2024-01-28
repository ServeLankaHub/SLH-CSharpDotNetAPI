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
        public string Id { get; set; }

        public virtual Users Users { get; set; }

        public virtual ICollection<PersonDetails> PersonDetails { get; set; }


    }
}
