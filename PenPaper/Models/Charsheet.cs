namespace PenPaper.Models
{
    public class Charsheet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CharSheetItem { get; set; }
        public int Version { get; set; }
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}