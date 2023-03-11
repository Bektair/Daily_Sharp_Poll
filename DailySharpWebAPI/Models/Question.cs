using DailySharpWebAPI.Models;
using Newtonsoft.Json;
using System;
/// <summary>
/// The question has one or zero pictures
///I have one to many alternatives 
/// </summary>
public class Question
{
    public long Id { get; set; }
    public string ImageName { get; set; }
    public string QuestionTxt { get; set; }

    //NAV
    [JsonIgnore]
    public Poll Poll { get; set; }
    public long PollId { get; set; }

    public ICollection<Alternative> Alternatives { get; set; }


}
