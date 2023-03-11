using System;
/// <summary>
/// User/Contributor has discord id
/// It has discord name
/// </summary>
public class Contributor
{
    public string DiscordId { get; set; }

    public long Id { get; set; }

	public string NickName { get; set; }

    public ICollection<Poll> Poll { get; set; }
}
