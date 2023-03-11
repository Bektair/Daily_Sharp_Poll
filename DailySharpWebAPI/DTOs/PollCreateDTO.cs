namespace DailySharpWebAPI.DTOs;

public class PollCreateDTO
{
    public string Topic { get; set; }
    public string OverallQuestion { get; set; }
    public long ContributorId { get; set; }
    public ICollection<PollPostCreateDTO> PollPost { get; set; }
    public ICollection<QuestionCreateDTO> Questions { get; set; }
}
