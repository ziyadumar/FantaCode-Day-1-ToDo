using System.ComponentModel.DataAnnotations;
using System;

namespace FantaCode.Todoapi
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public Boolean Done { get; set; }
    }
}
