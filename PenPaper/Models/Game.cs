using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PenPaper.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descriptio { get; set; }
        public ICollection<Charsheet> Charsheets { get; set; }
        public int Version { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}