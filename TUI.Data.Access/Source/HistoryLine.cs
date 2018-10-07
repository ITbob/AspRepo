using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source
{
    public class HistoryLine : IIdContainer
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public String DateType { get; set; }
        [Required]
        public OperationType Operation { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
    }
}
