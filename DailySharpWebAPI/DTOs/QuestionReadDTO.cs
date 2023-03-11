using System;

public class QuestionReadDTO
{

    public long Id { get; set; }
    public string ImageName { get; set; }
    public string QuestionTxt { get; set; }

    public ICollection<AlternativeReadDTO> AlternativeReadDTOs { get; set; }


}
