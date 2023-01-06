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


    public int Id { get; set; }
    public string Topic { get; set; }

    public string OverallQuestion { get; set; }

    // Navigation Properties

    //public ICollection<Chat> Chats { get; set; }

    public Contributor ContributorName { get; set; }
    public int ContributorId { get; set; }

    //public PollQuestion pollQuestion { get; set; }
    //public int pollQuestionId { get; set; }

}
