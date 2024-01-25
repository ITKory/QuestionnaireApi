namespace QuestionnaireApi.Domain.Models;
public partial class Survey
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
