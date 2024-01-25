namespace QuestionnaireApi.Domain.Models;
public partial class Interview
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string SessionId { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
