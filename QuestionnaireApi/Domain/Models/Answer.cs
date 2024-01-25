namespace QuestionnaireApi.Domain.Models;
public partial class Answer
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int QuestionId { get; set; }

}
