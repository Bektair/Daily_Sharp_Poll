using DailySharpWebAPI.Models;

namespace DailySharpWebAPI.DTOs;

public class PollPostReadDTO
{
    public long Id { get; set; }

    public long PollId { get; set; }

    public DateTime DatePosted { get; set; }

    public ICollection<ReactionReadDTO> Reactions { get; set; }
}
