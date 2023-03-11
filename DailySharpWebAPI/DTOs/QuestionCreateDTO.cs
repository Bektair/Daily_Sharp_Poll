using System;

public class QuestionCreateDTO
{   
    public string ImageName { get; set; }
    public string QuestionTxt { get; set; }

    public ICollection<AlternativeCreateDTO> Alternatives { get; set; }

}
