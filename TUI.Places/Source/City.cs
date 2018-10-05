using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Model.Shared.Source;

namespace TUI.Places.Source
{
    public class City: IIdContainer
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        [ForeignKey("Location")]
        public Int32 LocationId { get; set; }
        [Display(Name = "Description")]
        public virtual Location Location { get; set; }
    }
}
