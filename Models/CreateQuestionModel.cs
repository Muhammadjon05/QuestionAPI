using QuestionAPI.Entities;

namespace QuestionAPI.Models;

public class CreateQuestionModel
{
    public string Title { get; set; }
    public List<Choice> Choices { get; set; }
    public MediaModel? Medias { get; set; }
}