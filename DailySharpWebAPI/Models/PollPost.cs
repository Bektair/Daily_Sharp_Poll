namespace DailySharpWebAPI.Models
{
    public class PollPost
    {
        public long Id { get; set; }
        public Poll Poll { get; set; }
        public long PollId { get; set; }
        public DateTime DatePosted { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

    }
}
