﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serveSLhub.Entities
{
    public class Family_Members

    {
        [Key]
        [ForeignKey("PersonDetails")]
        public int PesronID { get; set; }

        [ForeignKey("Family")]
        public int FamilyID { get; set; }

        public string Family_Position {  get; set; }
        public bool Ishead {  get; set; }

        public virtual PersonDetails PersonDetails { get; set; }
        public virtual Family Family { get; set; }
    }
}
