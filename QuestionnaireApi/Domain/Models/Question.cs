namespace QuestionnaireApi.Domain.Models;
public partial class Question
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int SurveyId { get; set; }

    public int SequenceNumber { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();


}
