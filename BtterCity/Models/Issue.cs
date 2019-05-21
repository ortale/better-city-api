using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BtterCity.Enums;

namespace BtterCity.Models
{
    public class Issue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public IssueType IssueType { get; set; }
        public EnumStatus Status { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Image { get; set; }
        public DateTime? Created { get; set; }
        public User User { get; set; }
    }
}
