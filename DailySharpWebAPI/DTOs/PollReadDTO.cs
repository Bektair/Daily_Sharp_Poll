using System;

public class PollReadDTO
{

    public long Id { get; set; }
    public string Topic { get; set; }
    public string OverallQuestion { get; set; }

    public ICollection<QuestionReadDTO> Questions { get; set; }


}
