using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int ActorID { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; } = string.Empty;
    }
}
