using System.Text.Json.Serialization;

namespace DailySharpWebAPI.Models
{
    /// <summary>
    /// The reaction has name
    /// it has amount
    /// </summary>
    public class Reaction
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        //Nav
        public long PollPostId { get; set; }
        public PollPost PollPost { get; set; }
    }
}
