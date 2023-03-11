using System.Text.Json.Serialization;

namespace DailySharpWebAPI.Models
{
    public class Alternative
    {
        public long Id { get; set; }
        public string AltTxt { get; set; }

        //NAV
        public long QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
