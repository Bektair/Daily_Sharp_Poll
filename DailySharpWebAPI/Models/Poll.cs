using DailySharpWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// The poll has one or zero overall questions
/// It has a contributor(default me) of the poll
/// It has one to many pollQuestion
/// It has a topic
/// </summary>
public class Poll
{
    public long Id { get; set; }
    public string Topic { get; set; }

    public string OverallQuestion { get; set; }

    // Navigation Properties
    public long ContributorId { get; set; }

    public Contributor Contributor { get; set; }

    public ICollection<Question> Questions { get; set; }

    [JsonIgnore]
    public ICollection<PollPost> PollPost { get; set; }


}
