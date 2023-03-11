namespace DailySharpWebAPI.DTOs;

public class PollPostCreateDTO
{
    public DateTime DatePosted { get; set; }

    public ICollection<ReactionCreateDTO> Reactions { get; set; }
}
