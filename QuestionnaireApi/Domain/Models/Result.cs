namespace QuestionnaireApi.Domain.Models;
public partial class Result
{
    public int Id { get; set; }

    public int InterviewId { get; set; }

    public int UserAnswerId { get; set; }

    public virtual Interview Interview { get; set; } = null!;

    public virtual Answer UserAnswer { get; set; } = null!;
}
